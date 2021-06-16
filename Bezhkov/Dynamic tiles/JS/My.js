function addElement() {
    var element = document.getElementById("myelements");
    var pElements = document.getElementsByTagName("p");

    function getRandomInt(max) {
        return Math.floor(Math.random() * max);
    }
    pElements[0].innerHTML = getRandomInt(150);

    var newelement = element.cloneNode(true);
    document.getElementById("element").appendChild(newelement);
    pElements[0].innerHTML = getRandomInt(150);

};

function deleteElement() {
    var element = document.querySelector("div.container");
    var removeElement = document.querySelectorAll("div.conteiner");
    for (i = 1; i < removeElement.length; i++) {
        if (i == removeElement.length - 1) {
            element.removeChild(removeElement[i]);
        }
    }
}

function deleteAllElements() {
    var element = document.querySelector("div.container");
    var removeElement = document.querySelectorAll("div.conteiner");
    for (i = 1; i < removeElement.length; i++) {
        element.removeChild(removeElement[i]);
    }
}
var allElement;

function SortElementMax() {


    var element = document.querySelector("div.con.sd")
    var removeElement = document.querySelectorAll("p.pfountmenu");

    let sorted = [...removeElement].sort(function(a, b) {
        return a.innerHTML - b.innerHTML;
    });
    element.innerHTML = '';

    for (i = 0; i > removeElement.length; i++) {
        element.innerHTML = sorted[i]
    }
    for (let p of sorted) {
        element.appendChild(p);

    }
}

function SortElementMin() {


    var element = document.querySelector("div.con.sd")
    var removeElement = document.querySelectorAll("p.pfountmenu");

    let sorted = [...removeElement].sort(function(a, b) {
        return -a.innerHTML - b.innerHTML;
    });
    element.innerHTML = '';

    for (let p of sorted) {
        element.appendChild(p);

    }
}