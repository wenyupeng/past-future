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

function buildCapList() {
    let divTag = document.getElementById('top_cap_list');
    divTag.innerHTML = ''
    let ulTag = document.createElement('ul');
    divTag.appendChild(ulTag)
    capArray.forEach(t => {
        let liTag = document.createElement('li');
        liTag.innerText = t;
        ulTag.appendChild(liTag);
    })
}

function removeCapList() {
    let divTag = document.getElementById('top_cap_list');
    divTag.innerHTML = '<p><em>List is empty</em></p>'
}