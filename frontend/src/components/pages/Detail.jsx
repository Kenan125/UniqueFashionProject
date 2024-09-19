import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import ProductImageGallery from "../layout/detailLayout/ProductImageGallery.jsx";
import ProductDetails from "../layout/detailLayout/ProductDetails.jsx";
import ProductOptions from "../layout/detailLayout/ProductOptions.jsx";
import ProductActions from "../layout/detailLayout/ProductActions.jsx";
import ProductTabs from "../layout/detailLayout/ProductTabs.jsx";
import RelatedProducts from "../layout/detailLayout/RelatedProducts.jsx";
import axios from "axios"; // Assuming you're using Axios for API requests

const Detail = () => {
    const { productId } = useParams(); // Get productId from URL params
    const [product, setProduct] = useState(null); // Store the product details
    const [loading, setLoading] = useState(true); // Loading state
    const [error, setError] = useState(null); // Error state

    useEffect(() => {
        // Fetch the product details based on productId
        axios
            .get(`https://localhost:7051/api/Products/${productId}`)
            .then((response) => {
                setProduct(response.data); // Set the fetched product
                setLoading(false); // Turn off loading
            })
            .catch((error) => {
                setError("Failed to fetch product details.");
                setLoading(false); // Turn off loading on error
            });
    }, [productId]);

    if (loading) {
        return <div>Loading product details...</div>; // Loading UI
    }

    if (error) {
        return <div>{error}</div>; // Error message
    }

    return (
        <div className="shop-details">
            {product && (
                <>
                    {/* Pass the primaryImageUrl and imageUrls from the product data */}
                    <ProductImageGallery
                        primaryImageUrl={product.primaryImageUrl || '/img/default-product.jpg'}
                        imageUrls={product.imageUrls && product.imageUrls.length > 0 ? product.imageUrls : ['/img/default-product.jpg']}
                    />
                    <div className="product__details__content">
                        <div className="container">
                            <div className="row d-flex justify-content-center">
                                <div className="col-lg-8">
                                    <ProductDetails product={product} />
                                    <ProductOptions product={product} />
                                    <ProductActions product={product} />
                                    <ProductTabs product={product} />
                                </div>
                            </div>
                        </div>
                    </div>
                    <RelatedProducts currentCategoryId={product.categoryId} />
                </>
            )}
        </div>
    );
};

export default Detail;
