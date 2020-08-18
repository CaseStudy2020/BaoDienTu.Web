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
//home.GetCategoryId = function () {
//    $.ajax({
//        url: `/Home/GetsCategory`,
//        method: "GET",
//        dataType: "json",

//        success: function (data) {
//            categoriId = data.categories
//        }
//    })
//};

home.getTop1LatestPost = function () {
    $('#Top1LatestPost').empty();
    for (let i = 0; i <top5.length-4;i++ ) {
        $('#Top1LatestPost').append(
            `  <div class="latest-slider">
                   <div class="slider-active">
                        <div class="single-slider">
                            <div class="trending-top mb-30">
                                <div class="trend-top-img text-center">
                                      <a href="Post/PostDetail/${top5[i].postId}"><img src="${top5[i].thumbnail}" style="width:570px;height:500px" alt=""></a>
                                         <div class="trend-top-cap">
                                            <a href="Post/PostDetail/${top5[i].postId}"><span class="bgr" data-animation="fadeInUp" data-delay=".2s" data-duration="1000ms"><strong>${top5[i].title}</strong></span></a>
                                        
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
                                                 <a href="Post/PostDetail/${top5[i].postId}"><img src="${top5[i].thumbnail}" alt=""></a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xl-6 col-lg-6 col-md-6">
                                    <div class="single-baner-nw2 mb-30">
                                        <div class="banner-img-cap2">
                                            <div class="banner-cap2 banner-cap3">
                                                <p>${top5[i].title}</p>
                                                <h3><a href="Post/PostDetail/${top5[i].postId}">${top5[i].title}</a></h3>
                                                <p class="normal">${top5[i].shortContent2}...</p>
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
                                       <a href="Post/PostDetail/${top5[i].postId}"><img src="${top5[i].thumbnail}" alt="">
                                    </div>
                                    <div class="banner-cap2">
                                        <p>${top5[i].title}</p>
                                        <h3><a href="Post/PostDetail/${top5[i].postId}">${top5[i].shortContent2}...</a></h3>
                                    </div>
                                </div>
                            </div>
                        </div>`
        );
    }
};



//home.getByCategory = function () {
//    $.ajax({
//        url: `/Home/GetsCategory/`,
//        method: "GET",
//        dataType: "json",
//        success: function (data) {
//            $('#PostByCateId').empty();
//            $.each(data.categories, function (i, v) {
//                $('#PostByCateId').append(
//                    `
//            <div class="latest-posts pt-80 pb-80" style="background-color:#EFF5F8">
//                <div class="container">
//                    <div class="row">
//                        <div class="col-12">
//                            <div class="section-tittle mb-35">
//                                <h2>${v.categoryName}</h2>
//                            </div>
//                        </div>
//                    </div>
//                    <div class="row" id="post_${v.categoryId}">
                 

//                    </div>
//                </div>
//            </div>
//                    `
//                );
//                //home.drawpostofcategory(v.categoryId);
//            });
//        }
//    });
//};


//home.drawpostofcategory = function (categoryId) {
//    $.ajax({
//        url: `/Home/GetsTop3LastestPostByCategoryId/${categoryId}`,
//        method: "GET",
//        dataType: "json",
//        success: function (data) {
//            $(`#post_${v.categoriId}`).empty();
//            $.each(data.post3ByCateId, function (i, k) {
//                $(`#post_${v.categoriId}`).append(`<div class="col-lg-4 col-md-6">
//                            <div class="single-baner-nw2 mb-30">
//                                <div class="banner-img-cap2">
//                                    <div class="banner-img">
//                                        <a href="#"><img src="${k.thumbnail}" alt=""></a>
//                                    </div>
//                                    <div class="banner-cap2">
//                                        <p>${k.title}</p>
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



home.getTop10PostByDay = function () {
    $.ajax({
        url: `/Home/GetTop10MostViewOfDay`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#mostviewpost').empty();
            $.each(data.mostviewpost, function (i, v) {
                $('#mostviewpost').append(
                    `<div class="single-job-items mb-30">
                        <div class="job-items">
                            <div class="company-img">
                                <a href="Post/PostDetail/${v.postId}"><img src="${v.thumbnail}" style="width:264px;height:214px" alt=""></a>
                            </div>
                            <div class="job-tittle">
                                <a href="Post/PostDetail/${v.postId}"><h4>${v.title}</h4></a>
                                <span>${v.dateCreated} - <i class="far fa-eye"></i> ${v.view}</span>
                                <p>${v.shortContent}...</p>
                                <a href="Post/PostDetail/${v.postId}" style="color:blue">Read more <i class="far fa-arrow-alt-circle-right"></i></a>
                                <span><i class="far fa-thumbs-up"></i> ${v.like} - <i class="fas fa-comment"></i> ${v.numberOfComment}</span>
                            </div>
                        </div>
                    </div>
                    `
                );
            });
        }
    });
}

//home.getAllCategory = function () {
//    $.ajax({
//        url: `/Home/GetsCategory`,
//        method: "GET",
//        dataType: "json",
//        success: function (data) {
//            $('#navigation').empty();
//            $.each(data.categories, function (i, v) {
//                $('#navigation').append(
//                    `
//                    <li><a href="Post/PostByCategory/${v.categoriId}">${v.categoryName}</a></li>
//                    `
//                );
//            });
//        }
//    });
//}
home.init = function () {
    //home.getAllCategory();
    //home.GetCategoryId();
    home.GetTop5();
    setInterval(home.getTop1LatestPost, 1000);
    setInterval(home.getTop2LatestPost, 1000);
    setInterval(home.getTop3LatestPost, 1000);
    home.getTop10PostByDay();
    //home.getByCategory();
    //home.drawpostofcategory();

    

};

$(document).ready(function () {
    home.init();
});