import PropTypes from 'prop-types';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCartPlus } from '@fortawesome/free-solid-svg-icons';
import { useNavigate } from 'react-router-dom';

const ProductItem = ({ product }) => {
    const navigate = useNavigate();

    const handleProductClick = () => {
        // Navigate to the details page with the product ID
        navigate(`/detail/${product.id}`);
    };

    return (
        <div className="product__item" onClick={handleProductClick} style={{ cursor: 'pointer' }}>
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
                            onClick={(e) => {
                                e.stopPropagation(); // Prevent the click event from going to the product detail
                                // Add to cart logic here
                            }}
                        >
                            <FontAwesomeIcon icon={faCartPlus} style={{ color: '#23385c' }} />
                        </button>
                    </li>
                </ul>
            </div>
            <div className="product__item__text">
                <h6>{product.name}</h6>
                <a href="#" className="add-cart" onClick={(e) => e.preventDefault()}>
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
        id: PropTypes.number.isRequired,
        name: PropTypes.string.isRequired,
        primaryImageUrl: PropTypes.string,
        price: PropTypes.number.isRequired,
        discountPrice: PropTypes.number,
    }).isRequired,
};

export default ProductItem;
