
$(document).ready(function () {
    $('#radioo').click(function () {
        $('.content').change(function () {
            var value = $(this).val();
            console.log(value)
            $.ajax({
                type: "GET",
                url: `/Home/SearchContent/${value}`,

            })


        })
    })
});
//$(function () // this function excited if the jquery is ready i mean after jquery successfully loaded
//{
//    function loaddata() {

//        var moviename = $("#moviename").val(); // read moviename value and assign;

//        console.log("moviename: ", moviename)

//        $.ajax({
//            type: "GET",          
//            url: `/Home/Search/${moviename}`,        
//            data: {
//                 //"search": moviename
//                name: moviename 
//            },
//            success: function (data) {   
//                console.log("Data", data)
//                $("#result").html(data.post, function (i, v) {
//                    $('#result').append(
//                        `<div class="card mb-3">
//                            <div class="row no-gutters">
//                                <div class="col-md-4">
//                                    <img src='${v.thumbnail}' width="auto" height="166.25px" class="card-img" alt="...">
//                                            </div>
//                                    <div class="col-md-8">
//                                        <div class="card-body">
//                                            <h5 class="card-title">${v.title}"</h5>
//                                            <p class="card-text"><small class="text-muted">Last updated 3 mins ago</small></p>
//                                            <p class="card-text">${v.content}</p>
//                                        </div>
//                                    </div>
//                                </div>
//                            </div>`
//                    )
//                });

//            }       

//        });

//    }
      

//    $("#submit").click(function (event) // Click Event Listener.
//    {
//        console.log("Submit Clicked")
//        event.preventDefault();
//        loaddata()
//    });
//});

