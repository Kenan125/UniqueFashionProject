import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import '/css/SearchBar.css?url'; // Ensure your CSS file is correctly linked

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
        if (searchTerm.trim()) {
            navigate(`/shop?search=${searchTerm}`);
        } else {
            navigate('/shop'); // Navigate to show all products when no search term
        }
    };

    return (
        <div className="shop__sidebar__search">
            <form onSubmit={handleSearchSubmit}>
                <input
                    type="text"
                    placeholder="Search..."
                    value={searchTerm}
                    onChange={handleSearchChange}
                />
                <button type="submit">
                    <i className="fa-sharp fa-solid fa-magnifying-glass"></i>
                </button>
            </form>
        </div>
    );
};

export default SearchBar;
