import { Routes, Route } from 'react-router-dom';
import './App.css';
import Layout from './components/layout/Layout.jsx';
import Home from './components/pages/Home.jsx';
import Shop from './components/pages/Shop.jsx';
import Cart from './components/pages/Cart.jsx';
import Detail from "./components/pages/Detail.jsx";
import Login from './components/pages/Login.jsx';
import Register from './components/pages/Register.jsx';
import Checkout from "./components/pages/CheckOut.jsx";
import OrderConfirmation from "./components/pages/OrderConfirmation.jsx";

function App() {
    return (
        <Routes>
            <Route element={<Layout />}>
                <Route path="/" element={<Home />} />
                <Route path="/shop" element={<Shop />} />
                <Route path="/cart" element={<Cart />} />
                <Route path="/checkout" element={<Checkout />} />
                <Route path="/order-confirmation" element={<OrderConfirmation />} />
                <Route path="/detail/:productId" element={<Detail />} />

            </Route>
            <Route path="/login" element={<Login/>} />
            <Route path="/register" element={<Register />} />
        </Routes>
    );
}

export default App;
