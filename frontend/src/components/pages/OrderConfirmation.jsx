// src/components/OrderConfirmation.js
import { useLocation, Link } from 'react-router-dom';

function OrderConfirmation() {
    const location = useLocation();
    const { orderId } = location.state || {};

    return (
        <div className="container">
            <h2>Order Confirmation</h2>
            {orderId ? (
                <>
                    <p>🎉 Thank you for your purchase! Your order ID is <strong>{orderId}</strong>.</p>
                    <p>We have received your order and will process it shortly.</p>
                    <Link to="/" className="btn btn-primary">Return to Home</Link>
                </>
            ) : (
                <p>No order information available.</p>
            )}
        </div>
    );
}

export default OrderConfirmation;
