import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

const SearchBar = () => {
    const [searchTerm, setSearchTerm] = useState('');
    const navigate = useNavigate();

    // Handle input change
    const handleSearchChange = (e) => {
        setSearchTerm(e.target.value);
    };

    // Handle form submission for search functionality
    const handleSearchSubmit = (e) => {
        e.preventDefault();
        navigate(`/shop?search=${encodeURIComponent(searchTerm.trim())}`);
    };

    return (
        <div className="shop__sidebar__search">
            <form onSubmit={handleSearchSubmit}>
                <input type="text" placeholder="Search..." value={searchTerm} onChange={handleSearchChange} />
                <button type="submit">
                    <i className="fa fa-search"></i>
                </button>
            </form>
        </div>
    );
};

export default SearchBar;
