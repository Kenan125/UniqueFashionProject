import React from 'react';
import { Link, useLocation } from 'react-router-dom';

const Breadcrumb = () => {
    const location = useLocation();
    const path = location.pathname.split('/').filter(Boolean);

    // Don't show breadcrumb on the homepage
    if (location.pathname === '/') {
        return null;
    }

    const createBreadcrumbLinks = () => {
        return path.map((segment, index) => {
            const link = `/${path.slice(0, index + 1).join('/')}`;
            const isLast = index === path.length - 1;
            return isLast ? (
                <span key={index}>{segment.charAt(0).toUpperCase() + segment.slice(1)}</span>
            ) : (
                <Link key={index} to={link}>
                    {segment.charAt(0).toUpperCase() + segment.slice(1)}
                </Link>
            );
        });
    };

    return (
        <section className="breadcrumb-option">
            <div className="container">
                <div className="row">
                    <div className="col-lg-12">
                        <div className="breadcrumb__text">
                            <h4>{path.length > 0 ? path[path.length - 1].charAt(0).toUpperCase() + path[path.length - 1].slice(1) : 'Shop'}</h4>
                            <div className="breadcrumb__links">
                                <Link to="/">Home</Link>
                                {createBreadcrumbLinks()}
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    );
};

export default Breadcrumb;
