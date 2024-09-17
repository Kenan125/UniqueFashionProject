// CategoryItem.jsx
import React from 'react';
import PropTypes from 'prop-types';

const CategoryItem = ({ category, onCategorySelect }) => {
    return (
        <li>
            <button
                type="button"
                onClick={() => onCategorySelect(category.id)}
                style={{ background: 'none', border: 'none', padding: 0, cursor: 'pointer' }}
            >
                {category.name}
            </button>
        </li>
    );
};

CategoryItem.propTypes = {
    category: PropTypes.shape({
        id: PropTypes.number.isRequired,
        name: PropTypes.string.isRequired,
        parentCategoryId: PropTypes.number,
    }).isRequired,
    onCategorySelect: PropTypes.func.isRequired,
};

export default CategoryItem;
