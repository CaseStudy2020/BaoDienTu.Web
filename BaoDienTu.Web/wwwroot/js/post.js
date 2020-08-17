﻿var post = {} || post;
var id = 0;

post.postDetail = function () {
    $.ajax({
        url: `/Post/PostDetail/${id}`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#detail').empty();
            $.each(data.postById, function (i, v) {
                $('#detail').append(
                    `<div class="container">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="details-img mb-40">
                            <img class="img-fluid" src="${v.thumbnail}" alt="">
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-8">
                        <div class="about-details-cap">
                            <h2>Calling time on irresponsible junk  food advertising to children</h2>
                        </div>
                    </div>
                    <div class="col-lg-10">
                        <div class="about-details-cap">
                            <p class="mb-30">Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. </p>

                            <p class="mb-30">Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. </p>

                            <p class="mb-50">Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem.</p>
                        </div>
                    </div>
                    <div class="col-lg-10">
                        <div class="about-details-cap">
                            <h3>Calling time on irresponsible junk  food advertising to children</h3>
                            <p>Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. </p>
                            <div class="details-img">
                                <img class="img-fluid mb-15" src="~/lib/img/gallery/post_details2.png" alt="">
                                <p>Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem.</p>
                            </div>
                            <!-- Socaial -->
                            <div class="social-iocn pt-20 pb-20">
                                <a href="#"><img class="mr-10 mb-10" src="~/lib/img/gallery/facebook.png" alt=""></a>
                                <a href="#"><img class="mr-10 mb-10" src="~/lib/img/gallery/twitter.png" alt="#"></a>
                                <a href="#"><img class="mr-10 mb-10" src="~/lib/img/gallery/pinterest.png" alt=""></a>
                                <a href="#"><img class="mb-10" src="~/lib/img/gallery/whatsapp.png" alt=""></a>
                            </div>
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
    post.postDetail();
};
$(document).ready(function () {
    id = $("#PostId").val();
    post.init();
});