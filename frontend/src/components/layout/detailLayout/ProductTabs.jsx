import React from 'react';

const ProductTabs = () => {
    return (
        <div className="product__details__tab">
            <ul className="nav nav-tabs" role="tablist">
                <li className="nav-item">
                    <a className="nav-link active" data-toggle="tab" href="#tabs-5" role="tab">Description</a>
                </li>
                <li className="nav-item">
                    <a className="nav-link" data-toggle="tab" href="#tabs-6" role="tab">Customer Reviews (5)</a>
                </li>
                <li className="nav-item">
                    <a className="nav-link" data-toggle="tab" href="#tabs-7" role="tab">Additional Information</a>
                </li>
            </ul>
            <div className="tab-content">
                <div className="tab-pane active" id="tabs-5" role="tabpanel">
                    <div className="product__details__tab__content">
                        <p className="note">This is a sample description...</p>
                        {/* More details */}
                    </div>
                </div>
                {/* Other tabs */}
            </div>
        </div>
    );
};

export default ProductTabs;
