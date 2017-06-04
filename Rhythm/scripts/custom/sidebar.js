function GetData() {

    function getSideBar() {

        $.ajax({
            type: "GET",
            url: "/Recents/RecentCategories",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                console.log(data);
                //recentCategories(data);
            },
            error: function (data, err, mess) {
                console.log(data.responseText);
                recentCategories(data.responseText);
                console.log("Error: " + err + ", message: " + mess);

            }
        })
    }

    function recentCategories(data) {
        for (var i = 0; i < data.length; i++) {
            var txt = '<li> <a href="@Url.Action("Category", "Search", new { id = category.Id, Name = category.Name })" title="@category.Name">@category.Name</a> <small> - @category.CountCategory </small> <div class="fa fa-examples"> <i class="fa fa-fw">&#xf0a5</i> </div> </li>';

            document.getElementById("recentCategories").innerHTML = txt;
        }
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