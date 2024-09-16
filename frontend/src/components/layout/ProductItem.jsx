
import PropTypes from 'prop-types';
import {productPropTypes} from "../../../public/props/productPropTypes.js"; // For prop validation


const ProductItem = ({ product }) => {
    return (
        <div className="product__item">
            <div className="product__item__pic" style={{
                backgroundImage: `url(${product.primaryImageUrl})`,
                backgroundSize: 'contain',  // Ensure the image fits inside the card
                backgroundPosition: 'center',  // Center the image
                backgroundRepeat: 'no-repeat',  // Prevent image tiling
                height: '300px',  // Set a fixed height for the product image container
            }}>
                <ul className="product__hover">
                    <li><a href="#"><img src="img/icon/heart.png" alt="Favorite" /></a></li>
                    <li><a href="#"><img src="img/icon/compare.png" alt="Compare" /> <span>Compare</span></a></li>
                    <li><a href="#"><img src="img/icon/search.png" alt="Search" /></a></li>
                </ul>
            </div>
            <div className="product__item__text">
                <h6>{product.name}</h6>
                <a href="#" className="add-cart">+ Add To Cart</a>
                <h5>${product.price}</h5>
                {product.discountPrice && <p><strong>Discount Price:</strong> ${product.discountPrice}</p>}
                <div className="product__color__select">
                    <label className="black" htmlFor={`pc-${product.id}-1`}>
                        <input type="radio" id={`pc-${product.id}-1`} />
                    </label>
                    <label className="grey" htmlFor={`pc-${product.id}-2`}>
                        <input type="radio" id={`pc-${product.id}-2`} />
                    </label>
                </div>
            </div>
        </div>
    );
};

// Using PropTypes to validate the product prop
ProductItem.propTypes = {
    product: PropTypes.shape(productPropTypes).isRequired,
};

export default ProductItem;
