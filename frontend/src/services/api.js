import axios from 'axios';

const API_BASE_URL = 'https://localhost:7051/api';

export const getProducts = () => axios.get(`${API_BASE_URL}/Products`);
export  const postProducts = () => axios.post(`${API_BASE_URL}/Products`);
export const getProductById = (id) => axios.get(`${API_BASE_URL}/Products/${id}`);
export const updateProduct = (id) => axios.put(`${API_BASE_URL}/Products/${id}`);
export const deleteProduct = (id) => axios.delete(`${API_BASE_URL}/${id}`);
export const getBrands = () => axios.get(`${API_BASE_URL}/Brands`);

export const searchProducts = (term) => axios.get(`${API_BASE_URL}/Products/search`, { params: { term } });
export const getCategories = () => axios.get(`${API_BASE_URL}/Categories`);




