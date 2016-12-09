document.addEventListener("DOMContentLoaded", ButtonTrigger, false);

function ButtonTrigger() {
    var button = DropBox.createChooseButton(options);
    document.getElementById("container").appendChild(button);

}