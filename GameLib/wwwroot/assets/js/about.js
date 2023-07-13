"use strict"

let aboutBG = document.querySelector("#image img");
let aboutBGContainer = document.getElementById("image");
let containerWidth = aboutBGContainer.offsetWidth;
let containerHeight = aboutBGContainer.offsetHeight;

aboutBGContainer.addEventListener("mousemove", function (event) {
    const mouseX = event.pageX - this.offsetLeft;
    const mouseY = event.pageY - this.offsetTop;

    const xPercentage = (mouseX / containerWidth - 0.5) * 45;
    const yPercentage = (mouseY / containerHeight - 0.5) * 45;

    aboutBG.style.transform = `translate(${xPercentage}px, ${yPercentage}px)`;
});

aboutBGContainer.addEventListener('mouseleave', function () {
    aboutBG.style.transform = 'translate(0, 0)';
});