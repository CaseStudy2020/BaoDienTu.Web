var post = {} || post;

post.getsTop5LastestPost = function () {
    $.ajax({
        url: `/Home/GetsTop5LastestPost`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#top5lastestpost').empty();
            $.each(data.top5lastestpost, function (i, v) {
                $('#top5lastestpost').append(
                    `
                        <div class="col-lg-4 col-md-6">
                        <div class="single-baner-nw2 mb-30">
                            <div class="banner-img-cap2">
                                <div class="banner-img">
                                    <img src="${v.thumpnail}" alt="">
                                </div>
                                <div class="banner-cap2">
                                    <p>Technology</p>
                                    <h3><a href="post_details.html">${v.title}</a></h3>
                                    <p class="blog-text" style="text-transform: normal !important;">Indie folks start out by making something they want to read, that tell stories they want told..</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    `
                );
            });
        }
    });
}


post.init = function () {
    post.getsTop5LastestPost;
};
$(document).ready(function () {
    post.init();
});