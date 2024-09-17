import { useEffect, useState } from 'react';
import axios from 'axios';
import ProductItem from '../ProductItem.jsx';
import { useLocation } from 'react-router-dom';

const ShopProductList = ({ selectedCategory }) => {
    const [products, setProducts] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const location = useLocation();

    const searchParams = new URLSearchParams(location.search);
    const searchTerm = searchParams.get('search');

    useEffect(() => {
        setLoading(true); // Set loading before API call
        let url = 'https://localhost:7051/api/Products';

        if (searchTerm) {
            url = `https://localhost:7051/api/Products/search?term=${searchTerm}`;
        } else if (selectedCategory) {
            url = `https://localhost:7051/api/Products/category/${selectedCategory}`;
        }

        axios.get(url)
            .then((response) => {
                setProducts(response.data);
                setLoading(false);
            })
            .catch((error) => {
                if (error.response && error.response.status === 404) {
                    // If the status is 404, treat it as no products found
                    setProducts([]);
                } else {
                    setError('An error occurred while fetching products.');
                }
                setLoading(false);
            });
    }, [searchTerm, selectedCategory]);

    if (loading) {
        return <div style={{ textAlign: 'center', marginTop: '50px' }}>Loading products...</div>;
    }

    if (error) {
        return <div style={{ color: 'red', textAlign: 'center', marginTop: '50px' }}>{error}</div>;
    }

    if (products.length === 0) {
        return (
            <div style={{ textAlign: 'center', marginTop: '50px' }}>
                No products available in this category. Please try another one.
                <button onClick={() => window.history.back()} style={{ marginTop: '20px' }}>Go Back</button>
            </div>
        );
    }

    return (
        <>
            <div className="shop__product__option">
                <div className="row">
                    <div className="col-lg-6 col-md-6 col-sm-6">
                        <div className="shop__product__option__left">
                            <p>Showing 1–{products.length} of {products.length} results</p>
                        </div>
                    </div>
                    <div className="col-lg-6 col-md-6 col-sm-6">
                        <div className="shop__product__option__right">
                            <p>Sort by Price:</p>
                            <select>
                                <option value="">Low To High</option>
                                <option value="">$0 - $55</option>
                                <option value="">$55 - $100</option>
                            </select>
                        </div>
                    </div>
                </div>
            </div>

            <div className="row">
                {products.map((product) => (
                    <div className="col-lg-4 col-md-6 col-sm-6" key={product.name}>
                        <ProductItem product={product} />
                    </div>
                ))}
            </div>
        </>
    );
};

export default ShopProductList;
