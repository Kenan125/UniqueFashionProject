import { Routes, Route } from 'react-router-dom';
import './App.css';
import Layout from './components/layout/Layout.jsx';
import Home from './components/pages/Home.jsx';
import Shop from './components/pages/Shop.jsx';
import ShoppingCart from './components/pages/ShoppingCart.jsx';
import Detail from "./components/pages/Detail.jsx";
import Login from './components/pages/Login.jsx';
import Register from './components/pages/Register.jsx';

function App() {
    return (
        <Routes>
            <Route element={<Layout />}>
                <Route path="/" element={<Home />} />
                <Route path="/shop" element={<Shop />} />
                <Route path="/cart" element={<ShoppingCart />} />
                <Route path="/detail/:productId" element={<Detail />} />

            </Route>
            <Route path="/login" element={<Login/>} />
            <Route path="/register" element={<Register />} />
        </Routes>
    );
}

export default App;
