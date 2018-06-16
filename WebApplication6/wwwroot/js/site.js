// Write your JavaScript code.
function toggleFields() {
    var radioButton2 = document.getElementById("radio2");
    var radioButton1 = document.getElementById("radio1");
    if (radioButton2.checked == true) {
        document.getElementById("firma").classList.remove("hidden-field");
        document.getElementById("regon").classList.remove("hidden-field");
        document.getElementById("imie").classList.add("hidden-field");
        document.getElementById("nazwisko").classList.add("hidden-field");
        document.getElementById("pesel").classList.add("hidden-field");
        document.getElementById("nip").classList.add("hidden-field");

    }
    else {
        document.getElementById("firma").classList.add("hidden-field");
        document.getElementById("regon").classList.add("hidden-field");
        document.getElementById("imie").classList.remove("hidden-field");
        document.getElementById("nazwisko").classList.remove("hidden-field");
        document.getElementById("pesel").classList.remove("hidden-field");
        document.getElementById("nip").classList.remove("hidden-field");
    }
}