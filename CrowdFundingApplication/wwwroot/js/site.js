var change_button = function (checkbox, button) {
    var btn = document.getElementById(button);

    if (checkbox.checked == true) {
        btn.disabled = "";
    } else {
        btn.disabled = "disabled";
    }
}

function showCount2() {
    var numbFromResulid = 125 * 1;
    resultid.innerHTML = numbFromResulid;
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

CKEDITOR.replace('FullDescription');

$("#submitBotton").bind("click", function () {
    if ($("#myform").valid()) {
        alert("Проект был успешно создан и отправлен на модерацию! Статус проекта можно просмотреть в профиле.");
    }
});