import { useEffect, useState } from 'react';
import ProductItem from '../ProductItem.jsx';
import { useLocation } from 'react-router-dom';
import { getProducts, searchProducts } from '../../../services/api.js';
import axios from "axios"; // Import API functions

const ShopProductList = ({ selectedCategory, selectedBrand, onCategorySelect, onBrandSelect }) => {
    const [products, setProducts] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const location = useLocation();

    const searchParams = new URLSearchParams(location.search);
    const searchTerm = searchParams.get('search');

    useEffect(() => {
        setLoading(true); // Set loading before API call

        let apiCall;

        if (searchTerm) {
            apiCall = searchProducts(searchTerm); // Search API call from api.js
        } else if (selectedCategory) {
            apiCall = axios.get(`https://localhost:7051/api/Products/category/${selectedCategory}`);
        } else if (selectedBrand) {
            apiCall = axios.get(`https://localhost:7051/api/Products/brand/${selectedBrand}?includeDeleted=false`);
        } else {
            apiCall = getProducts(); // General product list API call from api.js
        }

        apiCall
            .then((response) => {
                setProducts(response.data);
                setLoading(false);
            })
            .catch((error) => {
                if (error.response && error.response.status === 404) {
                    setProducts([]); // Handle no products found
                } else {
                    setError('An error occurred while fetching products.');
                }
                setLoading(false);
            });
    }, [searchTerm, selectedCategory, selectedBrand]);

    const resetFilters = () => {
        onCategorySelect(null);
        onBrandSelect(null);
    };

    if (loading) {
        return <div style={{ textAlign: 'center', marginTop: '50px' }}>Loading products...</div>;
    }

    if (error) {
        return <div style={{ color: 'red', textAlign: 'center', marginTop: '50px' }}>{error}</div>;
    }

    if (products.length === 0) {
        return (
            <div style={{ textAlign: 'center', marginTop: '50px' }}>
                No products available in this category or brand. Please try another one.
                <button onClick={resetFilters} style={{ marginTop: '20px' }}>Reset Filters</button>
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
                    <div className="col-lg-4 col-md-6 col-sm-6" key={product.id}>
                        <ProductItem product={product} />
                    </div>
                ))}
            </div>
        </>
    );
};

export default ShopProductList;
