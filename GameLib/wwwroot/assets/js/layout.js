"use strict"

// Search

let searchPage = document.getElementById("search");
let body = document.querySelector("body");

document.querySelector("header .user-panel .search .open-close").addEventListener("click", function() {
    searchPage.style.top = 0;
    body.style.overflow = "hidden";
});

document.querySelector("#search .close").addEventListener("click", function() {
    searchPage.style.top = "-100%";
    body.style.overflow = "unset";
});

document.querySelector("#search .search-input i").addEventListener("click", function () {
    search();
});

document.querySelector("#search .search-input input").addEventListener("keydown", function (event) {
    if (event.keyCode === 13) {
        search();
    }
});



// User

document.querySelector("header .user-panel .user i").addEventListener("click", function() {
    let loginRegister = document.querySelector("header .user-panel .user .login-register");

    if (loginRegister.style.opacity == 0) {
        loginRegister.style.opacity = 1;
        loginRegister.style.pointerEvents = "unset";
    }

    else {
        loginRegister.style.opacity = 0;
        loginRegister.style.pointerEvents = "none";
    }
});

document.addEventListener("click", function(event) {
    let target = event.target;
    let loginRegisterParent = document.querySelector("header .user-panel .user");
    let loginRegister = document.querySelector("header .user-panel .user .login-register");

    if (target !== loginRegister && !loginRegisterParent.contains(target)) {
        loginRegister.style.opacity = 0;
        loginRegister.style.pointerEvents = "none";
    }
});



// Logout

if (document.querySelector("header .user-panel .user .login-register").lastElementChild.classList.contains("logout")) {
    document.querySelector("header .user-panel .user .login-register").lastElementChild.addEventListener("click", function () {
        let url = "/Account/Logout";

        fetch(url, {
            method: "POST"
        }).then(function (response) {
            if (response.ok) {
                window.location.reload();
            }
        })
    });
}




// Functions

function search() {
    let searchText = document.querySelector("#search .search-input input");

    if (searchText.value.trim() != "") {
        window.location.assign(`/Search/SearchByGames?searchText=${searchText.value}`);
    }
}