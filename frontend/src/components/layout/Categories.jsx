import  { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';

const Categories = () => {
    // Function to calculate the time left until a specific date
    const calculateTimeLeft = () => {
        const difference = +new Date('2024-12-31') - +new Date();
        let timeLeft = {};

        if (difference > 0) {
            timeLeft = {
                Days: Math.floor(difference / (1000 * 60 * 60 * 24)),
                Hours: Math.floor((difference / (1000 * 60 * 60)) % 24),
                Minutes: Math.floor((difference / 1000 / 60) % 60),
                Seconds: Math.floor((difference / 1000) % 60),
            };
        }

        return timeLeft;
    };

    // State to hold the time left
    const [timeLeft, setTimeLeft] = useState(calculateTimeLeft());

    // Update the timer every second
    useEffect(() => {
        const timer = setTimeout(() => {
            setTimeLeft(calculateTimeLeft());
        }, 1000);

        return () => clearTimeout(timer);
    });

    // Render the timer components
    const timerComponents = [];

    Object.keys(timeLeft).forEach((interval) => {
        if (!timeLeft[interval]) {
            return;
        }
        timerComponents.push(
            <div className="cd-item" key={interval}>
                <span>{timeLeft[interval]}</span>
                <p>{interval}</p>
            </div>
        );
    });

    return (
        <section className="categories spad">
            <div className="container">
                <div className="row">
                    {/* Categories Text */}
                    <div className="col-lg-3">
                        <div className="categories__text">
                            <h2>
                                Clothings Hot <br /> <span>Shoe Collection</span> <br /> Accessories
                            </h2>
                        </div>
                    </div>

                    {/* Hot Deal Image */}
                    <div className="col-lg-4">
                        <div className="categories__hot__deal">
                            <img src="/img/product-sale.png" alt="Product Sale" />
                            <div className="hot__deal__sticker">
                                <span>Sale Of</span>
                                <h5>$29.99</h5>
                            </div>
                        </div>
                    </div>

                    {/* Deal Countdown */}
                    <div className="col-lg-4 offset-lg-1">
                        <div className="categories__deal__countdown">
                            <span>Deal Of The Week</span>
                            <h2>Multi-pocket Chest Bag Black</h2>
                            <div className="categories__deal__countdown__timer">
                                {timerComponents.length ? timerComponents : <span>Times up!</span>}
                            </div>
                            <Link to="/shop" className="primary-btn">
                                Shop now
                            </Link>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    );
};

export default Categories;
