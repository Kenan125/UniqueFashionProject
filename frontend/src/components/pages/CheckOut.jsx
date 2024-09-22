import { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { clearCart, getCartItems } from '../../services/cartUtils.js';
import axios from 'axios';
import ShippingAddress from "../layout/checkoutLayout/ShippingAddress.jsx";
import CardInfo from "../layout/checkoutLayout/CardInfo.jsx";

function Checkout() {
    const navigate = useNavigate();
    const cartItems = getCartItems();
    const totalPrice = cartItems.reduce((total, item) => total + item.price * item.quantity, 0);

    const [savedAddresses, setSavedAddresses] = useState([]);
    const [selectedAddressId, setSelectedAddressId] = useState(null);
    const [shippingAddress, setShippingAddress] = useState({
        addressLine: '',
        district: '',
        city: '',
        postalCode: ''
    });
    const [useNewAddress, setUseNewAddress] = useState(true); // Set to true by default

    const [savedCards, setSavedCards] = useState([]);
    const [selectedCardId, setSelectedCardId] = useState(null);
    const [cardInfo, setCardInfo] = useState({
        maskedCardNumber: '',
        cardholderName: '',
        expirationDate: ''
    });
    const [useNewCard, setUseNewCard] = useState(true); // Set to true by default
    const [saveCard, setSaveCard] = useState(false);

    useEffect(() => {
        const fetchSavedData = async () => {
            try {
                const userId = localStorage.getItem('userId');
                const token = localStorage.getItem('token');

                if (!userId || !token) {
                    console.error("User ID or token is missing, please log in.");
                    navigate('/login');
                    return;
                }

                const config = {
                    headers: {
                        'Authorization': `Bearer ${token}`
                    }
                };

                // Fetch saved shipping addresses
                const addressResponse = await axios.get(`https://localhost:7051/api/shippingAddresses`, config);
                if (addressResponse.data && addressResponse.data.length > 0) {
                    setSavedAddresses(addressResponse.data);
                    setSelectedAddressId(addressResponse.data[0].id);
                    setUseNewAddress(false);
                } else {
                    setUseNewAddress(true);
                }

                // Fetch saved card infos
                const cardResponse = await axios.get(`https://localhost:7051/api/cardInfos`, config);
                if (cardResponse.data && cardResponse.data.length > 0) {
                    setSavedCards(cardResponse.data);
                    setSelectedCardId(cardResponse.data[0].id);
                    setUseNewCard(false);
                } else {
                    setUseNewCard(true);
                }
            } catch (error) {
                console.error('Error fetching saved data:', error);
                setUseNewAddress(true);
                setUseNewCard(true);
            }
        };

        fetchSavedData();
    }, [navigate]);

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            const userId = localStorage.getItem('userId');
            const token = localStorage.getItem('token');

            if (!userId || !token) {
                alert("You must be logged in to complete the checkout");
                navigate('/login');
                return;
            }

            const config = {
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${token}`
                }
            };

            // Prepare shipping address
            let shippingAddressData = {};
            if (useNewAddress) {
                shippingAddressData = shippingAddress;
            } else {
                shippingAddressData = savedAddresses.find(addr => addr.id === selectedAddressId);
            }

            // Prepare card info
            let cardInfoData = {};
            if (useNewCard) {
                cardInfoData = cardInfo;
            } else {
                cardInfoData = savedCards.find(card => card.id === selectedCardId);
            }

            // Send checkout data to the backend
            const response = await axios.post('https://localhost:7051/api/checkout', {
                userId,
                cartItems: cartItems.map(item => ({
                    productId: item.productId,
                    price: item.price,
                    quantity: item.quantity
                })),
                cardInfo: cardInfoData,
                shippingAddress: shippingAddressData,
                saveCard: saveCard && useNewCard  // Only save card if it's new and user wants to save it
            }, config);

            if (response.status === 200) {
                const data = response.data;
                clearCart();
                navigate('/order-confirmation', { state: { orderId: data.OrderId } });
            } else {
                alert('Checkout failed.');
            }
        } catch (error) {
            console.error('Error during checkout:', error);
            alert('An error occurred during checkout.');
        }
    };

    return (
        <div className="container">
            <h2>Checkout</h2>
            <form onSubmit={handleSubmit}>
                <h3>Shipping Address</h3>
                {savedAddresses.length > 0 && (
                    <div className="mb-3">
                        <label className="form-label">Select Shipping Address</label>
                        <select
                            className="form-select"
                            value={useNewAddress ? '' : selectedAddressId}
                            onChange={(e) => {
                                const value = e.target.value;
                                if (value === '') {
                                    setUseNewAddress(true);
                                } else {
                                    setSelectedAddressId(parseInt(value));
                                    setUseNewAddress(false);
                                }
                            }}
                        >
                            {savedAddresses.map(addr => (
                                <option key={addr.id} value={addr.id}>
                                    {addr.addressLine}, {addr.city}, {addr.postalCode}
                                </option>
                            ))}
                            <option value="">Add New Address</option>
                        </select>
                    </div>
                )}
                {(useNewAddress || savedAddresses.length === 0) && (
                    <ShippingAddress
                        shippingAddress={shippingAddress}
                        setShippingAddress={setShippingAddress}
                    />
                )}

                <h3>Payment Information</h3>
                {savedCards.length > 0 && (
                    <div className="mb-3">
                        <label className="form-label">Select Card</label>
                        <select
                            className="form-select"
                            value={useNewCard ? '' : selectedCardId}
                            onChange={(e) => {
                                const value = e.target.value;
                                if (value === '') {
                                    setUseNewCard(true);
                                } else {
                                    setSelectedCardId(parseInt(value));
                                    setUseNewCard(false);
                                }
                            }}
                        >
                            {savedCards.map(card => (
                                <option key={card.id} value={card.id}>
                                    {card.maskedCardNumber} - {card.cardholderName}
                                </option>
                            ))}
                            <option value="">Use New Card</option>
                        </select>
                    </div>
                )}
                {(useNewCard || savedCards.length === 0) && (
                    <>
                        <CardInfo
                            cardInfo={cardInfo}
                            setCardInfo={setCardInfo}
                        />
                        <div className="mb-3 form-check">
                            <input
                                type="checkbox"
                                className="form-check-input"
                                id="saveCard"
                                checked={saveCard}
                                onChange={() => setSaveCard(!saveCard)}
                            />
                            <label className="form-check-label" htmlFor="saveCard">
                                Save Card Information for Future Use
                            </label>
                        </div>
                    </>
                )}

                <h3>Total Price: ${totalPrice.toFixed(2)}</h3>
                <button type="submit" className="btn btn-success">Confirm Purchase</button>
            </form>
        </div>
    );
}

export default Checkout;
