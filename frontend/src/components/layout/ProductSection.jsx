const ProductSection = () => {
    return (
        <section className="product spad">
            <div className="container">
                <div className="row">
                    <div className="col-lg-12">
                        <ul className="filter__controls">
                            <li className="active" data-filter="*">Best Sellers</li>
                            <li data-filter=".new-arrivals">New Arrivals</li>
                            <li data-filter=".hot-sales">Hot Sales</li>
                        </ul>
                    </div>
                </div>
                <div className="row product__filter">
                    {/* Product 1 */}
                    <div className="col-lg-3 col-md-6 col-sm-6 mix new-arrivals">
                        <div className="product__item">
                            <div className="product__item__pic set-bg" style={{ backgroundImage: `url('img/product/product-1.jpg')` }}>
                                <span className="label">New</span>
                                <ul className="product__hover">
                                    <li><a href="#"><img src="img/icon/heart.png" alt="Wishlist" /></a></li>
                                    <li><a href="#"><img src="img/icon/compare.png" alt="Compare" /> <span>Compare</span></a></li>
                                    <li><a href="#"><img src="img/icon/search.png" alt="Search" /></a></li>
                                </ul>
                            </div>
                            <div className="product__item__text">
                                <h6>Piqué Biker Jacket</h6>
                                <a href="#" className="add-cart">+ Add To Cart</a>
                                <div className="rating">
                                    <i className="fa fa-star-o"></i>
                                    <i className="fa fa-star-o"></i>
                                    <i className="fa fa-star-o"></i>
                                    <i className="fa fa-star-o"></i>
                                    <i className="fa fa-star-o"></i>
                                </div>
                                <h5>$67.24</h5>
                                <div className="product__color__select">
                                    <label htmlFor="pc-1">
                                        <input type="radio" id="pc-1" />
                                    </label>
                                    <label className="active black" htmlFor="pc-2">
                                        <input type="radio" id="pc-2" />
                                    </label>
                                    <label className="grey" htmlFor="pc-3">
                                        <input type="radio" id="pc-3" />
                                    </label>
                                </div>
                            </div>
                        </div>
                    </div>

                    {/* Product 2 */}
                    <div className="col-lg-3 col-md-6 col-sm-6 mix hot-sales">
                        <div className="product__item">
                            <div className="product__item__pic set-bg" style={{ backgroundImage: `url('img/product/product-2.jpg')` }}>
                                <ul className="product__hover">
                                    <li><a href="#"><img src="img/icon/heart.png" alt="Wishlist" /></a></li>
                                    <li><a href="#"><img src="img/icon/compare.png" alt="Compare" /> <span>Compare</span></a></li>
                                    <li><a href="#"><img src="img/icon/search.png" alt="Search" /></a></li>
                                </ul>
                            </div>
                            <div className="product__item__text">
                                <h6>Piqué Biker Jacket</h6>
                                <a href="#" className="add-cart">+ Add To Cart</a>
                                <div className="rating">
                                    <i className="fa fa-star-o"></i>
                                    <i className="fa fa-star-o"></i>
                                    <i className="fa fa-star-o"></i>
                                    <i className="fa fa-star-o"></i>
                                    <i className="fa fa-star-o"></i>
                                </div>
                                <h5>$67.24</h5>
                                <div className="product__color__select">
                                    <label htmlFor="pc-4">
                                        <input type="radio" id="pc-4" />
                                    </label>
                                    <label className="active black" htmlFor="pc-5">
                                        <input type="radio" id="pc-5" />
                                    </label>
                                    <label className="grey" htmlFor="pc-6">
                                        <input type="radio" id="pc-6" />
                                    </label>
                                </div>
                            </div>
                        </div>
                    </div>

                    {/* Other products can be added similarly */}
                </div>
            </div>
        </section>
    );
};

export default ProductSection;
