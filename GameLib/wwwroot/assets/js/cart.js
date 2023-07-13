"use strict"

// Check Cart

if (document.querySelector("#devide #games table tbody").children.length == 0) {
    clearCart();
}



// Increase Count

let increaseCountBtns = document.querySelectorAll("#devide #games table tbody tr .count .increase");

for (const increase of increaseCountBtns) {
    increase.addEventListener("click", function () {
        let count = this.previousElementSibling;
        let gameId = this.getAttribute("data-gameId");
        let userId = this.getAttribute("data-userId");
        let url = `/Cart/IncreaseGameCount?gameId=${gameId}&userId=${userId}`

        fetch(url, {
            method: "POST"
        }).then(function (response) {
            if (response.ok) {
                count.innerText++;

                subtotal();
                total();
            }
        })
    });
}



// Decrease Count

let decreaseCountBtns = document.querySelectorAll("#devide #games table tbody tr .count .decrease");

for (const decrease of decreaseCountBtns) {
    decrease.addEventListener("click", function () {
        let game = this.parentNode.parentNode.parentNode;
        let count = this.nextElementSibling;
        let gameId = this.getAttribute("data-gameId");
        let userId = this.getAttribute("data-userId");

        if (parseInt(this.nextElementSibling.innerText) > 1) {
            let url = `/Cart/DecreaseGameCount?gameId=${gameId}&userId=${userId}`

            fetch(url, {
                method: "POST"
            }).then(function (response) {
                if (response.ok) {
                    count.innerText--;

                    subtotal();
                    total();
                }
            })
        }

        else {
            let url = `/Cart/RemoveGameFromCart?gameId=${gameId}&userId=${userId}`;

            fetch(url, {
                method: "POST"
            }).then(function (response) {
                if (response.ok) {
                    game.remove();
                    total();

                    if (document.querySelector("#devide #games table tbody").children.length == 0) {
                        clearCart();
                    }
                }
            })
        }
    });
}



// Clear Cart

document.querySelector("#devide #games .clear").addEventListener("click", function () {
    let userId = this.getAttribute("data-userId");
    let url = `/Cart/ClearCart?userId=${userId}`;

    fetch(url, {
        method: "POST"
    }).then(function (response) {
        if (response.ok) {
            clearCart();
        }
    });
});



// Remove Game From Cart

let removeBtn = document.querySelectorAll("#devide #games table tbody tr .name i");

for (const remove of removeBtn) {
    remove.addEventListener("click", function () {
        let game = this.parentNode.parentNode;
        let gameId = this.getAttribute("data-gameId");
        let userId = this.getAttribute("data-userId");
        let url = `/Cart/RemoveGameFromCart?gameId=${gameId}&userId=${userId}`

        fetch(url, {
            method: "POST"
        }).then(function (response) {
            if (response.ok) {
                game.remove();

                if (document.querySelector("#devide #games table tbody").children.length == 0) {
                    clearCart();
                }


                total();
            }
        })
    });
}



// Subtotal

subtotal();



// Total

total();



// Checkout

document.querySelector("#checkout button").addEventListener("click", function () {
    let userId = this.getAttribute("data-userId");
    let total = parseFloat(document.querySelector("#checkout .total .price").lastElementChild.innerText.replace(",", "."));

    window.location.assign(`/Cart/Checkout?userId=${userId}&total=${total}`);
});





// Functions

function total() {
    let total = document.querySelector("#devide #checkout .total .price");
    let totalSum = 0;

    for (const price of document.querySelectorAll("#devide #games table tbody tr .subtotal :last-child")) {
        totalSum += parseFloat(price.innerText.replace(",", "."));
    }

    total.lastElementChild.innerText = totalSum.toFixed(2).toString().replace(".", ",");
}

function subtotal() {
    let subtotal = document.querySelectorAll("#devide #games table tbody tr .subtotal :last-child");
    
    for (const item of subtotal) {
        item.innerText = (parseFloat(item.parentNode.previousElementSibling.previousElementSibling.lastElementChild.innerText.replace(",", ".")) * parseInt(item.parentNode.previousElementSibling.firstElementChild.children[1].innerText)).toFixed(2).toString().replace(".", ",");
    }
}

function clearCart() {
    document.getElementById("games").style.display = "none";
    document.getElementById("checkout").style.display = "none";
    document.querySelector("#devide .empty").style.display = "unset";
}