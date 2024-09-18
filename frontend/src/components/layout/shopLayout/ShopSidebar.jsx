import { useEffect, useState } from 'react';
import SearchBar from '../SearchBar.jsx';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCircleXmark } from '@fortawesome/free-solid-svg-icons';
import { getBrands, getCategories } from '../../../services/api.js';

const ShopSidebar = ({ onCategorySelect, onBrandSelect }) => {
    const [categories, setCategories] = useState([]);
    const [brands, setBrands] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const [activeCategory, setActiveCategory] = useState(null);
    const [activeBrand, setActiveBrand] = useState(null);
    const [searchTerm, setSearchTerm] = useState('');

    // Fetch categories from the API
    useEffect(() => {
        getCategories()
            .then(response => {
                setCategories(response.data);
                setLoading(false);
            })
            .catch(error => {
                setError('Error fetching categories');
                setLoading(false);
            });
    }, []);

    // Fetch brands from the API
    useEffect(() => {
        getBrands()
            .then(response => {
                setBrands(response.data);
                setLoading(false);
            })
            .catch(error => {
                setError('Error fetching brands');
                setLoading(false);
            });
    }, []);

    const handleCategorySelect = (categoryId) => {
        setActiveCategory(categoryId);
        onCategorySelect(categoryId);
    };

    const handleBrandSelect = (brandId, brandName) => {
        setActiveBrand(brandName); // Store the selected brand name
        onBrandSelect(brandId);
    };

    const resetCategoryFilter = () => {
        setActiveCategory(null);
        onCategorySelect(null);
    };

    const resetBrandFilter = () => {
        setActiveBrand(null);
        onBrandSelect(null);
    };

    const handleSearchInput = (e) => {
        setSearchTerm(e.target.value);
    };

    const resetSearch = () => {
        setSearchTerm('');
    };

    if (loading) {
        return <div>Loading categories and brands...</div>;
    }

    if (error) {
        return <div>{error}</div>;
    }

    return (
        <div className="shop__sidebar">
            {/* Search Bar with Reset Button */}
            <div className="shop__sidebar__search">
                <SearchBar value={searchTerm} onChange={handleSearchInput} />
                {searchTerm && (
                    <button className="reset-search-btn" onClick={resetSearch}>
                        <FontAwesomeIcon icon={faCircleXmark} size="lg" />
                    </button>
                )}
            </div>

            {/* Categories Section */}
            <div className="shop__sidebar__accordion">
                <div className="accordion" id="accordionExample">
                    <div className="card">
                        <div className="card-heading">
                            <a data-bs-toggle="collapse" data-bs-target="#collapseCategories" aria-expanded="true">
                                Categories
                            </a>
                        </div>
                        <div id="collapseCategories" className="collapse show" data-bs-parent="#accordionExample">
                            <div className="card-body">
                                <div className="shop__sidebar__categories">
                                    <ul className="nice-scroll">
                                        {categories.map((category) => (
                                            <li
                                                key={category.id || category.name}
                                                className={`category-item ${activeCategory === category.id ? 'active' : ''}`}>
                                                <a href="#" onClick={(e) => {
                                                    e.preventDefault();
                                                    handleCategorySelect(category.id);
                                                }}>
                                                    {category.name}
                                                </a>
                                                {activeCategory === category.id && (
                                                    <button className="reset-btn" onClick={resetCategoryFilter}>
                                                        <FontAwesomeIcon icon={faCircleXmark} size="lg" />
                                                    </button>
                                                )}
                                            </li>
                                        ))}
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>

                    {/* Brands Section */}
                    <div className="card">
                        <div className="card-heading">
                            <a data-bs-toggle="collapse" data-bs-target="#collapseBrands" aria-expanded="true">
                                Brands
                            </a>
                        </div>
                        <div id="collapseBrands" className="collapse show" data-bs-parent="#accordionExample">
                            <div className="card-body">
                                <div className="shop__sidebar__brand">
                                    <ul className="nice-scroll">
                                        {brands.map((brand) => (
                                            <li
                                                key={brand.id || brand.name}
                                                className={`category-item ${activeBrand === brand.name ? 'active' : ''}`}>
                                                <a href="#" onClick={(e) => {
                                                    e.preventDefault();
                                                    handleBrandSelect(brand.id, brand.name);
                                                }}>
                                                    {brand.name}
                                                </a>
                                                {activeBrand === brand.name && (
                                                    <button className="reset-btn" onClick={resetBrandFilter}>
                                                        <FontAwesomeIcon icon={faCircleXmark} size="lg" />
                                                    </button>
                                                )}
                                            </li>
                                        ))}
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>

                    {/* Display Selected Brand */}
                    {activeBrand && (
                        <div className="selected-brand">
                            <p>Products for Brand {activeBrand}</p>
                        </div>
                    )}
                </div>
            </div>
        </div>
    );
};

export default ShopSidebar;
