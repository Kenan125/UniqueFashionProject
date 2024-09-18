import axios from 'axios';

const API_BASE_URL = 'https://localhost:7051/api';

export const getProducts = () => axios.get(`${API_BASE_URL}/Products`);

export const getBrands = () => axios.get(`${API_BASE_URL}/Brands`);
export const searchProducts = (term) => axios.get(`${API_BASE_URL}/Products/search`, { params: { term } });
export const getCategories = () => axios.get(`${API_BASE_URL}/Categories`);




