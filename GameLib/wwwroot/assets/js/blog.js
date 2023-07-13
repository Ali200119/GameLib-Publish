"use strict"

// Fav-Blog Parallax

let favBlogBG = document.querySelector("#fav-blog img");

window.addEventListener("scroll", function() {
    let scrollPosition = window.pageYOffset;

    favBlogBG.style.transform = `translateY(${scrollPosition * 0.4}px)`;
});



//Search

document.querySelector("#panel .search .search-input i").addEventListener("click", function () {
    search();
});

document.querySelector("#panel .search .search-input input").addEventListener("keydown", function (event) {
    if (event.keyCode === 13) {
        search();
    }
});





// Functions

function search() {
    let searchText = document.querySelector("#panel .search .search-input input");

    if (searchText.value.trim() != "") {
        window.location.assign(`/Search/SearchByBlogs?searchText=${searchText.value}`);
    }
}