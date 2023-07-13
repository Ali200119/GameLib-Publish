"use strict"

// Hide and Unhide Password

let showHidePassword = document.querySelectorAll("#inputs form .inputBox i");

showHidePassword.forEach(element => {
    element.addEventListener("click", function () {
        if (this.classList.contains("fa-eye")) {
            this.classList.remove("fa-eye");
            this.classList.add("fa-eye-slash");
            this.previousElementSibling.setAttribute("type", "text");
        }
    
        else {
            this.classList.remove("fa-eye-slash");
            this.classList.add("fa-eye");
            this.previousElementSibling.setAttribute("type", "password");
        }
    });
});