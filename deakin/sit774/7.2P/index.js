let counter = 0;
let switchFlag = true;

function displayDateInfo() {
    let date = new Date();

    let displayTag = document.getElementById("displayInfo");
    displayTag.innerHTML = '';
    let hTag = document.createElement("h3");
    hTag.classList.add("mt-3");
    hTag.innerText = "Well done, you clicked the button!";
    displayTag.appendChild(hTag);


    let urlTag1 = document.createElement("ul");
    displayTag.appendChild(urlTag1);
    urlTag1.innerHTML = '<li>' + "At time:" + date.toTimeString() + '</li>';


    let urlTag2 = document.createElement("ul");
    displayTag.appendChild(urlTag2);
    urlTag2.innerHTML = '<li>' + "On date:" + date.toDateString() + '</li>';

    let urlTag3 = document.createElement("ul");
    displayTag.appendChild(urlTag3);
    urlTag3.innerHTML = '<li>' + "The date in ISO format:" + date.toISOString() + '</li>';

    let pTag = document.createElement("p");
    pTag.innerHTML = '<b>' + "Move your cursor/mouse over this div element to change the background colour to ORANGE." + '</b>';
    displayTag.appendChild(pTag);

    let btnTag = document.getElementById("btnContent");
    counter++;
    btnTag.value = "Try again...Pressed " + counter + " timers";

    if (counter > 3 && switchFlag) {
        displayTag.style.display = "none";
        btnTag.value = "Click to Re-start";
        switchFlag = false;
        counter = 0;
    } else if (counter >= 5) {
        displayTag.style.display = "block";
    }


}

function changeBackgroundColor() {
    let contentTag = document.getElementById("displayInfo");
    contentTag.style.backgroundColor = "Orange";
}

function resetBackgroundColor() {
    let contentTag = document.getElementById("displayInfo");
    contentTag.style.backgroundColor = "";
}