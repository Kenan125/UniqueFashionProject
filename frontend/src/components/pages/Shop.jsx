import ShopSidebar from "../layout/shopLayout/ShopSidebar.jsx";
import ShopProductList from "../layout/shopLayout/ShopProductList.jsx";
import {useState} from "react";


function Shop() {
    const [selectedCategory, setSelectedCategory] = useState(null);
    return (
        <section className="shop spad">
            <div className="container">
                <div className="row">
                    <div className="col-lg-3">
                        <ShopSidebar onCategorySelect={setSelectedCategory} />
                    </div>
                    <div className="col-lg-9">
                        <ShopProductList selectedCategory={selectedCategory} />
                    </div>
                </div>
            </div>
        </section>
    );
}

export default Shop;