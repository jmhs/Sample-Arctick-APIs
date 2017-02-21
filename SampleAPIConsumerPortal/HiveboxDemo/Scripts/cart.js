update = function () {
    var data = [];
    var items = $(".item").each(function (i, obj) {
        var id = $(this).attr("data-id");
        data[i] = {};
        data[i]["CartItemId"] = id;
        data[i]["ItemId"] = $(this).find("td:first").html();
        data[i]["ItemQty"] = $(this).find("input").val();
    });

    console.log(data);
    jQuery.ajax({
        url: 'cart/update',
        type: 'post',
        data: {"Data" : data},
        //contentType: "application/json",
        //dataType: "json",
        success: function (result, status) {
            console.log(result);
        },
        error: function (xhr, desc, err) {
        }
    });
}

var addItemToCart = function (itemId) {
    if (itemId) {        
        jQuery.ajax({
            url: "cart/add/",
            type: 'post',
            data: {
                "id": itemId
            },            
            success: function (result, status) {
                alert("Item is added to cart!");
            },
            error: function (xhr, desc, err) {
                alert(xhr.responseText);
            }
        });
    }
}

$(document).ready(function () {
    $("#updatebtn").click(function () {
        update();
    })
});