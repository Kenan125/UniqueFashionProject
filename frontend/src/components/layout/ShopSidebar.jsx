import React from 'react';

const ShopSidebar = () => {
    return (
        <div className="shop__sidebar">
            <div className="shop__sidebar__search">
                <form action="#">
                    <input type="text" placeholder="Search..." />
                    <button type="submit">
                        <span className="icon_search"></span>
                    </button>
                </form>
            </div>

            {/* Categories Filter */}
            <div className="shop__sidebar__categories">
                <h5>Categories</h5>
                <ul className="nice-scroll">
                    <li><a href="#">Men (20)</a></li>
                    <li><a href="#">Women (20)</a></li>
                    {/* You can replace this with dynamic data */}
                </ul>
            </div>

            {/* Additional filters like Brand, Price, etc., go here */}
        </div>
    );
};

export default ShopSidebar;
