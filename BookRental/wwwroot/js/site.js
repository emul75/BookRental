// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function loadBookListView() {
    $.ajax({
        url: "/api/book/all",
        type: "GET",
        success: function (data) {
            document.getElementById("mainView").innerHTML = data;
        },
        error: function (error) {
            alert(error.responseText);
            console.log(error);
        }
    });
}