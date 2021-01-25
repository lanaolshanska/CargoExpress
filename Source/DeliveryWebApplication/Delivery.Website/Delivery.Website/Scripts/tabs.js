var currentTab = 0;

$(document).ready(function () {
    showTab(currentTab);
});

function showTab(n) {
    var x = document.getElementsByClassName("tab");
    x[n].style.display = "block";
    if (n == 0) {
        document.getElementById("prevBtn").style.display = "none";
    } else {
        document.getElementById("prevBtn").style.display = "inline";
    }
    if (n == (x.length - 1)) {
        document.getElementById("nextBtn").innerHTML = "Submit";
    } else {
        document.getElementById("nextBtn").innerHTML = "Next";
    }
    fixStepIndicator(n)
}

function nextPrev(n) {
    var x = document.getElementsByClassName("tab");
    if (n == 1 & !validateForm()) {
        return false;
    } else if (currentTab === (x.length - 1) && n === 1) {
        $('form').submit();
    } else {
        x[currentTab].style.display = "none";
        currentTab = currentTab + n;
        showTab(currentTab);
    }
}

function fixStepIndicator(n) {
    var i, x = document.getElementsByClassName("step");
    for (i = 0; i < x.length; i++) {
        x[i].className = x[i].className.replace(" active", "");
    }
    x[n].className += " active";
}

function validateForm() {
    var valid = true;
    var tabs = document.getElementsByClassName("tab");

    var inputField = tabs[currentTab].getElementsByClassName("inputField");
    var errorMessages = tabs[currentTab].getElementsByClassName("errmessage");

    var dropDownField = tabs[currentTab].getElementsByClassName("dropDownField");
    var dropdownErrorMessages = tabs[currentTab].getElementsByClassName("dropdownErr");
    
    for (var i = 0; i < inputField.length; i++) {
        errorMessages[i].className = "errmessage";
    }

    for (var i = 0; i < dropDownField.length; i++) {
        dropdownErrorMessages[i].className = "errmessage dropdownErr";
    }

    for (var i = 0; i < inputField.length; i++) {
        if (inputField[i].value == "0" || inputField[i].value == "") {
            errorMessages[i].className += " visible";
            valid = false;
        }
    }
    if (dropDownField.length != 0) {
        for (var i = 0; i < dropDownField.length; i++) {
            if (dropDownField[i].options[dropDownField[i].selectedIndex].value == 0) {
                dropdownErrorMessages[i].className += " visible";
                valid = false;
            }
        }
    }
    if (valid) {
        document.getElementsByClassName("step")[currentTab].className += " finish";
    }
    return valid;
}
