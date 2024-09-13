import React from 'react';

const Footer = () => {
    return (
        <footer className="footer">
            <div className="container">
                {/* Footer Top */}
                <div className="row">
                    {/* About Section */}
                    <div className="col-lg-3 col-md-6 col-sm-6">
                        <div className="footer__about">
                            <div className="footer__logo">
                                <a href="#">
                                    <img src="img/footer-logo.png" alt="Footer Logo" />
                                </a>
                            </div>
                            <p>
                                The customer is at the heart of our unique business model, which includes design.
                            </p>
                            <a href="#">
                                <img src="img/payment.png" alt="Payment Methods" />
                            </a>
                        </div>
                    </div>

                    {/* Shopping Links */}
                    <div className="col-lg-2 offset-lg-1 col-md-3 col-sm-6">
                        <div className="footer__widget">
                            <h6>Shopping</h6>
                            <ul>
                                <li>
                                    <a href="#">Clothing Store</a>
                                </li>
                                <li>
                                    <a href="#">Trending Shoes</a>
                                </li>
                                <li>
                                    <a href="#">Accessories</a>
                                </li>
                                <li>
                                    <a href="#">Sale</a>
                                </li>
                            </ul>
                        </div>
                    </div>

                    {/* Information Links */}
                    <div className="col-lg-2 col-md-3 col-sm-6">
                        <div className="footer__widget">
                            <h6>Information</h6>
                            <ul>
                                <li>
                                    <a href="#">Contact Us</a>
                                </li>
                                <li>
                                    <a href="#">Payment Methods</a>
                                </li>
                                <li>
                                    <a href="#">Delivery</a>
                                </li>
                                <li>
                                    <a href="#">Return & Exchanges</a>
                                </li>
                            </ul>
                        </div>
                    </div>

                    {/* Newsletter */}
                    <div className="col-lg-3 offset-lg-1 col-md-6 col-sm-6">
                        <div className="footer__widget">
                            <h6>Newsletter</h6>
                            <div className="footer__newslatter">
                                <p>
                                    Be the first to know about new arrivals, look books, sales &amp; promos!
                                </p>
                                <form action="#">
                                    <input type="text" placeholder="Your email" />
                                    <button type="submit">
                                        <span className="icon_mail_alt"></span>
                                    </button>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>

                {/* Footer Bottom */}
                <div className="row">
                    <div className="col-lg-12 text-center">
                        <div className="footer__copyright__text">
                            <p>
                                &copy; {new Date().getFullYear()} All rights reserved | This template is made with{' '}
                                <i className="fa fa-heart-o" aria-hidden="true"></i> by{' '}
                                <a href="https://colorlib.com" target="_blank" rel="noopener noreferrer">
                                    Colorlib
                                </a>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </footer>
    );
};

export default Footer;
