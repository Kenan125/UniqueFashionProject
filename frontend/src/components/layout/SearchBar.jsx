import React, { useState } from 'react';

const SearchBar = () => {
    const [isOpen, setIsOpen] = useState(false);

    const openSearch = () => {
        setIsOpen(true); // Open search modal
    };

    const closeSearch = () => {
        setIsOpen(false); // Close search modal
        document.getElementById('search-input').value = ''; // Clear input
    };

    return (
        <>
            {/* Search Icon (Trigger) */}
            <img
                src="https://cdn4.iconfinder.com/data/icons/evil-icons-user-interface/64/magnifier-512.png"
                alt="Search Icon"
                style={{ height: '24px', cursor: 'pointer' }}
                onClick={openSearch}
            />

            {/* Search Modal */}
            {isOpen && (
                <div className="search-model" style={modalStyles}>
                    <div className="search-close-switch" style={closeButtonStyles} onClick={closeSearch}>
                        × {/* Close Button */}
                    </div>
                    <form action="#" className="search-model-form" style={formStyles}>
                        <input
                            type="text"
                            id="search-input"
                            placeholder="Search products..."
                            style={inputStyles}
                        />
                    </form>
                </div>
            )}
        </>
    );
};

// Styles
const modalStyles = {
    position: 'fixed',
    top: 0,
    left: 0,
    width: '100%',
    height: '100%',
    backgroundColor: 'rgba(0, 0, 0, 0.8)',
    zIndex: 9999,
    display: 'flex',
    justifyContent: 'center',
    alignItems: 'center',
};

const formStyles = {
    padding: '0 15px',
};

const inputStyles = {
    width: '500px',
    fontSize: '40px',
    border: 'none',
    borderBottom: '2px solid #333',
    backgroundColor: 'transparent',
    color: '#999',
};

const closeButtonStyles = {
    position: 'absolute',
    top: '30px',
    right: '30px',
    width: '50px',
    height: '50px',
    backgroundColor: '#333',
    color: '#fff',
    textAlign: 'center',
    borderRadius: '50%',
    fontSize: '28px',
    cursor: 'pointer',
};

export default SearchBar;
