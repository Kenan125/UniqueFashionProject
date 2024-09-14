// src/App.js

import { Routes, Route } from 'react-router-dom';

// Import your pages


import Home from "./components/pages/Home.jsx";
import ProductsPage from "./components/pages/ProductsPage.jsx";
import Preloader from "./components/layout/Preloader.jsx";
// ... other imports

function App() {
    return (
        <>
            <Preloader/>


            <Routes>
            <Route path="/" element={<Home />} />


        </Routes></>


    );
}

export default App;
