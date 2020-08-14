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

WritePostObject.getData = function () {
    
    WritePostObject.link = "";
    WritePostObject.authorId = $("#authorId").val();
    WritePostObject.thumbnail = $("#thumbnail").val();
    WritePostObject.subCategoryId = parseInt( $("#subCategoryId").val());
    WritePostObject.title = $("#title").val();
    WritePostObject.content = CKEDITOR.instances['content'].getData();;
}