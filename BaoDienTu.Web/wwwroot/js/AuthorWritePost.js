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
WritePostObject.getData = function () {
    
    WritePostObject.Link = "";
    WritePostObject.AuthorId = $("#authorId").val();

    WritePostObject.Thumbnail = imagebase64;
    WritePostObject.SubCategoryId = parseInt($("#subCategoryId").val());
   
    WritePostObject.Title = $("#title").val();
    WritePostObject.Content = CKEDITOR.instances['content'].getData();;
}



