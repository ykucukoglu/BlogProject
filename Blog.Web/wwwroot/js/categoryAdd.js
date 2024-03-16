$(document).ready(function () {
    $("#btnSave").click(function (event) {
        event.preventDefault();
        let addUrl = app.Urls.categoryAddUrl;
        let redirectUrl = app.Urls.articleAddUrl;
        let categoryAddDto = {
            Name: $("input[id=categoryName]").val()
        }
        let jsonData = JSON.stringify(categoryAddDto);

        $.ajax({
            url: addUrl,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: jsonData,
            success: function (data) {
                setTimeout(function () { window.location = redirectUrl }, 1500);
            },
            error: function () {
                toast.error("Bir hata oluþtu", "Hata");
            }
        });
    });
});