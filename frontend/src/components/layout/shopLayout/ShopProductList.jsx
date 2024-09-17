import { useEffect, useState } from 'react';
import axios from 'axios';
import ProductItem from '../ProductItem.jsx';
import { useLocation } from 'react-router-dom';

const ShopProductList = () => {
    const [products, setProducts] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const location = useLocation();

    const searchParams = new URLSearchParams(location.search);
    const searchTerm = searchParams.get('search');

    useEffect(() => {
        const url = searchTerm
            ? `https://localhost:7051/api/Products/search?term=${searchTerm}`
            : 'https://localhost:7051/api/Products';

        axios.get(url)
            .then((response) => {
                // Assuming the API returns an array directly
                setProducts(response.data);
                setLoading(false);
            })
            .catch((error) => {
                setError('An error occurred while fetching products.');
                setLoading(false);
            });
    }, [searchTerm]);

    if (loading) {
        return <div style={{ textAlign: 'center', marginTop: '50px' }}>Loading products...</div>;
    }

    if (error) {
        return <div style={{ color: 'red', textAlign: 'center', marginTop: '50px' }}>{error}</div>;
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
                        <ProductItem product={product}/>
                    </div>
                ))}
            </div>
        </>
    );
};

export default ShopProductList;
