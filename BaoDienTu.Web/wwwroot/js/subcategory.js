var sub = {} || sub;
var id = 0;
sub.drawTable = function () {
    $.ajax({
        url: `/SubCategory/GetSubByCategoryId/${id}`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#tbSub tbody').empty();
            $.each(data.subs, function (i, v) {
                $('#tbSub tbody').append(
                    `<tr>
                        <td>${v.subCategoryId}</td>
                        <td>${v.subCategoryName}</td>
                         <td>${v.categoryId}</td>
                        <td>
                          <a href="javascripts:;" onclick="sub.get(${v.subCategoryId})" class=" text-success"><i class="fa fa-edit"></i></a> 
                            <a href="javascripts:;" onclick="sub.delete(${v.subCategoryId})" class=" text-danger"><i class="fa fa-trash"></i></a>
                        </td>
                    </tr>`
                );
            });
        }
    });

};

sub.openAddEditSub = function () {
    sub.reset();
    $('#addEditSub').appendTo("body").modal('show');
};


sub.delete = function (id) {
    bootbox.confirm({
        title: "Delete Subcategory?",
        message: "Do you want to delete this Subcategory.",
        buttons: {
            cancel: {
                label: '<i class="fa fa-times "></i> No'
            },
            confirm: {
                label: '<i class="fa fa-check "></i> Yes'
            }
        },
        callback: function (result) {
            if (result) {
                $.ajax({
                    url: `/SubCategory/Delete/${id}`,
                    method: "GET",
                    dataType: "json",
                    success: function (data) {
                        bootbox.alert(data.subs.message);
                        sub.drawTable();
                    }
                });
            }
        }
    });
}


sub.get = function (id) {
    $.ajax({
        url: `/SubCategory/Get/${id}`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#SubCategoryName').val(data.subs.subCategoryName);
            $('#Category').val(data.subs.categoryId);
            $('#SubCategoryId').val(data.subs.subCategoryId);
            //$('#addEditBooks').find('.modal-title').text('Edit sUB')
            $('#addEditSub').modal('show');
        }
    });
}

sub.reset = function () {
    $('#SubCategoryName').val("");
    $('#SubCategoryId').val(0);
    $('#Category').val("0");
}
var a; 
sub.save = function () {
    if ($('#SubCategoryId').val() == '0') {
        var saveObj = {};
        saveObj.SubcategoryName = $('#SubCategoryName').val();
        saveObj.categoryId = parseInt($('#Category').val());
       a = saveObj;
        $.ajax({
            url: `/SubCategory/Create/`,
            method: "POST",
            dataType: "json",
            contentType: "application/json",
            data: JSON.stringify(saveObj),
            success: function (data) {
                $('#addEditSub').modal('hide');
                bootbox.alert(data.subs.message);
                sub.drawTable();
            }
        });
    }
    else {
        var saveObj = {};
        saveObj.SubcategoryName = $('#SubCategoryName').val();
        saveObj.categoryId = parseInt($('#Category').val());
        saveObj.SubCategoryId = parseInt($('#SubCategoryId').val());
        a = saveObj;
        $.ajax({
            url: `/SubCategory/Update/` + saveObj.SubCategoryId,
            method: "POST",
            dataType: "json",
            contentType: "application/json",
            data: JSON.stringify(saveObj),
            success: function (data) {
                $('#addEditSub').modal('hide');
                bootbox.alert(data.subs.message);
                sub.drawTable();
            }
        });
    }
}
     

sub.initCategory = function () {
    $.ajax({
        url: "/Category/Gets",
        method :"GET",
        dataType : "json",
        success : function (data) {
            $('#Category').empty();
            $.each(data.categorys, function (i, v) {
                $('#Category').append(`<option value ="${v.categoryId}">${v.categoryName}</option>`)
            });
        }
    });
}


//sub.deleteAll = function () {
//    var checked = $('input[type = "checkbox"]:checked');
//    if (checked.length > 0) {
//        checked.category.delete();
//    } else {
//        checked.category.reset();
//    }
//}
sub.init = function () {
    sub.drawTable();
    sub.initCategory();
};

$(document).ready(function () {
    id = $("#CategoryId").val();
    sub.init();

});