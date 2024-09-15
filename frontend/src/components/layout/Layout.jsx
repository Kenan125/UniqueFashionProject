import { Outlet } from 'react-router-dom';

import Header from './Header';
import Breadcrumb from "./Breadcrumb.jsx";

const Layout = () => {
    return (
        <>
            <Header />
            <Breadcrumb/>

            <Outlet /> {/* Renders the child route content, like Home or ProductsPage */}
        </>
    );
}

export default Layout;
