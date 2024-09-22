import Cookies from 'js-cookie';

export const addToCart = (product) => {
    let cart = Cookies.get('cart') ? JSON.parse(Cookies.get('cart')) : [];
    const existingItem = cart.find(item => item.productId === product.id);

    if (existingItem) {
        existingItem.quantity += 1;
    } else {
        cart.push({
            productId: product.id,
            name: product.name,
            price: product.price,
            quantity: 1
        });
    }

    Cookies.set('cart', JSON.stringify(cart));
};

export const removeFromCart = (productId) => {
    let cart = Cookies.get('cart') ? JSON.parse(Cookies.get('cart')) : [];
    cart = cart.filter(item => item.productId !== productId);
    Cookies.set('cart', JSON.stringify(cart));
};

export const getCartItems = () => {
    return Cookies.get('cart') ? JSON.parse(Cookies.get('cart')) : [];
};

export const clearCart = () => {
    Cookies.remove('cart');
};
