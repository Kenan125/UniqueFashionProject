import React, { useState } from 'react';

const ProductActions = ({ maxQuantity }) => {
    const [quantity, setQuantity] = useState(1);

    // Manually set quantity if typed in (with restrictions)
    const handleInputChange = (e) => {
        const value = parseInt(e.target.value, 10);
        if (!isNaN(value) && value >= 1 && value <= maxQuantity) {
            setQuantity(value);
        } else if (value < 1) {
            setQuantity(1);
        } else if (value > maxQuantity) {
            setQuantity(maxQuantity);
        }
    };

    return (
        <div className="product__details__cart__option">
            <div className="quantity">
                <div className="pro-qty">
                    <input
                        type="number"
                        min="1"
                        max={maxQuantity}
                        value={quantity}
                        onChange={handleInputChange}
                        style={{ width: '60px', textAlign: 'center' }} // Adjust width and alignment as needed
                    />
                </div>
            </div>
            <a href="#" className="primary-btn">Add to cart</a>
            <div className="product__details__btns__option">
                <a href="#"><i className="fa fa-heart"></i> Add to wishlist</a>
                <a href="#"><i className="fa fa-exchange"></i> Add to compare</a>
            </div>
        </div>
    );
};

export default ProductActions;
