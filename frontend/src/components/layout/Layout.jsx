import { Outlet } from 'react-router-dom';

import Header from './Header';
import Breadcrumb from "./Breadcrumb.jsx";
import Footer from "./Footer.jsx";

const Layout = () => {
    return (
        <>
            <Header />
            <Breadcrumb/>

            <Outlet />
            <Footer/>
        </>
    );
}

export default Layout;
