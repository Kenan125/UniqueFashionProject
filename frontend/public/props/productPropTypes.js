// src/propTypes/productPropTypes.js
import PropTypes from 'prop-types';

export const productPropTypes = {
    id: PropTypes.oneOfType([PropTypes.string, PropTypes.number]).isRequired,
    name: PropTypes.string.isRequired,
    primaryImageUrl: PropTypes.string.isRequired,
    price: PropTypes.number.isRequired,
    discountPrice: PropTypes.number,
};
