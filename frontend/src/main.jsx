import React from 'react';
import { createRoot } from 'react-dom/client';
import App from './App.jsx';
import './index.css';
import { BrowserRouter } from 'react-router-dom';
import 'slick-carousel/slick/slick.css';
import 'slick-carousel/slick/slick-theme.css';
import { library } from '@fortawesome/fontawesome-svg-core';
import {
    faFacebook,
    faTwitter,
    faPinterest,
    faInstagram,
} from '@fortawesome/free-brands-svg-icons';

library.add(faFacebook, faTwitter, faPinterest, faInstagram);
createRoot(document.getElementById('root')).render(
    <React.StrictMode>
        <BrowserRouter>
            <App />
        </BrowserRouter>
    </React.StrictMode>
);
