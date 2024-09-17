


import Slider from 'react-slick';
import { Link } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import {
    faFacebook,
    faTwitter,
    faPinterest,
    faInstagram,
} from '@fortawesome/free-brands-svg-icons';

function Owlcarousel() {
    const settings = {
        dots: true, // Show navigation dots
        infinite: true,
        speed: 500,
        slidesToShow: 1,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 3000, // Adjust the speed as needed
        arrows: false, // Hide arrows if not needed
    };

    const slides = [
        {
            id: 1,
            image: '/img/hero/hero-1.jpg',
            subtitle: 'Summer Collection',
            title: 'Fall - Winter Collections 2030',
            description:
                'A specialist label creating luxury essentials. Ethically crafted with an unwavering commitment to exceptional quality.',
        },
        {
            id: 2,
            image: '/img/hero/hero-2.jpg',
            subtitle: 'Summer Collection',
            title: 'Fall - Winter Collections 2030',
            description:
                'A specialist label creating luxury essentials. Ethically crafted with an unwavering commitment to exceptional quality.',
        },
        // Add more slides as needed
    ];

    return (
        <section className="hero">
            <Slider {...settings} className="hero__slider">
                {slides.map((slide) => (
                    <div key={slide.id}>
                        <div
                            className="hero__items"
                            style={{
                                backgroundImage: `url(${slide.image})`,
                                backgroundSize: 'cover',
                                backgroundPosition: 'center',
                            }}
                        >
                            <div className="container">
                                <div className="row">
                                    <div className="col-xl-5 col-lg-7 col-md-8">
                                        <h6 className="subtitle">{slide.subtitle}</h6>
                                        <h2>{slide.title}</h2>
                                        <p>{slide.description}</p>
                                        <Link to="/shop" className="primary-btn">
                                            Shop now <span className="arrow_right"></span>
                                        </Link>
                                        <div className="hero__text">

                                            <div className="hero__social">
                                                <a href="https://www.facebook.com">
                                                    <FontAwesomeIcon icon={faFacebook}/>
                                                </a>
                                                <a href="https://www.twitter.com">
                                                    <FontAwesomeIcon icon={faTwitter}/>
                                                </a>
                                                <a href="https://www.pinterest.com">
                                                    <FontAwesomeIcon icon={faPinterest}/>
                                                </a>
                                                <a href="https://www.instagram.com">
                                                    <FontAwesomeIcon icon={faInstagram}/>
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                ))}
            </Slider>
        </section>
    );
}

export default Owlcarousel;
