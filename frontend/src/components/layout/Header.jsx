import { NavLink } from 'react-router-dom';
import SearchBar from "./SearchBar.jsx";

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
                                    <NavLink to="/signin">Sign in</NavLink>
                                    <NavLink to="/register">Register</NavLink>
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
                            <NavLink to="/">
                                <img src="/img/logo.png" alt="Logo" />
                            </NavLink>
                        </div>
                    </div>

                    {/* Navigation Menu */}
                    <div className="col-lg-6 col-md-6">
                        <nav className="header__menu mobile-menu">
                            <ul>
                                <li>

                                    <NavLink
                                        to="/"
                                        className={({ isActive }) => (isActive ? 'active' : '')}
                                        end
                                    >
                                        Home
                                    </NavLink>
                                </li>
                                <li>
                                    <NavLink
                                        to="/shop"
                                        className={({ isActive }) => (isActive ? 'active' : '')}
                                    >
                                        Shop
                                    </NavLink>
                                </li>
                                <li>
                                    <NavLink
                                        to="/pages"
                                        className={({ isActive }) => (isActive ? 'active' : '')}
                                    >
                                        Pages
                                    </NavLink>
                                    <ul className="dropdown">
                                        <li>
                                            <NavLink to="/about">About Us</NavLink>
                                        </li>
                                        <li>
                                            <NavLink to="/shop-details">Shop Details</NavLink>
                                        </li>
                                        <li>
                                            <NavLink to="/shopping-cart">Shopping Cart</NavLink>
                                        </li>
                                        <li>
                                            <NavLink to="/checkout">Check Out</NavLink>
                                        </li>
                                        <li>
                                            <NavLink to="/blog-details">Blog Details</NavLink>
                                        </li>
                                    </ul>
                                </li>
                                <li>
                                    <NavLink
                                        to="/blog"
                                        className={({ isActive }) => (isActive ? 'active' : '')}
                                    >
                                        Blog
                                    </NavLink>
                                </li>
                                <li>
                                    <NavLink
                                        to="/contact"
                                        className={({ isActive }) => (isActive ? 'active' : '')}
                                    >
                                        Contacts
                                    </NavLink>
                                </li>

                            </ul>

                        </nav>

                    </div>

                    {/* Header Options */}
                    <div className="col-lg-3 col-md-3">

                        <div className="header__nav__option d-flex align-items-center justify-content-end">

                            <SearchBar/>
                            <NavLink to="/cart" className="d-flex align-items-center ml-3">

                                <img src="/img/icon/cart.png" alt="Cart" className="img-fluid"/>
                                <span>0</span>
                            </NavLink>

                            <div className="price ml-2">$0.00</div>
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
