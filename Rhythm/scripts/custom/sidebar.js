function GetData() {

    function getSideBar() {

        $.ajax({
            type: "GET",
            url: "http://localhost:52840/RecentsController/RecentCategories",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {

            },
            error: function (data, err, mess) {

                console.log("Error: " + err + ", message: " + mess);

            }
        })
    }

    return ({
        init: function () {
            getSideBar();
        }
    });
}

$(document).ready(function () {
    var getData = GetData(".side.bar").init();
});