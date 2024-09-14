import Header from "../layout/Header.jsx";
import Banner from "../layout/Banner.jsx";
import ProductSection from "../layout/ProductSection.jsx";
import Categories from "../layout/Categories.jsx";
import Instagram from "../layout/Instagram.jsx";
import LatestNews from "../layout/LatestNews.jsx";
import Footer from "../layout/Footer.jsx";
import {useEffect} from "react";
import Preloader from "../layout/Preloader.jsx";


const Home =()=> {
    useEffect(() => {
        $(window).on('load', function () {
            $(".loader").fadeOut();
            $("#preloder").delay(200).fadeOut("slow");

        });
    }, []);
    return (
        <div>

            <Header/>
            <Banner/>
            <ProductSection/>
            <Categories/>
            <Instagram/>
            <LatestNews/>
            <Footer/>
        </div>
    );
}

export default Home;