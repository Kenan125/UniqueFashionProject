import { Outlet } from 'react-router-dom';

import Header from './Header';

const Layout = () => {
    return (
        <>

            <Header />
            <Outlet /> {/* Renders the child route content, like Home or ProductsPage */}
        </>
    );
}

export default Layout;
