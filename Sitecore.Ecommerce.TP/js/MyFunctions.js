function LoadSublayout(sublayout, placeholder, callback) {
    var id = $("#scID").attr("content");

    $.ajax({
        type: "POST",
        url: "/layouts/sublayouts/MyBasketService.asmx/LoadSublayout",
        data: "{sublayout:'" + sublayout + "', id : '" + id + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: (callback) ? callback : function (msg) {
            placeholder.html(msg.d);
        }
    });
}

var addToShoppingCartIsProcessing = false;

function AddToShoppingCart(productCode) {
    if (!addToShoppingCartIsProcessing) {
        addToShoppingCartIsProcessing = true;
        setTimeout(function () {
            addToShoppingCartIsProcessing = false;
        }, 500);

        $.ajax({
            type: "POST",
            url: "/layouts/sublayouts/MyBasketService.asmx/AddToBasket",
            data: "{productCode:'" + productCode + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                // Replace the div's content with the page method's return.
                LoadSublayout("sublayouts/TechPub SmallCart", null, function (msg) {
                    $("#small_ShoppingCart_container").animate({ opacity: 0.3 }, 200).replaceWith(msg.d);
                    $("#small_ShoppingCart_container").css({ opacity: 0.3 }).animate({ opacity: 1 }, 600);
                });
            }
        });
    }
}