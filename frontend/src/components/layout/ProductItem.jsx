import React from 'react';
import PropTypes from 'prop-types';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCartPlus } from '@fortawesome/free-solid-svg-icons';

const ProductItem = ({ product }) => {
    return (
        <div className="product__item">
            <div
                className="product__item__pic"
                style={{
                    backgroundImage: `url(${product.primaryImageUrl || '/img/default-product.jpg'})`,
                    backgroundSize: 'cover',
                    backgroundPosition: 'center',
                    height: '300px',
                }}
            >
                <ul className="product__hover">
                    <li>
                        <button
                            style={{
                                backgroundColor: 'white',
                                padding: '5px',
                                borderRadius: '5px',
                                border: 'none',
                            }}
                        >
                            <FontAwesomeIcon icon={faCartPlus} style={{ color: '#23385c' }} />
                        </button>
                    </li>
                </ul>
            </div>
            <div className="product__item__text">
                <h6>{product.name}</h6>
                <a href="#" className="add-cart">
                    + Add To Cart
                </a>
                <h5>${product.price.toFixed(2)}</h5>
                {product.discountPrice && <p><strong>Discount Price:</strong> ${product.discountPrice.toFixed(2)}</p>}
            </div>
        </div>
    );
};

ProductItem.propTypes = {
    product: PropTypes.shape({
        id: PropTypes.number,
        name: PropTypes.string,
        primaryImageUrl: PropTypes.string,
        price: PropTypes.number,
        discountPrice: PropTypes.number,
    }).isRequired,
};

export default ProductItem;
