function showForm() {
    var username = document.getElementById("username").textContent;
    var password = document.getElementById("password").textContent;
    var email = document.getElementById("email").textContent;

    document.getElementById("popup-title").textContent = username;
    document.getElementById("popup-username").value = username;
    document.getElementById("popup-password").value = password;
    document.getElementById("popup-email").value = email;
    document.getElementById("popup-window").style.display = "block";
}

function closeForm() {
    document.getElementById("popup-window").style.display = "none"
}

// function showForm(x) {
//     var table = document.getElementById("table-text");
//     document.getElementById("popup-username").value = table.rows[x.rowIndex].cells[0];
//     document.getElementById("popup-window").style.display = "block";
// }