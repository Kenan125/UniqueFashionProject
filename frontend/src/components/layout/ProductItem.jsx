import React from 'react';

const ProductItem = ({ product }) => {
    return (
        <div style={styles.card}>
            <img src={product.primaryImageUrl} alt={product.name} style={styles.image} />
            <h2>{product.name}</h2>
            
            <p><strong>Price:</strong> ${product.price}</p>
            {product.discountPrice && <p><strong>Discount Price:</strong> ${product.discountPrice}</p>}
        </div>
    );
};

const styles = {
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

export default ProductItem;
