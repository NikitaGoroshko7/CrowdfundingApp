var change_button = function (checkbox, button) {
    var btn = document.getElementById(button);

    if (checkbox.checked == true) {
        btn.disabled = "";
    } else {
        btn.disabled = "disabled";
    }
}

function showCount2() {
    resultid.innerHTML = 125;
    resultid.innerHTML -= sms2.value.length;
}

sms2.onkeyup = sms2.oninput = showCount2;
sms2.onpropertychange = function () {
    if (event.propertyName == "value") showCount2();
}
sms2.oncut = function () {
    setTimeout(showCount, 0);
};

var loadFile = function (event) {
    var image = document.getElementById('output');
    image.src = URL.createObjectURL(event.target.files[0]);
};