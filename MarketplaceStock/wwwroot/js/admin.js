function closeForm() {
    document.getElementById("popup-window").style.display = "none"
}

async function showForm(id) {
    const user = await getUser(id);

    document.getElementById("popup-title").textContent = user["username"];
    document.getElementById("selectedUser").value = user["username"];
    document.getElementById("username").value = user["username"];
    document.getElementById("password").value = user["password"];
    document.getElementById("email").value = user["email"];

    document.getElementById("popup-window").style.display = "block";
}

async function getUser(id) {
    const response = await fetch('/api/Data');
    if (response.ok) {
        const data = await response.json();
        const user = data.find(element => element["id"] == id);
        if (user) {
            return user;
        } else {
            console.error('User not found');
        }
    } else {
        console.error('Unable to retrieve data');
    }
}