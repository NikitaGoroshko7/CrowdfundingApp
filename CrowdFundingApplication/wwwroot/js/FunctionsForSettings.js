var loadFile = function (event) {
    var image = document.getElementById('output');
    image.src = URL.createObjectURL(event.target.files[0]);
};

var deleteFile = function () {
    var image = document.getElementById('output');
    image.src = "";
}

function showCount() {
    result.innerHTML = 100;
    result.innerHTML -= sms.value.length;
}

sms.onkeyup = sms.oninput = showCount;
sms.onpropertychange = function () {
    if (event.propertyName == "value") showCount();
}
sms.oncut = function () {
    setTimeout(showCount, 0);
};

var message = function () {
    alert("Данные были успешно обновлены!");
}