// Company form validation
const reportAddressInput = document.getElementById("reportAddressInput");
const reportCoordinatesInput = document.getElementById("reportCoordinatesInput");
const reportDescriptionInput = document.getElementById("reportDescriptionInput");
const reportEmailInput = document.getElementById("emailInput");
const reportPhoneInput = document.getElementById("phoneInput");
const reportSubmitButton = document.getElementById("reportSubmitBtn");
const errorMessageContainer = document.getElementById("reportErrorMessage");
const ogBorderColour = reportAddressInput.style.borderColor;

let validAddress;
let validDescription;
let validPhone;
let vaildEmail;

//disables form from posting if inputs are invalid
function ValidateForm(event) {
    validAddress = reportAddressInput.value.length > 0 && reportAddressInput.value != " ";
    validDescription = reportDescriptionInput.value != "";
    validEmail = emailRegex.test(reportEmailInput.value) || reportEmailInput.value == "";
    validPhone = phoneRegex.test(reportPhoneInput.value) || reportPhoneInput.value == "";
    SetInputsValid();
    if (!validAddress || !validDescription || !validEmail || !validPhone) {
        event.preventDefault();
        SetInputsInvalid();
    }
}

//sets invalid fields border to error colour and adds error message
function SetInputsInvalid() {
    if (!validAddress) {
        reportAddressInput.style.borderColor = borderErrorColor;
        errorMessageContainer.innerText += "Please enter the address\n";
    }
    if (!validDescription) {
        reportDescriptionInput.style.borderColor = borderErrorColor;
        errorMessageContainer.innerText += "Please enter a description\n";
    }
    if (!validEmail) {
        reportEmailInput.style.borderColor = borderErrorColor;
        errorMessageContainer.innerText += "Please enter a valid email\n";
    }
    if (!validPhone) {
        reportPhoneInput.style.borderColor = borderErrorColor;
        errorMessageContainer.innerText += "Please enter a valid phone number\n";
    }
}

//removes errors on fields
function SetInputsValid() {
    reportAddressInput.style.borderColor = ogBorderColour;
    reportDescriptionInput.style.borderColor = ogBorderColour;
    reportEmailInput.style.borderColor = ogBorderColour;
    reportPhoneInput.style.borderColor = ogBorderColour;
    errorMessageContainer.innerText = "";
}

reportSubmitButton.addEventListener("click", ValidateForm);