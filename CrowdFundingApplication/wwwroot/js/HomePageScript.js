//appearance navbar
$(window).scroll(function () {
    if ($(window).scrollTop() > 0) {
        $('.navbar').css('background', '#212529');
    } else {
        $('.navbar').css('background', 'transparent');
    }
})

//autoscroll to info section
function scrollTo(element) {
    window.scroll({
        left: 0,
        top: element.offsetTop,
        behavior: 'smooth'
    });
}

var button = document.getElementById('buttonStart');
var gotoDown = document.getElementById('info');

button.addEventListener('click', () => {
    scrollTo(gotoDown);
});
