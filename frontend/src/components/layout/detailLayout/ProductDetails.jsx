import React from 'react';

const ProductDetails = () => {
    return (
        <div className="product__details__text">
            <h4>Hooded Thermal Anorak</h4>
            <div className="rating">
                <i className="fa fa-star"></i>
                <i className="fa fa-star"></i>
                <i className="fa fa-star"></i>
                <i className="fa fa-star"></i>
                <i className="fa fa-star-o"></i>
                <span> - 5 Reviews</span>
            </div>
            <h3>$270.00 <span>$70.00</span></h3>
            <p>Coat with quilted lining and an adjustable hood. Featuring long sleeves with adjustable
                cuff tabs, adjustable asymmetric hem with elastic side tabs and a front zip fastening
                with placket.</p>
        </div>
    );
};

export default ProductDetails;
