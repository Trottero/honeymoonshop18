window.onload = function () {
    /*var merk1 = document.getElementById('inputMerk_0');
    merk1.setAttribute('value', 'checked')
    window.alert(merk1.getAttribute('value'));*/

    var checkboxes = document.getElementsByClassName('checkbox');
    for (var i = 0; i != checkboxes.length; i++) {
        if (checkboxes[i].hasAttribute('value') == false) {
            checkboxes[i].setAttribute('value', 'notChecked');
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
                this.setAttribute('value', 'notChecked');                
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