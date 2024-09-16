import React from 'react';

const LatestNews = () => {
    const blogPosts = [
        {
            id: 1,
            image: 'img/blog/blog-1.jpg',
            date: '16 February 2020',
            title: 'What Curling Irons Are The Best Ones',
            link: '#',
        },
        {
            id: 2,
            image: 'img/blog/blog-2.jpg',
            date: '21 February 2020',
            title: 'Eternity Bands Do Last Forever',
            link: '#',
        },
        {
            id: 3,
            image: 'img/blog/blog-3.jpg',
            date: '28 February 2020',
            title: 'The Health Benefits Of Sunglasses',
            link: '#',
        },
    ];

    return (
        <section className="latest spad">
            <div className="container">
                {/* Section Title */}
                <div className="row">
                    <div className="col-lg-12">
                        <div className="section-title">
                            <span>Latest News</span>
                            <h2>Fashion New Trends</h2>
                        </div>
                    </div>
                </div>

                {/* Blog Posts */}
                <div className="row">
                    {blogPosts.map((post) => (
                        <div className="col-lg-4 col-md-6 col-sm-6" key={post.id}>
                            <div className="blog__item">
                                <div
                                    className="blog__item__pic set-bg"
                                    style={{ backgroundImage: `url(${post.image})` }}
                                ></div>
                                <div className="blog__item__text">
                  <span>
                    <img src="img/icon/calendar.png" alt="Calendar" /> {post.date}
                  </span>
                                    <h5>{post.title}</h5>
                                    <a href={post.link}>Read More</a>
                                </div>
                            </div>
                        </div>
                    ))}
                </div>
            </div>
        </section>
    );
};

export default LatestNews;
