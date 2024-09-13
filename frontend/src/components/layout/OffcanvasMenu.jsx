import  { useState } from 'react';

const OffcanvasMenu = () => {
    const [menuActive, setMenuActive] = useState(false);

    // Toggle menu active state
    const toggleMenu = () => {
        setMenuActive(!menuActive);
    };

    return (
        <>
            {/* Overlay */}
            <div
                className={`offcanvas-menu-overlay ${menuActive ? 'active' : ''}`}
                onClick={toggleMenu}
            />

            {/* Offcanvas Menu Wrapper */}
            <div className={`offcanvas-menu-wrapper ${menuActive ? 'active' : ''}`}>
                <div className="offcanvas__option">
                    <div className="offcanvas__links">
                        <a href="#">Sign in</a>
                        <a href="#">FAQs</a>
                    </div>
                    <div className="offcanvas__top__hover">
                        <span>Usd <i className="arrow_carrot-down"></i></span>
                        <ul>
                            <li>USD</li>
                            <li>EUR</li>
                            <li>USD</li>
                        </ul>
                    </div>
                </div>
                <div className="offcanvas__nav__option">
                    <a href="#" className="search-switch"><img src="img/icon/search.png" alt=""/></a>
                    <a href="#"><img src="img/icon/heart.png" alt=""/></a>
                    <a href="#"><img src="img/icon/cart.png" alt=""/> <span>0</span></a>
                    <div className="price">$0.00</div>
                </div>
                <div id="mobile-menu-wrap"></div>
                <div className="offcanvas__text">
                    <p>Free shipping, 30-day return or refund guarantee.</p>
                </div>
            </div>

            {/* Button to open/close the menu */}
            <button className="canvas__open" onClick={toggleMenu}>☰</button>
        </>
    );
};

export default OffcanvasMenu;
