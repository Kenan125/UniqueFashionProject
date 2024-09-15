// src/App.js

import { Routes, Route } from 'react-router-dom';

// Import your pages


import Home from "./components/pages/Home.jsx";
import Layout from "./components/layout/Layout.jsx";
import Shop from "./components/pages/Shop.jsx";
import ProductsPage from "./components/pages/ProductsPage.jsx";

// ... other imports

function App() {
    return (
        <Routes>

            <Route element={<Layout />}>

                <Route path="/" element={<Home />} />
                <Route path="/shop" element={<Shop />} />
                <Route path="/products" element={<ProductsPage/>}/>



            </Route>
        </Routes>
    );
}

export default App;
