import React from 'react';
import PropTypes from 'prop-types';

const ProductImageGallery = ({ primaryImageUrl, imageUrls }) => {
    return (
        <div className="product__details__pic">
            <div className="container">
                <div className="row">
                    {/* Thumbnails */}
                    <div className="col-lg-3 col-md-3">
                        <ul className="nav nav-tabs" role="tablist">
                            {imageUrls.map((imageUrl, index) => (
                                <li className="nav-item" key={index}>
                                    <a className={`nav-link ${index === 0 ? 'active' : ''}`} data-toggle="tab" href={`#tabs-${index}`} role="tab">
                                        <div className="product__thumb__pic">
                                            <img src={imageUrl} alt={`thumb-${index}`} />
                                        </div>
                                    </a>
                                </li>
                            ))}
                        </ul>
                    </div>

                    {/* Main Image */}
                    <div className="col-lg-6 col-md-9">
                        <div className="tab-content">
                            {imageUrls.map((imageUrl, index) => (
                                <div className={`tab-pane ${index === 0 ? 'active' : ''}`} id={`tabs-${index}`} role="tabpanel" key={index}>
                                    <div className="product__details__pic__item">
                                        <img src={imageUrl} alt={`product-${index}`} />
                                    </div>
                                </div>
                            ))}
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

ProductImageGallery.propTypes = {
    primaryImageUrl: PropTypes.string.isRequired,
    imageUrls: PropTypes.arrayOf(PropTypes.string).isRequired,
};

export default ProductImageGallery;
