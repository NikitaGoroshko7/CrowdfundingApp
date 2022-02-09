/* Card Number Spacing */
$('#card-number').on('keypress change blur', function () {
    $(this).val(function (index, value) {
        return value.replace(/[^a-z0-9]+/gi, '').replace(/(.{4})/g, '$1 ');
    });
});

$('#card-number').on('copy cut paste', function () {
    setTimeout(function () {
        $('#card-number').trigger("change");
    });
});

/* Month and Year */
$('#card-exp').on('input', function () {
    var curLength = $(this).val().length;
    if (curLength === 2) {
        var newInput = $(this).val();
        newInput += '/';
        $(this).val(newInput);
    }
});

/* Validation for creadit card*/
$(document).ready(function () {
    $("#card-ccv").keypress(function (e) {
        //if the letter is not digit don't type anything
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            return false;
        }
    });

    $("#card-number").keypress(function (e) {
        //if the letter is not digit don't type anything
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            return false;
        }
    });

    $("#card-exp").keypress(function (e) {
        //if the letter is not digit don't type anything
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            return false;
        }
    });

    $(function () {
        $('#card-name').keydown(function (e) {
            //if the digit don't type anything
            if (e.shiftKey || e.ctrlKey || e.altKey) {
                e.preventDefault();
            } else {
                var key = e.keyCode;
                if (!((key == 8) || (key == 32) || (key == 46) || (key >= 35 && key <= 40) || (key >= 65 && key <= 90))) {
                    e.preventDefault();
                }
            }
        });
    });
});