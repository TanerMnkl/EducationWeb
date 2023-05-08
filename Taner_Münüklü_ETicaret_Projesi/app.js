"use strict"

const slides = document.querySelectorAll(".slide");
const btnPrev = document.querySelector("#prev");
const btnNext = document.querySelector("#next");
const sellerPrev = document.getElementById("seller-prev");
const sellerNext = document.getElementById("seller-next");

const firstSellers = document.querySelector(".first-sellers-container");
const secondSellers = document.querySelector(".second-sellers-container");
const card = document.getElementsByClassName("card");
const buttons = document.querySelectorAll('#btn');





let autoSlider = true;
let sliderInterval;
let timerInterval;
let counter;
let intervalTime = 5000



buttons.forEach(button => {
    button.addEventListener('click', e => {
        const key = e.target.id;
        const value = e.target.innerText;
        localStorage.setItem(key, value);
    });
});


for (let i = 0; i < localStorage.length; i++) {
    const key = localStorage.key(i);
    const value = localStorage.getItem(key);
    console.log(key + " = " + value);
}















btnPrev.addEventListener("click", function () {
    prevSlide();
    againInterval();
})

btnNext.addEventListener("click", function () {
    nextSlide();
    againInterval();

})


function prevSlide() {
    let activeSlide = document.querySelector(".active");
    activeSlide.classList.remove("active");
    if (activeSlide.previousElementSibling) {
        activeSlide.previousElementSibling.classList.add("active");

    } else {
        slides[slides.length - 1].classList.add("active")
    }

}

function nextSlide() {
    let activeSlide = document.querySelector(".active");
    activeSlide.classList.remove("active");
    if (activeSlide.nextElementSibling && activeSlide.nextElementSibling.classList.contains("slide")) {
        activeSlide.nextElementSibling.classList.add("active");
    } else {
        slides[0].classList.add("active");
    }
}

function againInterval() {
    if (autoSlider) {
        clearInterval(sliderInterval);
        clearInterval(timerInterval);
        counter = 1;

        sliderInterval = setInterval(nextSlide, intervalTime);
        timerInterval = setInterval(timerInterval, 5000);
    }
}
secondSellers.style.display = "none";
sellerNext.addEventListener("click", () => {
    firstSellers.style.display = "none";
    secondSellers.style.display = "inline-block";
});

sellerPrev.addEventListener("click", () => {
    firstSellers.style.display = "inline-block";
    secondSellers.style.display = "none";
});





