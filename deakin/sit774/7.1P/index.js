function processTextOld() {
    // let originInputString = "I love wearing a baseball cap on a sunny afternoon at the park made me feel effortlessly" + " cool " + "and shielded from the glaring sun. The soft fabric of the cap and it's relaxed fit gave me a " + "sense of casual ease, perfect for a day of laid-back enjoyment. Absolutely love my cap!";
    let originInputString = document.getElementById("exampleFormControlTextarea1").value;
    let searchString = document.getElementById("searchWord").value;
    let numCharacters = parseInt(document.getElementById("numberCharacters").value);

    if (originInputString === "" || searchString === "") {
        alert("Ensure you input a value in both fields!");
    } else if (numCharacters < 10 || numCharacters > 50) {
        alert("Ensure number of characters in the sub string is between 1 and 50!");
    } else {
        let inputString = originInputString.toLowerCase();
        searchString = searchString.toLowerCase();

        let length = inputString.length;
        document.getElementById("strResult1").innerText = length;

        let count = inputString.split(" ").length;
        document.getElementById("strResult2").innerText = count;

        let upperCaseString = inputString.toUpperCase();
        document.getElementById("strResult3").innerText = upperCaseString;

        document.getElementById("searchTerm").innerText = searchString;
        let index = inputString.indexOf(searchString);
        if (index === -1) {
            document.getElementById("strResult4").innerText = "Not Found";
        } else {
            let occurrence = 1;
            while (index !== -1) {
                index = inputString.indexOf(searchString, index + 1);
                if (index !== -1) {
                    occurrence++;
                }
            }
            document.getElementById("strResult4").innerText = occurrence;
        }

        document.getElementById("numberSubstringCharactersStart").innerText = numCharacters;
        document.getElementById("strResult5").innerHTML =
            '<span style="color:blue">' + originInputString.substring(0, numCharacters) +'</span>'
            + originInputString.substring(numCharacters + 1);

        document.getElementById("numberSubstringCharactersEnd").innerText = numCharacters;
        document.getElementById("strResult6").innerHTML =
            originInputString.substring(0, originInputString.length - numCharacters - 1) +
            '<span style="color:blue">' + originInputString.substring(originInputString.length - numCharacters - 1) + '</span>';
    }
}