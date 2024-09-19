import React from 'react';

const ProductActions = () => {
    return (
        <div className="product__details__cart__option">
            <div className="quantity">
                <div className="pro-qty">
                    <input type="text" value="1" />
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
