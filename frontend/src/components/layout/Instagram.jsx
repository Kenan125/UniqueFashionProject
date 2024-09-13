import React from 'react';

const Instagram = () => {
    // Instagram images array (You can add more images or make them dynamic if needed)
    const instagramImages = [
        'img/instagram/instagram-1.jpg',
        'img/instagram/instagram-2.jpg',
        'img/instagram/instagram-3.jpg',
        'img/instagram/instagram-4.jpg',
        'img/instagram/instagram-5.jpg',
        'img/instagram/instagram-6.jpg',
    ];

    return (
        <section className="instagram spad">
            <div className="container">
                <div className="row">
                    <div className="col-lg-8">
                        <div className="instagram__pic">
                            {instagramImages.map((image, index) => (
                                <div
                                    key={index}
                                    className="instagram__pic__item set-bg"
                                    style={{ backgroundImage: `url(${image})` }}
                                ></div>
                            ))}
                        </div>
                    </div>
                    <div className="col-lg-4">
                        <div className="instagram__text">
                            <h2>Instagram</h2>
                            <p>
                                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut
                                labore et dolore magna aliqua.
                            </p>
                            <h3>#Male_Fashion</h3>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    );
};

export default Instagram;
