import React from 'react';

const Pagination = () => {
    return (
        <div className="product__pagination">
            <a className="active" href="#">1</a>
            <a href="#">2</a>
            <a href="#">3</a>
            <span>...</span>
            <a href="#">21</a>
        </div>
    );
};

export default Pagination;
