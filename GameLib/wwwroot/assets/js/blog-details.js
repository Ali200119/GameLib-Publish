"use strict"

// Blog Background Parallax

let blogBG = document.querySelector("#blog-bg img");

window.addEventListener("scroll", function() {
    let scrollPosition = window.pageYOffset;

    blogBG.style.transform = `translateY(${scrollPosition * 0.4}px)`;
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



// Comments' Count

commentsCount(document.querySelector("#title .content .date-author-comments").lastElementChild.firstElementChild);
commentsCount(document.querySelector("#blog-content .comments .title span"));



// Check Comment

document.querySelector("#blog-content .comments form textarea").addEventListener("keyup", function () {
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

if (document.querySelector("#blog-content .comments .items").children.length != 0) {
    let removeCommentBtns = document.querySelectorAll("#blog-content .comments .items .item i");

    for (const removeBtn of removeCommentBtns) {
        if (removeBtn.classList.contains("delete")) {
            removeBtn.addEventListener("click", function () {
                let commentId = this.getAttribute("data-commentId");
                let comment = this.parentNode;
                let url = `/Blog/DeleteComment?id=${commentId}`;

                fetch(url, {
                    method: "POST"
                }).then(function (response) {
                    if (response.ok) {
                        comment.remove();
                        commentsCount(document.querySelector("#title .content .date-author-comments").lastElementChild.firstElementChild);
                        commentsCount(document.querySelector("#blog-content .comments .title span"));
                    }
                });
            });
        }
    }
}





// Functions

function search() {
    let searchText = document.querySelector("#panel .search .search-input input");

    if (searchText.value.trim() != "") {
        window.location.assign(`/Search/SearchByBlogs?searchText=${searchText.value}`);
    }
}

function commentsCount(element) {
    let count = document.querySelector("#blog-content .comments .items").children.length;

    element.innerText = count;
}