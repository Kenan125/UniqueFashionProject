import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import '../../../public/css/SearchBar.css'; // Ensure your CSS file is correctly linked

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
                    <span className="icon_search"></span>
                </button>
            </form>
        </div>
    );
};

export default SearchBar;
