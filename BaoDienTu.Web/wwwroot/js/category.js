var category = {} || category;

category.drawTable = function () {
    $.ajax({
        url: "/Category/Gets",
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#tbCategory tbody').empty();
            $.each(data.categorys, function (i, v) {
                $('#tbCategory tbody').append(
                    `<tr>
                        <td>${v.categoryId}</td>
                        <td>${v.categoryName}</td>
                         <td><a href="/SubCategory/Index/${v.categoryId}" title="Sub Category list">${v.soLuong}</a></td>
                        <td>
                          <a href="javascripts:;" onclick="category.get(${v.categoryId})" class="btn btn-success">Edit</a> 
                            <a href="javascripts:;" onclick="category.delete(${v.categoryId})" class="btn btn-danger">Delete</a>
                        </td>
                    </tr>`
                );
            });
        }
    });

};

category.openAddEditCategory = function () {
    category.reset();
    $('#addEditCategory').appendTo("body").modal('show');
};


category.delete = function (id) {
    bootbox.confirm({
        title: "Delete category?",
        message: "Do you want to delete this category.",
        buttons: {
            cancel: {
                label: '<i class="fa fa-times"></i> No'
            },
            confirm: {
                label: '<i class="fa fa-check"></i> Yes'
            }
        },
        callback: function (result) {
            if (result) {
                $.ajax({
                    url: `/Category/Delete/${id}`,
                    method: "GET",
                    dataType: "json",
                    success: function (data) {
                        bootbox.alert(data.categorys.message);
                        category.drawTable();
                    }
                });
            }
        }
    });
}

category.get = function (id) {
    $.ajax({
        url: `/Category/Get/${id}`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#CategoryName').val(data.categorys.categoryName);
            $('#CategoryId').val(data.categorys.categoryId);
            $('#addEditCategory').modal('show');
        }
    });
}



category.reset = function () {
    $('#CategoryName').val("");
    $('#CategoryId').val(0);
}

category.save = function () {
    var saveObj = {};
    saveObj.CategoryName = $('#CategoryName').val();
    saveObj.CategoryId = parseInt($('#CategoryId').val());
    $.ajax({
        url: `/Category/Create/`,
        method: "POST",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(saveObj),
        success: function (data) {
            $('#addEditCategory').modal('hide');
            bootbox.alert(data.categorys.message);
            category.drawTable();
        }
    });
}

category.deleteAll = function () {
    var checked = $('input[type = "checkbox"]:checked');
    if (checked.length > 0) {
        checked.category.delete();
    } else {
        checked.category.reset();
    }
}
category.init = function () {
    category.drawTable();
};

$(document).ready(function () {
    category.init();
});