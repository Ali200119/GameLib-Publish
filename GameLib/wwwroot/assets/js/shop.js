"use strict"

// Sort

document.querySelector("#games .sort select").addEventListener("change", function () {
    let pattern = this.value;

    let url = `/Shop/Sort?pattern=${pattern}`;

    fetch(url, {
        method: "GET"
    }).then(function (response) {
        if (response.ok) {
            return response.text();
        }
    }).then(function (data) {
        document.querySelector("#games .items").innerHTML = data;
    });
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



// Filter by Platform

let platforms = document.querySelectorAll("#panel .platforms .platform .name");

for (const platform of platforms) {
    platform.addEventListener("click", function () {
        let id = parseInt(this.getAttribute("data-id"));

        let url = `/Shop/FilterByPlatform?platformId=${id}`;

        fetch(url, {
            method: "GET"
        }).then(function (response) {
            if (response.ok) {
                return response.text();
            }
        }).then(function (data) {
            document.querySelector("#games .items").innerHTML = data;
        });
    });
}



// Filter by Genre

let genres = document.querySelectorAll("#panel .genres .items .genre");

for (const genre of genres) {
    genre.addEventListener("click", function () {
        let id = parseInt(this.getAttribute("data-id"));

        let url = `/Shop/FilterByGenre?genreId=${id}`;

        fetch(url, {
            method: "GET"
        }).then(function (response) {
            if (response.ok) {
                return response.text();
            }
        }).then(function (data) {
            document.querySelector("#games .items").innerHTML = data;
            document.querySelector("#games .sort select").firstElementChild.setAttribute("selected", "selected");
        });
    });
}





// Functions

function search() {
    let searchText = document.querySelector("#panel .search .search-input input");

    if (searchText.value.trim() != "") {
        window.location.assign(`/Search/SearchByGames?searchText=${searchText.value}`);
    }
}