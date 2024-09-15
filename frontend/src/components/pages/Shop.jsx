import ShopSidebar from "../layout/ShopSidebar.jsx";
import ShopProductList from "../layout/ShopProductList.jsx";


function Shop() {
    return (
        <section className="shop spad">
            <div className="container">
                <div className="row">
                    <div className="col-lg-3">
                        <ShopSidebar/>
                    </div>
                    <div className="col-lg-9">
                        <ShopProductList/>
                    </div>
                </div>
            </div>
        </section>
    );
}

export default Shop;