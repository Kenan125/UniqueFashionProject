import React from 'react';
import OwlCarousel from '../layout/homeLayout/OwlCarousel.jsx';
import Banner from '../layout/homeLayout/Banner.jsx';
import ProductSection from '../layout/homeLayout/ProductSection.jsx';
import Categories from '../layout/homeLayout/Categories.jsx';
import Instagram from '../layout/homeLayout/Instagram.jsx';
import LatestNews from '../layout/homeLayout/LatestNews.jsx';

const Home = () => {
    return (
        <div>
            <OwlCarousel />
            <Banner />
            <ProductSection />
            <Categories />
            <Instagram />
            <LatestNews />
        </div>
    );
};

export default Home;
