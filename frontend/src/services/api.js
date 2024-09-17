import axios from 'axios';

const API_BASE_URL = 'http://localhost:7051/api';

export const getProducts = () => axios.get(`${API_BASE_URL}/Products`);

export const getBrands = () => axios.get(`${API_BASE_URL}/Brands`);
export const searchProducts = (term) => axios.get(`${API_BASE_URL}/Products/search`, { params: { term } });
// Modify getCategories to handle the $values and mapping
export const getCategories = async () => {
    try {
        const response = await axios.get(`${API_BASE_URL}/Categories`);
        const categoriesData = response.data.$values || [];
        const categoriesWithId = categoriesData.map((category) => ({
            id: parseInt(category.$id), // Assign 'id' from '$id'
            name: category.name,
            parentCategoryId: category.parentCategoryId,
        }));
        return categoriesWithId;
    } catch (error) {
        console.error('Error fetching categories:', error);
        throw error;
    }
};

export const getProductsByCategory = (categoryId) =>
    axios.get(`${API_BASE_URL}/Products`, { params: { categoryId } }).then(res => res.data);