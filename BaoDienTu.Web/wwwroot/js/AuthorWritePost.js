let ajaxPost = function (dataModel) {
    $.ajax({
        type: "POST",
        url: `author/SavePost`,
        contentType : "application/json",
        data: JSON.stringify(dataModel),
        dataType: "json",
        success: function (response) {
            console.log(response);
            alert(response.result.message)
        }
    });
}

var WritePostObject = {} || WritePostObject;
WritePostObject.getData = function () {

    
    WritePostObject.AuthorId = $("#authorId").val();

    WritePostObject.Thumbnail = imagebase64;
    WritePostObject.CategoryId = parseInt($("#category").val());

    WritePostObject.Title = $("#title").val();
    WritePostObject.Content = $('#content').val();
    WritePostObject.SubCategoryId = parseInt( $('#subCategory').val());
}

$("#WritePost").click(function (e) {
    e.preventDefault();
    WritePostObject.getData();
    ajaxPost( WritePostObject);
});
$("#thumbnail").change(function (e) {
    e.preventDefault();
    encodeImageFileAsURL(this);
});
var imagebase64 = "";

function encodeImageFileAsURL(element) {
    var file = element.files[0];
    var reader = new FileReader();
    reader.onloadend = function () {
        imagebase64 = reader.result;
    }
    reader.readAsDataURL(file);
}  


//get list category when page is completed load
GetListCategory = function () {
    $.ajax({
        type: "GET",
        url: "Author/GetListCategory",
        dataType: "json",
        success: function (response) {
            var s = '<option value="Select category" selected disabled>Choose Category</option>'
            $('#category').append(s);   
            $.each(response.listCategory, function (i, v) {
                $('#category').append($('<option></option>').val(i+1).text(v.categoryName));
            });
        }
    });
}
$(GetListCategory());


//get list Sub category when category is choosen
GetListSubCategory = function () {
    let id = $('#category').val();
    $.ajax({
        type: "GET",
        url: `author/GetListSubCategory/${id}`,
        dataType: "json",
        success: function (response) {
            $('#subCategory').empty();
            $.each(response.listSubCategory, function (i, v) {
                $('#subCategory').append($('<option></option>').val(i+1).text(v.subCategoryName));

            });
        }
    });
}
$('#category').change(function (e) {
    GetListSubCategory();
});