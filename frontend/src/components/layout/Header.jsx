import { useState, useEffect } from 'react';
import { NavLink, useNavigate } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faBagShopping, faUser } from '@fortawesome/free-solid-svg-icons';
import SearchBar from './SearchBar.jsx';

function Header() {
    const [isLoggedIn, setIsLoggedIn] = useState(false); // Track login status
    const [username, setUsername] = useState(null); // Store logged-in user's name
    const navigate = useNavigate();

    useEffect(() => {
        // Check if the user is logged in (e.g., by checking localStorage or a token)
        const token = localStorage.getItem('token');
        const savedUsername = localStorage.getItem('username'); // Assuming username is stored in localStorage
        if (token && savedUsername) {
            setIsLoggedIn(true);
            setUsername(savedUsername);
        }
    }, []);

    const handleLogout = () => {
        // Clear token and username from localStorage
        localStorage.removeItem('token');
        localStorage.removeItem('username');
        setIsLoggedIn(false);
        setUsername(null);
        navigate('/'); // Redirect to homepage after logout
    };

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
                                    {isLoggedIn ? (
                                        <div className="dropdown">
                                            <button
                                                className="btn btn-secondary dropdown-toggle"
                                                type="button"
                                                data-bs-toggle="dropdown"
                                                aria-expanded="false"
                                            >
                                                <FontAwesomeIcon icon={faUser} /> {username}
                                            </button>
                                            <ul className="dropdown-menu">
                                                <li>
                                                    <NavLink className="dropdown-item" to="/account">
                                                        My Account
                                                    </NavLink>
                                                </li>
                                                <li>
                                                    <button className="dropdown-item" onClick={handleLogout}>
                                                        Logout
                                                    </button>
                                                </li>
                                            </ul>
                                        </div>
                                    ) : (
                                        <>
                                            <NavLink to="/login">Log in</NavLink>
                                            <NavLink to="/register">Register</NavLink>
                                        </>
                                    )}
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
                        <nav className="header__menu">
                            <ul>
                                <li>
                                    <NavLink to="/" end>
                                        Home
                                    </NavLink>
                                </li>
                                <li>
                                    <NavLink to="/shop">Shop</NavLink>
                                </li>
                            </ul>
                        </nav>
                    </div>

                    {/* Header Options */}
                    <div className="col-lg-3 col-md-3">
                        <div className="header__nav__option d-flex align-items-center justify-content-end">
                            <SearchBar />
                            <NavLink to="/cart" className="nav-link-custom d-flex align-items-center ml-3">
                                <FontAwesomeIcon icon={faBagShopping} style={{ color: '#23385c' }} />
                                <span>0</span>
                            </NavLink>
                            <div className="price ml-2">$0.00</div>
                        </div>
                    </div>
                </div>
            </div>
        </header>
    );
}

export default Header;
