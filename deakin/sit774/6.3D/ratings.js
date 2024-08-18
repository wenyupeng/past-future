const capRatingListJSON = {
    capratings: [
        {cap: "BBC", fullName: 'Baseball Cap', stars: [12, 34, 532, 321, 77]},
        {cap: "FDC", fullName: 'Fedora Cap', stars: [55, 23, 123, 59, 24]},
        {cap: "SNC", fullName: 'Sun Cap', stars: [33, 124, 288, 983, 672]},
        {cap: "PPC", fullName: 'Porkpie Cap', stars: [61, 234, 341, 633, 43]},
        {cap: "BRC", fullName: 'Beret Cap', stars: [88, 341, 343, 456, 234]},
        {cap: "SNV", fullName: 'Sun Visor', stars: [12, 44, 123, 233, 88]},
        {cap: "BKC", fullName: 'Bucket Cap', stars: [56, 77, 44, 23, 17]},
        {cap: "PNC", fullName: 'Panamа Cар', stars: [78, 389, 545, 241, 112]},
        {cap: "FLC", fullName: 'Flat Cap', stars: [37, 201, 358, 332, 123]},
        {cap: "CBC", fullName: 'Cowboy Cap', stars: [19, 42, 112, 215, 99]}
    ]
};

function generateContent() {
    let content = document.getElementById('content');
    content.innerHTML = ''

    let description = document.createElement('p');
    description.classList.add('mt-3');
    description.innerText = 'The following table has been dynamically generated from JSON data:';
    content.appendChild(description);

    let table = buildCapRatingTable();
    content.appendChild(table);

    let description2 = document.createElement('p');
    description2.innerText = 'Some statistics on the cap ratings across all types:';
    content.appendChild(description2);

    let ulTag = document.createElement('ul');
    ulTag.classList.add('mt-3');
    content.appendChild(ulTag);

    let bestRatingTag = document.createElement('li');
    bestRatingTag.innerHTML = 'Best rating cap: <b>' + summary.bestRatingCap + '</b> with <b>' + summary.max + '</b> rating';
    ulTag.appendChild(bestRatingTag);

    let worstRatingTag = document.createElement('li');
    worstRatingTag.innerHTML = 'Worst rating cap: <b>' + summary.worstRatingCap + '</b> with <b>' + summary.min + '</b> rating';
    ulTag.appendChild(worstRatingTag);

    let TotalRatingTag = document.createElement('li');
    TotalRatingTag.innerHTML = 'Total number of ratings submitted: <b>' + summary.totalRatings + '</b>';
    ulTag.appendChild(TotalRatingTag);

    let averageRatingTag = document.createElement('li');
    averageRatingTag.innerHTML = 'Average number of ratings per cap: <b>' + summary.totalRatings / capRatingListJSON.capratings.length + '</b>';
    ulTag.appendChild(averageRatingTag);

    let categoryTag = document.createElement('li');
    categoryTag.innerHTML = 'Average ratings over all caps: <b>' + summary.sumAverageRatings / capRatingListJSON.capratings.length + '</b> which equates to a rating category of <b>' + capCategory(summary.sumAverageRatings / capRatingListJSON.capratings.length) + '</b>';
    ulTag.appendChild(categoryTag);

    let pTag = document.createElement('p');
    pTag.innerText='Average calculated from summing up all the star rating dividing each by the total number of ratings for that cap.';
    content.appendChild(pTag);
}

const capNameDict = {
    "BBC": 'Baseball Cap',
    "FDC": 'Fedora Cap',
    "SNC": 'Sun Cap',
    "PPC": 'Porkpie Cap',
    "BRC": 'Beret Cap',
    "SNV": 'Sun Visor',
    "BKC": 'Bucket Cap',
    "PNC": 'Panamа Cар',
    "FLC": 'Flat Cap',
    "CBC": 'Cowboy Cap'
}

const summary = {
    'max': 0,
    'min': 100,
    'bestRatingCap': '',
    'worstRatingCap': '',
    'totalRatings': 0,
    'sumAverageRatings': 0.0,
}

function fullCapName(abbreviatedCapName) {
    return capNameDict[abbreviatedCapName];
}

function calcCapRatingTotal(capRatingsArray) {
    return capRatingsArray.reduce((acc, cur) => {
        return acc + cur;
    });
}

function calcCapAverageRating(capRatingsArray) {
    return ((capRatingsArray[0] * 1.0 + capRatingsArray[1] * 2.0 + capRatingsArray[2] * 3.0 + capRatingsArray[3] * 4.0
        + capRatingsArray[4] * 5.0) / calcCapRatingTotal(capRatingsArray)).toFixed(2);
}

function capCategory(capRating) {
    if (capRating >= 0 && capRating <= 2.5) {
        return 'Poor';
    } else if (capRating >= 2.5 && capRating <= 4) {
        return 'Good';
    } else if (capRating >= 4.0) {
        return 'Great';
    } else {
        return '';
    }
}

function addTableHeader(table) {
    let thead = document.createElement('thead');
    table.appendChild(thead);

    let tr = document.createElement('tr');
    thead.appendChild(tr);
    let header = ['Cap', 'Cap Full Name', '1-star', '2-stars', '3-stars', '4-stars', '5-stars', 'Rating Total', 'Average Rating', 'Rating Category'];
    header.forEach(cell => {
        let th = document.createElement('th');
        th.innerText = cell;
        tr.appendChild(th);
    });
}

function addTableBody(table) {
    let tbody = document.createElement('tbody');
    table.appendChild(tbody);
    capRatingListJSON.capratings.forEach(r => {
        let tr = document.createElement('tr');
        table.appendChild(tr);

        let abbreviation = document.createElement('td');
        abbreviation.innerText = r.cap;
        tr.appendChild(abbreviation);

        let fullName = document.createElement('td');
        fullName.innerText = fullCapName(r.cap);
        tr.appendChild(fullName);

        r.stars.forEach(r => {
            let star = document.createElement('td');
            star.innerText = r;
            tr.appendChild(star);
        });

        let ratingTotal = calcCapRatingTotal(r.stars);
        let ratingTotalTag = document.createElement('td');
        ratingTotalTag.innerText = ratingTotal;
        tr.appendChild(ratingTotalTag);

        summary.totalRatings += parseInt(ratingTotal);

        let averageRating = calcCapAverageRating(r.stars);
        let averageRatingTag = document.createElement('td');
        averageRatingTag.innerText = averageRating;
        tr.appendChild(averageRatingTag);

        summary.sumAverageRatings += parseInt(averageRating);

        let capCategoryTag = document.createElement('td');
        capCategoryTag.innerText = capCategory(averageRating);
        tr.appendChild(capCategoryTag);

        if (averageRating > summary.max) {
            summary.max = averageRating;
            summary.bestRatingCap = r.cap;
        }

        if (averageRating < summary.min) {
            summary.min = averageRating;
            summary.worstRatingCap = r.cap;
        }

    })
}

function buildCapRatingTable() {
    let table = document.createElement('table');
    table.classList.add('table', 'table-bordered', 'my-4');

    addTableHeader(table);
    addTableBody(table);

    return table;
}