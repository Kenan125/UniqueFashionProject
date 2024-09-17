import { useEffect, useState } from 'react';

import SearchBar from '../SearchBar.jsx';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCircleXmark } from '@fortawesome/free-solid-svg-icons';
import {getCategories} from "../../../services/api.js";

const ShopSidebar = ({ onCategorySelect }) => {
    const [categories, setCategories] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const [activeCategory, setActiveCategory] = useState(null);
    const [searchTerm, setSearchTerm] = useState('');

    // Fetch categories from the API
    useEffect(() => {
        getCategories()
            .then(response => {
                setCategories(response.data);
                setLoading(false);
            })
            .catch(error => {
                console.error('Error fetching categories:', error);
                setError('Error fetching categories');
                setLoading(false);
            });
    }, []);

    const handleCategorySelect = (categoryId) => {
        setActiveCategory(categoryId);
        onCategorySelect(categoryId);
    };

    const resetCategoryFilter = () => {
        setActiveCategory(null);
        onCategorySelect(null);
    };

    const handleSearchInput = (e) => {
        setSearchTerm(e.target.value);
    };

    const resetSearch = () => {
        setSearchTerm('');
    };

    if (loading) {
        return <div>Loading categories...</div>;
    }

    if (error) {
        return <div>{error}</div>;
    }

    return (
        <div className="shop__sidebar">
            {/* Search Bar with Reset Button */}
            <div className="search-bar-wrapper">
                <SearchBar value={searchTerm} onChange={handleSearchInput} />
                {searchTerm && (
                    <button className="reset-search-btn" onClick={resetSearch}>
                        <FontAwesomeIcon icon={faCircleXmark} size="lg" />
                    </button>
                )}
            </div>

            {/* Collapse Button */}
            <p className="categories-header">
                <a className="btn" data-bs-toggle="collapse" href="#collapseCategories" role="button" aria-expanded="false" aria-controls="collapseCategories">
                    CATEGORIES
                    <span className="arrow">&#9662;</span>
                </a>
            </p>

            {/* Collapsible Categories Section */}
            <div className="collapse" id="collapseCategories">
                <div className="card-body">
                    <div className="shop__sidebar__categories">
                        <ul className="nice-scroll">
                            {categories.map((category) => (
                                <li key={category.id} className={`category-item ${activeCategory === category.id ? 'active' : ''}`}>
                                    <a href="#" onClick={(e) => {
                                        e.preventDefault();
                                        handleCategorySelect(category.id);
                                    }}>
                                        {category.name}
                                    </a>
                                    {activeCategory === category.id && (
                                        <button className="reset-btn" onClick={resetCategoryFilter}><FontAwesomeIcon icon={faCircleXmark} size="lg" /></button>
                                    )}
                                </li>
                            ))}
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default ShopSidebar;
