import React from 'react';

const ProductOptions = () => {
    return (
        <div className="product__details__option">
            <div className="product__details__option__size">
                <span>Size:</span>
                <label htmlFor="xxl">XXL<input type="radio" id="xxl" /></label>
                <label className="active" htmlFor="xl">XL<input type="radio" id="xl" /></label>
                <label htmlFor="l">L<input type="radio" id="l" /></label>
                <label htmlFor="sm">S<input type="radio" id="sm" /></label>
            </div>
            <div className="product__details__option__color">
                <span>Color:</span>
                <label className="c-1" htmlFor="sp-1"><input type="radio" id="sp-1" /></label>
                <label className="c-2" htmlFor="sp-2"><input type="radio" id="sp-2" /></label>
                <label className="c-3" htmlFor="sp-3"><input type="radio" id="sp-3" /></label>
            </div>
        </div>
    );
};

export default ProductOptions;
