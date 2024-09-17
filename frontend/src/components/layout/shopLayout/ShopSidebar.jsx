import { useEffect, useState } from 'react';
import axios from 'axios';
import SearchBar from "../SearchBar.jsx";

const ShopSidebar = ({ onCategorySelect }) => {
    const [categories, setCategories] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        axios.get('https://localhost:7051/api/Categories')
            .then(response => {
                // Assuming the API returns an array directly
                setCategories(response.data);
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
            <SearchBar/>

            <div className="shop__sidebar__categories">
                <h5>Categories</h5>
                <ul className="nice-scroll">
                    {categories.map((category) => (
                        <li key={category.id}>
                            <a href="#" onClick={(e) => {
                                e.preventDefault();
                                onCategorySelect(category.id);
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
