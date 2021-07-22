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

function loadAddBookView() {
    $.ajax({
        url: "/api/book/add",
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

function AddBook() {
    let newBook = {
        Title: document.getElementById("title-input").value,
        Author: document.getElementById("author-input").value,
        Category: document.getElementById("category-input").value,
        Published: document.getElementById("date-input").value
    }
    $.ajax({
        url: "/api/book/add",
        type: "POST",
        data: newBook,
        success: function () {
            loadBookListView();
        },
        error: function (error) {
            alert(error.responseText);
            console.log(error);
        }
    });
}

function deleteBook(id) {
    $.ajax({
        url: "/api/book",
        type: "DELETE",
        data: {id: id},
        success: function (data) {
            loadBookListView()
        },
        error: function (error) {
            alert(error.responseText);
            console.log(error);
        }
    });
}

function loadAddNewClientView() {
    $.ajax({
        url: "/api/client/add",
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

function AddClient() {
    let newClient = {
        FirstName: document.getElementById("firstname-input").value,
        LastName: document.getElementById("lastname-input").value,
        ContactNumber: document.getElementById("contact-number-input").value
    }
    $.ajax({
        url: "/api/client/add",
        type: "POST",
        data: newClient,
        success: function () {
            loadBookListView();
        },
        error: function (error) {
            alert(error.responseText);
            console.log(error);
        }
    });
}

function loadUpdateBookView(id) {
    $.ajax({
        url: "/api/book/update",
        type: "GET",
        data: {id:id},
        success: function (data) {
            document.getElementById("mainView").innerHTML = data;
        },
        error: function (error) {
            alert(error.responseText);
            console.log(error);
        }
    });
}

function UpdateBook(id) {
    let updatedBook = {
        Id: id,
        Title: document.getElementById("title-input").value,
        Author: document.getElementById("author-input").value,
        Category: document.getElementById("category-input").value,
        Published: document.getElementById("date-input").value
    }
    $.ajax({
        url: "/api/book/update",
        type: "POST",
        data: updatedBook,
        success: function () {
            loadBookListView();
        },
        error: function (error) {
            alert(error.responseText);
            console.log(error);
        }
    });
}