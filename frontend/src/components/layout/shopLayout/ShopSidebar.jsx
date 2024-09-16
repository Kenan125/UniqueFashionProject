import { useEffect, useState } from 'react';
import axios from 'axios';

const ShopSidebar = ({ onCategorySelect }) => {
    const [categories, setCategories] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        axios.get('https://localhost:7051/api/Categories')
            .then(response => {
                setCategories(response.data.$values); // Adjust based on API response structure
                setLoading(false);
            })
            .catch(error => {
                console.error('Error fetching categories:', error);
                setError('Error fetching categories');
                setLoading(false);
            });
    }, []);

    if (loading) {
        return <div>Loading categories...</div>;
    }

    if (error) {
        return <div>{error}</div>;
    }

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
                    {categories.map((category) => (
                        <li key={category.id}>
                            {/* onClick to trigger onCategorySelect with category id */}
                            <a href="#" onClick={(e) => {
                                e.preventDefault(); // Prevent default link behavior
                                onCategorySelect(category.id); // Call the callback with the category id
                            }}>
                                {category.name}
                            </a>
                        </li>
                    ))}
                </ul>
            </div>
        </div>
    );
};

export default ShopSidebar;
