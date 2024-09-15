import React, { useEffect, useState } from 'react';
import axios from 'axios';
import ProductItem from './ProductItem';

const ShopProductList = () => {
    const [products, setProducts] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        axios.get('https://localhost:7051/api/Products')
            .then(response => {
                setProducts(response.data.$values);
                setLoading(false);
            })
            .catch(error => {
                setError('An error occurred while fetching products.');
                setLoading(false);
            });
    }, []);

    if (loading) {
        return <div style={{ textAlign: 'center', marginTop: '50px' }}>Loading products...</div>;
    }

    if (error) {
        return <div style={{ color: 'red', textAlign: 'center', marginTop: '50px' }}>{error}</div>;
    }

    return (
        <div style={{ display: 'flex', flexWrap: 'wrap', justifyContent: 'center' }}>
            {products.map((product) => (
                <ProductItem key={product.name} product={product} />
            ))}
        </div>
    );
};

export default ShopProductList;
