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
 


home.getTop5LatestPost = function () {
    $('#Top5LatestPost').empty();
    for (let i = 1; i < top5.length;i++ ) {
        $('#Top5LatestPost').append(
            `  <div class="single-slider">
                    <div class="trending-top mb-30">
                        <div class="trend-top-img text-center">
                                <a href="#"><img src="${top5[i].thumbnail}" alt=""></a>
                            <div class="trend-top-cap">
                                <span class="bgr" data-animation="fadeInUp" data-delay=".2s" data-duration="1000ms">${top5[i].title}</span>
                                <h2><a href="post_details.html" data-animation="fadeInUp" data-delay=".4s" data-duration="1000ms">${top5[i].shortContent}...</a></h2>
                            </div>
                        </div>
                    </div>
                </div>`
        );
    }        
};

home.init = function () {
    setInterval(home.GetTop5, 1000);
    home.getTop5LatestPost();
};

$(document).ready(function () {
    home.init();
});