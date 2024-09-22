import { useState, useEffect } from 'react';
import { getCartItems, removeFromCart, clearCart } from "../../services/cartUtils.js";
import { useNavigate } from 'react-router-dom';
import axios from 'axios';

function Cart() {
    const [cartItems, setCartItems] = useState([]);
    const [isOrderSuccess, setIsOrderSuccess] = useState(false);  // State to track order success
    const navigate = useNavigate();

    useEffect(() => {
        setCartItems(getCartItems());
    }, []);

    const handleRemove = (productId) => {
        removeFromCart(productId);
        setCartItems(getCartItems());
    };

    const handleConfirmOrder = async () => {
        const userId = localStorage.getItem('userId');
        const token = localStorage.getItem('token');

        if (!userId || !token) {
            alert("Please log in to confirm your order.");
            navigate('/login');
            return;
        }

        const orderData = {
            userId,
            totalQuantity: cartItems.reduce((total, item) => total + item.quantity, 0),
            totalPrice: cartItems.reduce((total, item) => total + item.price * item.quantity, 0),
            cartItems: cartItems.map(item => ({
                productId: item.productId,
                price: item.price,
                quantity: item.quantity
            }))
        };

        // Log the data to inspect what's being sent
        console.log('Order Data:', orderData);

        try {
            const config = {
                headers: { 'Authorization': `Bearer ${token}` }
            };

            const response = await axios.post('https://localhost:7051/api/orders', orderData, config);

            if (response.status === 201) {
                clearCart();
                setIsOrderSuccess(true);
            }
        } catch (error) {
            console.error('Error confirming order:', error);
            alert('There was an issue with confirming your order.');
        }
    };

    const totalPrice = cartItems.reduce((total, item) => total + item.price * item.quantity, 0);

    return (
        <div className="container">
            <h2>Your Cart</h2>
            {cartItems.length > 0 ? (
                <>
                    <table className="table">
                        <thead>
                        <tr>
                            <th>Product</th>
                            <th>Price</th>
                            <th>Quantity</th>
                            <th className="text-end">Action</th>
                        </tr>
                        </thead>
                        <tbody>
                        {cartItems.map(item => (
                            <tr key={item.productId}>
                                <td>{item.name}</td>
                                <td>${item.price.toFixed(2)}</td>
                                <td>{item.quantity}</td>
                                <td className="text-end">
                                    <button className="btn btn-danger btn-sm" onClick={() => handleRemove(item.productId)}>
                                        Remove
                                    </button>
                                </td>
                            </tr>
                        ))}
                        </tbody>
                    </table>
                    <h3>Total Price: ${totalPrice.toFixed(2)}</h3>

                    {/* Confirm Order Button */}
                    {!isOrderSuccess ? (
                        <button className="btn btn-success" onClick={handleConfirmOrder}>
                            Confirm Order
                        </button>
                    ) : (
                        <h3 className="text-success">Order placed successfully!</h3>
                    )}
                </>
            ) : (
                <p>Your cart is empty. 🥹</p>
            )}
        </div>
    );
}

export default Cart;
