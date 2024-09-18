import ShopSidebar from "../layout/shopLayout/ShopSidebar.jsx";
import ShopProductList from "../layout/shopLayout/ShopProductList.jsx";
import {useState} from "react";


function Shop() {
    const [selectedCategory, setSelectedCategory] = useState(null);
    const [activeBrand, setActiveBrand] = useState(null);

    const handleCategorySelect = (categoryId) => {
        setSelectedCategory(categoryId); // Update the selected category state
    };

    const handleBrandSelect = (brandId) => {
        setActiveBrand(brandId); // Update the selected brand state
    };
    return (
        <section className="shop spad">
            <div className="container">
                <div className="row">
                    <div className="col-lg-3">
                        <ShopSidebar onCategorySelect={setSelectedCategory} onBrandSelect={setActiveBrand}   />
                    </div>
                    <div className="col-lg-9">
                        <ShopProductList selectedCategory={selectedCategory} selectedBrand={activeBrand} onCategorySelect={handleCategorySelect}  // Pass the reset function
                                         onBrandSelect={handleBrandSelect} />
                    </div>
                </div>
            </div>
        </section>
    );
}

export default Shop;