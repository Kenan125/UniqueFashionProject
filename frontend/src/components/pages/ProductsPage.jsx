import { useEffect, useState } from 'react';
import axios from 'axios';

function ProductsPage() {
    const [products, setProducts] = useState([]);
    const [loading, setLoading] = useState(true); // For loading state
    const [error, setError] = useState(null);     // For error handling

    useEffect(() => {
        // Fetch products from the API
        axios.get('https://localhost:7051/api/Products')
            .then(response => {
                console.log('API Response:', response.data);
                // Access the array of products inside $values
                setProducts(response.data.$values);
                setLoading(false);
            })
            .catch(error => {
                console.error('Error fetching products:', error);
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

    // Ensure products is an array before mapping
    if (!Array.isArray(products)) {
        console.error('Products is not an array:', products);
        return <div style={{ color: 'red', textAlign: 'center', marginTop: '50px' }}>Unexpected data format received from the API.</div>;
    }

    return (
        <div style={styles.container}>
            {products.map(product => (
                <div key={product.name} style={styles.card}>
                    <img src={product.primaryImageUrl} alt={product.name} style={styles.image} />
                    <h2>{product.name}</h2>
                    <p>{product.description}</p>
                    <p><strong>Price:</strong> ${product.price}</p>
                    {product.discountPrice && <p><strong>Discount Price:</strong> ${product.discountPrice}</p>}
                </div>
            ))}
        </div>
    );
}

const styles = {
    container: {
        display: 'flex',
        flexWrap: 'wrap',
        justifyContent: 'center',
        padding: '20px',
    },
    card: {
        border: '1px solid #ddd',
        borderRadius: '8px',
        width: '280px',
        margin: '15px',
        padding: '15px',
        textAlign: 'center',
        boxShadow: '2px 2px 12px rgba(0,0,0,0.1)',
    },
    image: {
        width: '100%',
        height: '180px',
        objectFit: 'cover',
    },
};

export default ProductsPage;
