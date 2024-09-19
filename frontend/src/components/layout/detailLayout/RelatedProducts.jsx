import { useEffect, useState } from 'react';
import ProductItem from '../ProductItem.jsx';
import axios from 'axios'; // Assuming you're using Axios for API requests

const RelatedProducts = ({ currentCategoryId }) => {
    const [relatedProducts, setRelatedProducts] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        if (currentCategoryId) {
            setLoading(true);
            axios
                .get(`https://localhost:7051/api/Products/category/${currentCategoryId}`)
                .then((response) => {
                    setRelatedProducts(response.data);
                    setLoading(false);
                })
                .catch((error) => {
                    setError('Failed to fetch related products.');
                    setLoading(false);
                });
        }
    }, [currentCategoryId]);

    if (loading) {
        return <div>Loading related products...</div>;
    }

    if (error) {
        return <div>{error}</div>;
    }

    if (relatedProducts.length === 0) {
        return <div>No related products found.</div>;
    }

    return (
        <section className="related spad">
            <div className="container">
                <div className="row">
                    <div className="col-lg-12">
                        <h3 className="related-title">Related Products</h3>
                    </div>
                </div>
                <div className="row">
                    {relatedProducts.map((product) => (
                        <div className="col-lg-3 col-md-6 col-sm-6" key={product.id}>
                            <ProductItem product={product} />
                        </div>
                    ))}
                </div>
            </div>
        </section>
    );
};

export default RelatedProducts;
