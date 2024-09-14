import { Link } from 'react-router-dom';

function Header() {
    return (
        <header className="header">
            {/* Header Top */}
            <div className="header__top">
                <div className="container">
                    <div className="row">
                        {/* Left Side */}
                        <div className="col-lg-6 col-md-7">
                            <div className="header__top__left">
                                <p>Free shipping, 30-day return or refund guarantee.</p>
                            </div>
                        </div>
                        {/* Right Side */}
                        <div className="col-lg-6 col-md-5">
                            <div className="header__top__right">
                                <div className="header__top__links">
                                    <Link to="/signin">Sign in</Link>
                                    <Link to="/register">Register</Link>
                                </div>
                                <div className="header__top__hover">


                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            {/* Main Header */}
            <div className="container">
                <div className="row">
                    {/* Logo */}
                    <div className="col-lg-3 col-md-3">
                        <div className="header__logo">
                            <Link to="/">
                                <img src="/img/logo.png" alt="Logo" />
                            </Link>
                        </div>
                    </div>

                    {/* Navigation Menu */}
                    <div className="col-lg-6 col-md-6">
                        <nav className="header__menu mobile-menu">
                            <ul>
                                <li className="active">
                                    <Link to="/">Home</Link>
                                </li>
                                <li>
                                    <Link to="/shop">Shop</Link> {/* Ensure it's lowercase /shop */}
                                </li>
                                <li>
                                    <Link to="#">Pages</Link>
                                    <ul className="dropdown">
                                        <li>
                                            <Link to="/about">About Us</Link>
                                        </li>
                                        <li>
                                            <Link to="/shop-details">Shop Details</Link>
                                        </li>
                                        <li>
                                            <Link to="/shopping-cart">Shopping Cart</Link>
                                        </li>
                                        <li>
                                            <Link to="/checkout">Check Out</Link>
                                        </li>
                                        <li>
                                            <Link to="/blog-details">Blog Details</Link>
                                        </li>
                                    </ul>
                                </li>
                                <li>
                                    <Link to="/blog">Blog</Link>
                                </li>
                                <li>
                                    <Link to="/contact">Contacts</Link>
                                </li>
                            </ul>
                        </nav>
                    </div>

                    {/* Header Options */}
                    <div className="col-lg-3 col-md-3">
                        <div className="header__nav__option">
                            <button className="search-switch">
                                <i className="fas fa-search"></i>
                            </button>
                            <Link to="/wishlist">
                                <i className="fas fa-heart"></i>
                            </Link>
                            <Link to="/cart">
                                <img src="/img/icon/cart.png" alt="Cart"  /> <span>0</span>
                            </Link>
                            <div className="price">$0.00</div>
                        </div>
                    </div>
                </div>
                <div className="canvas__open">
                    <i className="fas fa-bars"></i>
                </div>
            </div>
        </header>
    );
}

export default Header;
