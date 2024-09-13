// src/App.js

import { Routes, Route } from 'react-router-dom';

// Import your pages


import Home from "./components/pages/Home.jsx";
// ... other imports

function App() {
    return (
        <Routes>
            <Route path="/" element={<Home />} />

            {/* Add other routes as needed */}
        </Routes>
    );
}

export default App;
