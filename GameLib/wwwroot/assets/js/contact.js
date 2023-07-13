"use strict"

let contactBG = document.querySelector("#contact-bg img");

window.addEventListener("scroll", function() {
    let scrollPosition = window.pageYOffset;

    contactBG.style.transform = `translateY(${scrollPosition * 0.4}px)`;
});