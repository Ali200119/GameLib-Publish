"use strict"

// Header

window.addEventListener("scroll", function () {
    let scrollPosition = pageYOffset;

    if (scrollPosition > 156) {
        document.querySelector("header").style.backgroundColor = "#242230";
        document.querySelector("header").style.backdropFilter = "unset";
    }

    else {
        document.querySelector("header").style.backgroundColor = "transparent";
        document.querySelector("header").style.backdropFilter = "blur(3px)";
    }
});



// Cover Parallax

let cover = document.querySelector("#cover img");

window.addEventListener("scroll", function () {
    let scrollPosition = window.pageYOffset;

    cover.style.transform = `translateY(${scrollPosition * 0.4}px)`;
});



// Add to Cart

if (document.querySelector("#cover-key-art-options #key-art-options .options").lastElementChild.classList.contains("add-to-cart")) {
    document.querySelector("#cover-key-art-options #key-art-options .options button").addEventListener("click", function () {
        let alert = document.getElementById("game-added-alert");
        let gameName = this.parentNode.parentNode.firstElementChild.innerText;
        let gameId = parseInt(this.getAttribute("data-gameId"));
        let platform = this.parentNode.previousElementSibling.previousElementSibling.firstElementChild.value;
        let userId = this.getAttribute("data-userId");

        let url = `/Shop/AddToCart?gameId=${gameId}&platform=${platform}&userId=${userId}`;

        fetch(url, {
            method: "POST"
        }).then(function (response) {
            if (response.ok) {
                alert.innerText = `${gameName} has been added to the cart`;
                alert.style.opacity = 1;
                alert.style.pointerEvents = "unset";

                setTimeout(function () {
                    alert.style.opacity = 0;
                    alert.style.pointerEvents = "none";
                }, 3000);
            }
        });
    });
}

if (document.querySelector("#cover-key-art-options #key-art-options .options").lastElementChild.classList.contains("coming-soon")) {
    document.querySelector("#cover-key-art-options #key-art-options .options button").addEventListener("click", function () {
        Swal.fire(
            'Coming soon',
            `${this.parentNode.parentNode.firstElementChild.innerText} hasn't been released yet`,
            'info'
        )
    });
}

if (document.querySelector("#cover-key-art-options #key-art-options .options").lastElementChild.classList.contains("login")) {
    document.querySelector("#cover-key-art-options #key-art-options .options button").addEventListener("click", function () {
        window.location.assign("/Account/Login");
    });
}



// Full Screen Screenshot

let screenshots = document.querySelectorAll("#visuals .screenshots .screenshot");

for (const screenshot of screenshots) {
    screenshot.addEventListener("click", function () {
        document.getElementById("full-screen").style.display = "flex";
        document.querySelector("body").style.overflow = "hidden";

        let image = this.firstElementChild.getAttribute("src");
        document.querySelector("#full-screen .image img").setAttribute("src", image);
    });
}

document.querySelector("#full-screen i").addEventListener("click", function () {
    document.getElementById("full-screen").style.display = "none";
    document.querySelector("body").style.overflow = "unset";

    document.querySelector("#full-screen .image img").removeAttribute("src");
});



// Countdown

if (document.getElementById("countdown").lastElementChild.classList.contains("time")) {
    let days = document.querySelector("#countdown .time .days span");
    let hours = document.querySelector("#countdown .time .hours span");
    let minutes = document.querySelector("#countdown .time .minutes span");
    let seconds = document.querySelector("#countdown .time .seconds span");
    let releaseDate = document.querySelector("#countdown .time");

    let endTime = new Date(`${releaseDate.getAttribute("data-day")} ${releaseDate.getAttribute("data-month")} ${releaseDate.getAttribute("data-year")} 00:00:00`)

    function updateCountdownTime() {
        let currentTime = new Date();
        let diff = endTime - currentTime;
        let day = Math.floor(diff / 1000 / 60 / 60 / 24);
        let hour = Math.floor(diff / 1000 / 60 / 60) % 24;
        let min = Math.floor(diff / 1000 / 60) % 60;
        let sec = Math.floor(diff / 1000) % 60;
        days.innerHTML = day < 10 ? `0` + day : day;
        hours.innerHTML = hour < 10 ? `0` + hour : hour;
        minutes.innerHTML = min < 10 ? `0` + min : min;
        seconds.innerHTML = sec < 10 ? `0` + sec : sec;
    }

    setInterval(updateCountdownTime, 1000);
}



// Appearance Effect

window.addEventListener("scroll", function () {
    let scrollPosition = window.pageYOffset;

    if (scrollPosition > 265) {
        appearance(document.getElementById("visuals"));
    }

    if (scrollPosition > 1800) {
        appearance(document.getElementById("comments"));
    }
});



// Comments' Count

commentsCount();



// Check Comment

document.querySelector("#comments form textarea").addEventListener("keyup", function () {
    if (this.value != "") {
        this.nextElementSibling.style.opacity = 1;
        this.nextElementSibling.style.pointerEvents = "unset";
    }

    else {
        this.nextElementSibling.style.opacity = 0;
        this.nextElementSibling.style.pointerEvents = "none";
    }
});



// Delete Comment

if (document.querySelector("#comments .items").children.length != 0) {
    let removeCommentBtns = document.querySelectorAll("#comments .items .item i");

    for (const removeBtn of removeCommentBtns) {
        if (removeBtn.classList.contains("delete")) {
            removeBtn.addEventListener("click", function () {
                let commentId = this.getAttribute("data-commentId");
                let comment = this.parentNode;
                let url = `/Shop/DeleteComment?id=${commentId}`;

                fetch(url, {
                    method: "POST"
                }).then(function (response) {
                    if (response.ok) {
                        comment.remove();
                        commentsCount();
                    }
                });
            });
        }
    }
}





// Functions

function appearance(element) {
    element.style.transform = "unset";
    element.style.opacity = 1;
    element.style.pointerEvents = "unset";
}

function commentsCount() {
    let count = document.querySelector("#comments .items").children.length;

    document.querySelector("#comments .title span").innerText = count;
}