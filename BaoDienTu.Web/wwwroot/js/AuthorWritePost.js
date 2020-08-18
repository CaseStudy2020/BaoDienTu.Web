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
    
    WritePostObject.link = "";
    WritePostObject.authorId = $("#authorId").val();

    WritePostObject.thumbnail = imagebase64;
    WritePostObject.subCategoryId = parseInt( $("#subCategoryId").val());
    WritePostObject.title = $("#title").val();
    WritePostObject.content = CKEDITOR.instances['content'].getData();;
}



