const capArray = [
    "Baseball Cap",
    "Fedora Cap",
    "Sun Cap",
    "Porkpie Cap",
    "Beret Cap",
    "Sun Visor",
    "Bucket Cap",
    "Panama Cap",
    "Flat Cap",
    "Cowboy Cap"
];

function checkWeeksInput() {
    let weekCountInputTag = document.getElementById('weekCountInput');
    let userInput = parseInt(weekCountInputTag.value);
    if (userInput < 1 || userInput > 52) {
        alert(`Error: Number of WEEKS must be between 1 and 52 (value ${userInput} enter)`);
        weekCountInputTag.value = '';
        return null;
    } else {
        return userInput;
    }
}


function checkCapsInput() {
    let capCountInputTag = document.getElementById('capCountInput');
    let userInput = parseInt(capCountInputTag.value);
    if (userInput < 1 || userInput > 10) {
        alert(`Error: Number of CAPS must be between 1 and 10 (value ${userInput} enter)`);
        capCountInputTag.value = '';
        return null;
    } else {
        return userInput;
    }
}

function buildCapPlan() {
    let weeks = checkWeeksInput();
    let caps = checkCapsInput();

    let tbody = document.getElementById('cap-planner-table-body');
    tbody.innerHTML = '';

    let switchFlag = false;
    let serial = 1;
    for (let i = 0; i < weeks * 7; i++) {
        if (i % 7 === 0) {
            var row = document.createElement('tr');
            tbody.append(row);
            let serialNum = document.createElement('td');
            row.appendChild(serialNum);
            serialNum.innerText = serial++;
        }

        if (i % caps === 0) {
            switchFlag = !switchFlag;
        }

        let cell = document.createElement('td');
        cell.innerText = capArray[i % caps];
        if (switchFlag) {
            cell.classList.add('table-active')
        } else {
            cell.classList.remove('table-active')
        }
        row.appendChild(cell);

    }
}

function resetCapPlan() {
    document.getElementById('weekCountInput').value = null;
    document.getElementById('capCountInput').value = null;
    let tbody = document.getElementById('cap-planner-table-body');
    tbody.innerHTML = "<tr><td colspan=\"8\"><em>The plan is currently empty!</em></td></tr>";
}