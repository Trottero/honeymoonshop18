window.onload = function () {   

    var checkboxes = document.getElementsByClassName('checkbox');
    for (var i = 0; i != checkboxes.length; i++) {
        if (checkboxes[i].hasAttribute('value') == false) {
            checkboxes[i].setAttribute('value', 'notchecked');
        } else {
            if (checkboxes[i].getAttribute('value') == 'checked') {
                checkboxes[i].setAttribute('value', 'checked');
                checkboxes[i].children[0].className = 'checkboxDotActive';
            }
        }

        checkboxes[i].onclick = function () {
           
            var idStr = 'input' + this.getAttribute('id');
            
            var inputElem = document.getElementById(idStr);
            

            if (this.getAttribute('value') == 'checked') {
                this.setAttribute('value', 'notchecked');                
                this.children[0].className = 'checkboxDot';
                inputElem.setAttribute('value', 'notchecked');
            } else {
                this.setAttribute('value', 'checked');                
                this.children[0].className = 'checkboxDotActive';
                inputElem.setAttribute('value', 'checked');               
            }
        };
    }
};


//Functions to set value of selected user input to checked
function keepMerken(selectedMerken) {   
    for (var i = 0; i < selectedMerken.length; i++) {
        var idStrCheckbox = 'Merk_' + selectedMerken[i];
        var checkbox = document.getElementById(idStrCheckbox);
        checkbox.setAttribute('value', 'checked');
        var idStrInput = 'inputMerk_' + selectedMerken[i];
        var input = document.getElementById(idStrInput);
        input.setAttribute('value', 'checked');
    }
}
function keepStijlen(selectedStijlen) {
    for (var i = 0; i < selectedStijlen.length; i++) {
        var idStrCheckbox = 'Stijl_' + selectedStijlen[i];
        var checkbox = document.getElementById(idStrCheckbox);
        checkbox.setAttribute('value', 'checked');
        var idStrInput = 'inputStijl_' + selectedStijlen[i];
        var input = document.getElementById(idStrInput);
        input.setAttribute('value', 'checked');
    }
}
function keepNeklijnen(selectedNeklijnen) {
    for (var i = 0; i < selectedNeklijnen.length; i++) {
        var idStrCheckbox = 'Neklijn_' + selectedNeklijnen[i];
        var checkbox = document.getElementById(idStrCheckbox);
        checkbox.setAttribute('value', 'checked');
        var idStrInput = 'inputNeklijn_' + selectedNeklijnen[i];
        var input = document.getElementById(idStrInput);
        input.setAttribute('value', 'checked');
    }
}
function keepSilhouetten(selectedSilhouetten) {    
    for (var i = 0; i < selectedSilhouetten.length; i++) {
        var idStrCheckbox = 'Silhouette_' + selectedSilhouetten[i];
        var checkbox = document.getElementById(idStrCheckbox);
        checkbox.setAttribute('value', 'checked');
        var idStrInput = 'inputSilhouette_' + selectedSilhouetten[i];
        var input = document.getElementById(idStrInput);
        input.setAttribute('value', 'checked');
    }
}
function keepKleuren(selectedKleuren) {
    for (var i = 0; i < selectedKleuren.length; i++) {
        var idStrCheckbox = 'Kleur_' + selectedKleuren[i];
        var checkbox = document.getElementById(idStrCheckbox);
        checkbox.setAttribute('value', 'checked');
        var idStrInput = 'inputKleur_' + selectedKleuren[i];
        var input = document.getElementById(idStrInput);
        input.setAttribute('value', 'checked');
    }
}