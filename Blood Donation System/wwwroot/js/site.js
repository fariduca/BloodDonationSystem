// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

window.onscroll = function () { myFunction(); }
var navbar = document.getElementById('nav');
var sticky = navbar.offsetTop;
var homeLink = document.getElementById('homeLink');

function myFunction() {
    if (window.pageYOffset >= sticky) {
        navbar.classList.add("sticky");
        homeLink.href = "#home-section";
        navbar.classList.add('bg-light');
    } else {
        navbar.classList.remove("sticky");
        navbar.classList.remove('bg-light');
        homeLink.href = "/";
    }
}
