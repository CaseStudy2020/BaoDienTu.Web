var home = {} || home;
top5 = [];

home.GetTop5 = function () {
    $.ajax({
        url: `/Home/GetsTop5LastestPost`,
        method: "GET",
        dataType: "json",

        success: function (data) {
            top5 = data.lastestpost
        }
    })
};
categoriId = [];
home.GetCategoryId = function () {
    $.ajax({
        url: `/Home/GetsCategory`,
        method: "GET",
        dataType: "json",

        success: function (data) {
            categoriId = data.categories
        }
    })
};

home.getTop1LatestPost = function () {
    $('#Top1LatestPost').empty();
    for (let i = 0; i <top5.length-4;i++ ) {
        $('#Top1LatestPost').append(
            `  <div class="latest-slider">
                   <div class="slider-active">
                        <div class="single-slider">
                            <div class="trending-top mb-30">
                                <div class="trend-top-img text-center">
                                      <a href="#"><img src="${top5[i].thumbnail}" alt=""></a>
                                         <div class="trend-top-cap">
                                           <span class="bgr" data-animation="fadeInUp" data-delay=".2s" data-duration="1000ms"><strong>${top5[i].title}</strong></span>
                                                <h2><a href="post_details.html" data-animation="fadeInUp" data-delay=".4s" data-duration="1000ms">${top5[i].shortContent}...</a></h2>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>`
        );
    }        
};

home.getTop2LatestPost = function () {
    $('#Top2LatestPost').empty();
    for (let i = 1; i < top5.length-2; i++) {
        $('#Top2LatestPost').append(
            `      <div class="col-xl-6 col-lg-6 col-md-6">
                                  <div class="single-baner-nw2 mb-30 ">
                                        <div class="banner-img-cap2">
                                            <div class="banner-img">
                                                 <a href="#"><img src="${top5[i].thumbnail}" alt=""></a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xl-6 col-lg-6 col-md-6">
                                    <div class="single-baner-nw2 mb-30">
                                        <div class="banner-img-cap2">
                                            <div class="banner-cap2 banner-cap3">
                                                <p>${top5[i].title}</p>
                                                <h3><a href="post_details.html">${top5[i].title}</a></h3>
                                                <p class="normal">${top5[i].shortContent}...</p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                </div>`
        );
    }
};

home.getTop3LatestPost = function () {
    $('#Top3LatestPost').empty();
    for (let i = 3; i < top5.length; i++) {
        $('#Top3LatestPost').append(
            `    <div class="col-lg-6">
                            <div class="single-baner-nw2 mb-30 text-center">
                                <div class="banner-img-cap2">
                                    <div class="banner-img">
                                       <a href="#"><img src="${top5[i].thumbnail}" alt="">
                                    </div>
                                    <div class="banner-cap2">
                                        <p>${top5[i].title}</p>
                                        <h3><a href="post_details.html">${top5[i].shortContent2}...</a></h3>
                                    </div>
                                </div>
                            </div>
                        </div>`
        );
    }
};



home.getByCategory = function () {
    $.ajax({
        url: `/Home/GetsCategory/`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#PostByCateId').empty();
            $.each(data.categories, function (i, v) {
                $('#PostByCateId').append(
                    `
            <div class="latest-posts pt-80 pb-80" style="background-color:#EFF5F8">
                <div class="container">
                    <div class="row">
                        <div class="col-12">
                            <div class="section-tittle mb-35">
                                <h2>${v.categoryName}</h2>
                            </div>
                        </div>
                    </div>
                    <div class="row" id="post_${v.categoriId}">
                   <div class="col-lg-4 col-md-6">
                            <div class="single-baner-nw2 mb-30">
                                <div class="banner-img-cap2">
                                    <div class="banner-img">
                                        <img src="lib/img/gallery/trend1.png" alt="">
                                    </div>
                                    <div class="banner-cap2">
                                        <p>Technology</p>
                                        <h3><a href="post_details.html">The pomelo case: scope of plant rights in China</a></h3>
                                        <p class="blog-text" style="text-transform: normal !important;">Indie folks start out by making something they want to read, that tell stories they want told..</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6">
                            <div class="single-baner-nw2 mb-30">
                                <div class="banner-img-cap2">
                                    <div class="banner-img">
                                        <img src="lib/img/gallery/trend2.png" alt="">
                                    </div>
                                    <div class="banner-cap2">
                                        <p>Technology</p>
                                        <h3><a href="post_details.html">The pomelo case: scope of plant rights in China</a></h3>
                                        <p class="blog-text" style="text-transform: normal !important;">Indie folks start out by making something they want to read, that tell stories they want told..</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6">
                            <div class="single-baner-nw2 mb-30">
                                <div class="banner-img-cap2">
                                    <div class="banner-img">
                                        <img src="lib/img/gallery/trend2.png" alt="">
                                    </div>
                                    <div class="banner-cap2">
                                        <p>Technology</p>
                                        <h3><a href="post_details.html">The pomelo case: scope of plant rights in China</a></h3>
                                        <p class="blog-text" style="text-transform: normal !;">Indie folks start out by making something they want to read, that tell stories they want told..</p>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
                    `
                );
                //home.drawpostofcategory(v.categoriId);
            });
        }
    });
};
//home.drawpostofcategory = function (categoryId) {
//    $.ajax({
//        url: `/Home/GetPostByCategoryId/${categoryId}`,
//        method: "GET",
//        dataType: "json",
//        success: function (data) {
//            $(`#post_${v.categoriId}`).empty();
//            $.each(data.postByCateId, function (i, k) {
//                $(`#post_${v.categoriId}`).append(`<div class="col-lg-4 col-md-6">
//                            <div class="single-baner-nw2 mb-30">
//                                <div class="banner-img-cap2">
//                                    <div class="banner-img">
//                                        <a href="#"><img src="${k.thumbnail}" alt=""></a>
//                                    </div>
//                                    <div class="banner-cap2">
//                                        <p>${k.thumbnail}</p>
//                                        <h3><a href="post_details.html">${k.title}</a></h3>
//                                        <p class="blog-text" style="text-transform: normal !important;">${k.shortContent}...</p>
//                                    </div>
//                                </div>
//                            </div>
//                        </div>`
//                );
//            });
//        }
//    });
//}
home.init = function () {
    home.GetCategoryId();
    home.GetTop5();
    setInterval(home.getTop1LatestPost, 1000);
    setInterval(home.getTop2LatestPost, 1000);
    setInterval(home.getTop3LatestPost, 1000);
    setInterval(home.getByCategory, 1000);
    

};

$(document).ready(function () {
    home.init();
});