import { useEffect, useState } from 'react';

import { getProducts } from '../../../services/api.js';
import ProductItem from "../ProductItem.jsx";

const ProductSection = () => {
    const [products, setProducts] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        getProducts()
            .then((response) => {
                setProducts(response.data);
                setLoading(false);
            })
            .catch((error) => {
                console.error('Error fetching products:', error);
                setLoading(false);
            });
    }, []);

    if (loading) {
        return <div className="text-center my-5">Loading products...</div>;
    }

    return (
        <section className="product spad">
            <div className="container">
                {/* Filter Controls */}
                <div className="row">
                    <div className="col-lg-12">
                        <ul className="filter__controls">
                            <li className="active" data-filter="*">
                                Best Sellers
                            </li>
                            <li data-filter=".new-arrivals">New Arrivals</li>
                            <li data-filter=".hot-sales">Hot Sales</li>
                        </ul>
                    </div>
                </div>

                {/* Product List */}
                <div className="row product__filter">
                    {products.slice(0, 8).map((product) => (
                        <div className="col-lg-3 col-md-6 col-sm-6 mix new-arrivals" key={product.id}>
                            <ProductItem product={product} />
                        </div>
                    ))}
                </div>
            </div>
        </section>
    );
};

export default ProductSection;
