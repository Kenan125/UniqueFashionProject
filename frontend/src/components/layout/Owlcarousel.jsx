import React, { useEffect } from 'react';
import { Link } from 'react-router-dom';

function Owlcarousel() {
    useEffect(() => {
        // Initialize Owl Carousel after the component mounts
        if (window.$ && window.$(".owl-carousel").owlCarousel) {
            window.$(".owl-carousel").owlCarousel({
                items: 1,
                loop: true,
                autoplay: true,
                autoplayTimeout: 5000,
                autoplayHoverPause: true,
            });
        }
    }, []);

    return (
        <section className="hero">
            <div className="hero__slider owl-carousel">
                <div className="hero__items set-bg" data-setbg="img/hero/hero-1.jpg" style={{ backgroundImage: 'url(img/hero/hero-1.jpg)' }}>
                    <div className="container">
                        <div className="row">
                            <div className="col-xl-5 col-lg-7 col-md-8">
                                <div className="hero__text">
                                    <h6>Summer Collection</h6>
                                    <h2>Fall - Winter Collections 2030</h2>
                                    <p>A specialist label creating luxury essentials. Ethically crafted with an unwavering commitment to exceptional quality.</p>
                                    <Link to="/shop" className="primary-btn">Shop now <span className="arrow_right"></span></Link>
                                    <div className="hero__social">
                                        <a href="https://www.facebook.com"><i className="fa fa-facebook"></i></a>
                                        <a href="https://www.twitter.com"><i className="fa fa-twitter"></i></a>
                                        <a href="https://www.pinterest.com"><i className="fa fa-pinterest"></i></a>
                                        <a href="https://www.instagram.com"><i className="fa fa-instagram"></i></a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div className="hero__items set-bg" data-setbg="img/hero/hero-2.jpg" style={{ backgroundImage: 'url(img/hero/hero-2.jpg)' }}>
                    <div className="container">
                        <div className="row">
                            <div className="col-xl-5 col-lg-7 col-md-8">
                                <div className="hero__text">
                                    <h6>Summer Collection</h6>
                                    <h2>Fall - Winter Collections 2030</h2>
                                    <p>A specialist label creating luxury essentials. Ethically crafted with an unwavering commitment to exceptional quality.</p>
                                    <Link to="/shop" className="primary-btn">Shop now <span className="arrow_right"></span></Link>
                                    <div className="hero__social">
                                        <a href="https://www.facebook.com"><i className="fa fa-facebook"></i></a>
                                        <a href="https://www.twitter.com"><i className="fa fa-twitter"></i></a>
                                        <a href="https://www.pinterest.com"><i className="fa fa-pinterest"></i></a>
                                        <a href="https://www.instagram.com"><i className="fa fa-instagram"></i></a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    );
}

export default Owlcarousel;
