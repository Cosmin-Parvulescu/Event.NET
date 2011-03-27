function getOkMark() {
    var okMark = document.createElement('img');
    okMark.border = 0;
    okMark.src = 'gfx/greenCheck.png';
    okMark.alt = 'green OK checkmark';
    return okMark;
}

function getNotOkMark() {
    var okMark = document.createElement('img');
    okMark.border = 0;
    okMark.src = 'gfx/redCheck.png';
    okMark.alt = 'red NOT OK checkmark';
    return okMark;
}

function getLoadingIcon() {
    var loadingIcon = document.createElement('img');
    loadingIcon.border = 0;
    loadingIcon.src = 'gfx/ajaxloader.gif';
    loadingIcon.alt = 'valdation on server';
    return loadingIcon;
}

function clearChildren(element) {
    while (element.hasChildNodes()) {
        element.removeChild(element.firstChild);
    }
}

function validate(sender, canBeEmpty) {
    //get dom elements
    var length = sender.parentNode.parentNode.cells.length;
    var validationOutputCell = sender.parentNode.parentNode.cells[length-1];

    //no matter what we are going to append a new validation icon so we remove any previous ones
    clearChildren(validationOutputCell);

    //first we need to do the client side validation to try and save a request.
    //no fields are allowed to be empty so we always check for this
    if (!sender.value || sender.value == '') {
        if (canBeEmpty) {
            return true;
        }
        else {
            validationOutputCell.appendChild(getNotOkMark());
            return false;
        }
    }

    //now we need to do validation dependent on what field it id
    var validationResult = true;
    switch (sender.getAttribute('validation')) {
        case 'lettersOnly':
            validationResult = validateLetters(sender.value);
            break;
        case 'email':
            validationResult = validateEmail(sender.value);
            break;
        case 'numbersOnly':
            validationResult = validateNumbers(sender.value);
            break;
        case 'username':
            validationResult = validateUsername(sender.value);
            break;
        case 'password':
            validationResult = validatePassword(sender.value);
            break;
        case 'passwordConfirm':
            validationResult = validatePasswordConfirmation(sender.value);
            break;
        default:
            //do nuffin
    }

    if (validationResult) {
        validationOutputCell.appendChild(getOkMark());
    } else {
        validationOutputCell.appendChild(getNotOkMark());
    }
    return false;
}

function validateEmail(stringToValidate) {
    var regExp = /^\s*[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}\s*$/;
    return regExp.test(stringToValidate);
}

function validateNumbers(stringToValidate) {
    var regExp = /^\s*\d+\s*$/;
    return regExp.test(stringToValidate);
}

function validateLetters(stringToValidate) {
    var regExp = /^\s*([A-Za-z]|\s)+[A-Za-z]+\s*$/;
    return regExp.test(stringToValidate);
}

function validateUsername(stringToValidate) {
    var regExp = /^\s*[A-Za-z]+[A-Za-z0-9]*\s*$/;
    return regExp.test(stringToValidate);
}

function validatePassword(stringToValidate) {
    var regExp = /^[A-Za-z0-9]{8,}$/;
    return regExp.test(stringToValidate);
}

function validatePasswordConfirmation(stringToValidate) {
    var passwordField = document.getElementById('password');
    if (passwordField == null) {
        passwordField = document.getElementById('Password');
    }

    var password = passwordField.value;
    if (password != stringToValidate) {
        return false;
    }
    return true;
}