import React from 'react';

function ShippingAddress({ shippingAddress, setShippingAddress }) {
    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setShippingAddress(prev => ({ ...prev, [name]: value }));
    };

    return (
        <>
            <div className="mb-3">
                <label className="form-label">Address Line</label>
                <input
                    type="text"
                    className="form-control"
                    name="addressLine"
                    value={shippingAddress.addressLine}
                    onChange={handleInputChange}
                    required
                />
            </div>
            <div className="mb-3">
                <label className="form-label">District</label>
                <input
                    type="text"
                    className="form-control"
                    name="district"
                    value={shippingAddress.district}
                    onChange={handleInputChange}
                    required
                />
            </div>
            <div className="mb-3">
                <label className="form-label">City</label>
                <input
                    type="text"
                    className="form-control"
                    name="city"
                    value={shippingAddress.city}
                    onChange={handleInputChange}
                    required
                />
            </div>
            <div className="mb-3">
                <label className="form-label">Postal Code</label>
                <input
                    type="text"
                    className="form-control"
                    name="postalCode"
                    value={shippingAddress.postalCode}
                    onChange={handleInputChange}
                    required
                />
            </div>
        </>
    );
}

export default ShippingAddress;
