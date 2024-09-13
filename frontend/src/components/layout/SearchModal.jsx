

import {useState} from "react"; // Make sure to import the CSS

const SearchModal = () => {
    const [isActive, setIsActive] = useState(false);

    // Function to open the search modal
    const openSearch = () => {
        setIsActive(true);
    };

    // Function to close the search modal
    const closeSearch = () => {
        setIsActive(false);
    };

    return (
        <>
            {/* Button or icon to open the search modal */}
            <button className="search-open-button" onClick={openSearch}>
                <img src="img/icon/search.png" alt="Search" />
            </button>

            {/* Search Modal */}
            <div className={`search-model ${isActive ? 'active' : ''}`}>
                <div className="h-100 d-flex align-items-center justify-content-center">
                    <div className="search-close-switch" onClick={closeSearch}>
                        +
                    </div>
                    <form className="search-model-form">
                        <input
                            type="text"
                            id="search-input"
                            placeholder="Search here....."
                        />
                    </form>
                </div>
            </div>
        </>
    );
};

export default SearchModal;
