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
                                           <span class="bgr" data-animation="fadeInUp" data-delay=".2s" data-duration="1000ms">${top5[i].title}</span>
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
                                        <img src="${top5[i].thumbnail}" alt="">
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


home.init = function () {
   
    home.GetTop5();
    setInterval(home.getTop1LatestPost, 1000);
    setInterval(home.getTop2LatestPost, 1000);
    setInterval(home.getTop3LatestPost, 1000);
   
};

$(document).ready(function () {
    home.init();
});