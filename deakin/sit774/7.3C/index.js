function checkInput(inputTag, checkMsgTag, checkCondition, validMsg, invalidMsg) {
    let checkMsg = "";
    let addClass = "";
    if (checkCondition) {
        checkMsg = invalidMsg;
        addClass = "is-invalid";
        inputTag.classList.remove("is-valid");
        checkMsgTag.classList.add("invalid-feedback");
        checkMsgTag.classList.remove("valid-feedback");
    } else {
        checkMsg = validMsg;
        addClass = "is-valid";
        inputTag.classList.remove("is-invalid");
        checkMsgTag.classList.remove("invalid-feedback");
        checkMsgTag.classList.add("valid-feedback");
    }
    checkMsgTag.innerText = checkMsg;
    inputTag.classList.add(addClass);
}

function nameCheck() {
    let nameTag = document.getElementById("name");
    let nameMsgTag = document.getElementById("nameCheckMsg");
    let condition = nameTag.value === "" || nameTag.value.length > 100;
    let validMsg = "Valid name entered.";
    let invalidMsg = "Name is not valid. Must be 1 to 100 characters";
    checkInput(nameTag, nameMsgTag, condition, validMsg, invalidMsg);
}

function idCheck() {
    let inputTag = document.getElementById("ID");
    let checkMsgTag = document.getElementById("idCheckMsg");
    let condition = inputTag.value === "" || !/\d{10}/.test(inputTag.value) || inputTag.value.length !== 10;
    let validMsg = "Valid ID entered.";
    let invalidMsg = "ID is not valid. Must be exactly 10 digits.";
    checkInput(inputTag, checkMsgTag, condition, validMsg, invalidMsg);

}

function emailCheck() {
    let inputTag = document.getElementById("email");
    let checkMsgTag = document.getElementById("emailCheckMsg");
    let condition = inputTag.value === "" || !inputTag.value.endsWith("@deakin.edu.au");
    let validMsg = "Valid Email entered.";
    let invalidMsg = "Email is not valid. Must end with '@deakin.edu.au'.";
    checkInput(inputTag, checkMsgTag, condition, validMsg, invalidMsg);
}

function unitCheck() {
    let inputTag = document.getElementById("deakinUnit");
    let checkMsgTag = document.getElementById("unitCheckMsg");
    let condition = inputTag.value === "" || inputTag.value.length !== 6 || !/[a-zA-Z]{3}[0-9]{3}/.test(inputTag.value);
    let validMsg = "Valid Unit Code entered.";
    let invalidMsg = "Unit Code is not valid. Must be 6 characters in size and follow the 3 letters + 3 numbers" +
        " format(the letters can be capitalised or lowercase).";
    checkInput(inputTag, checkMsgTag, condition, validMsg, invalidMsg);
}

function capTypeCheck() {
    let inputTag = document.getElementById("capType");
    let checkMsgTag = document.getElementById("capTypeCheckMsg");
    let condition = inputTag.value === "" || inputTag.value.length !== 10 || !/[a-zA-Z]{3}-[a-zA-Z]{3}-[0-9]{2}/.test(inputTag.value);
    let validMsg = "Valid Cap Type entered.";
    let invalidMsg = "Cap Type is not valid. Must be of the format 3 letters + 3 letters + 2 numbers all separated" +
        " with a dash - (i.e., xxx-xxx-nn)";
    checkInput(inputTag, checkMsgTag, condition, validMsg, invalidMsg);
}

function validateForm() {
    nameCheck();
    idCheck();
    emailCheck();
    unitCheck();
    capTypeCheck();
}

function resetForm() {
    document.getElementById("nameCheckMsg").innerText = "";
    document.getElementById("name").classList.remove("is-valid","is-invalid");

    document.getElementById("idCheckMsg").innerText = "";
    document.getElementById("ID").classList.remove("is-valid","is-invalid");

    document.getElementById("emailCheckMsg").innerText = "";
    document.getElementById("email").classList.remove("is-valid","is-invalid");

    document.getElementById("unitCheckMsg").innerText = "";
    document.getElementById("deakinUnit").classList.remove("is-valid","is-invalid");

    document.getElementById("capTypeCheckMsg").innerText = "";
    document.getElementById("capType").classList.remove("is-valid","is-invalid");
}