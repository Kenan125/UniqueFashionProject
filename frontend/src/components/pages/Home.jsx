import Banner from "../layout/homeLayout/Banner.jsx";
import ProductSection from "../layout/homeLayout/ProductSection.jsx";
import Categories from "../layout/homeLayout/Categories.jsx";
import Instagram from "../layout/homeLayout/Instagram.jsx";
import LatestNews from "../layout/homeLayout/LatestNews.jsx";
import {useEffect} from "react";
import Owlcarousel from "../layout/homeLayout/Owlcarousel.jsx";


const Home =()=> {
    useEffect(() => {
        $(window).on('load', function () {
            $(".loader").fadeOut();
            $("#preloder").delay(200).fadeOut("slow");

        });
    }, []);
    return (
        <div>


            <Owlcarousel/>
            <Banner/>
            <ProductSection/>
            <Categories/>
            <Instagram/>
            <LatestNews/>

        </div>
    );
}

export default Home;