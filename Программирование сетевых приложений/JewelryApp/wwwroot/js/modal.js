function openModal(id, name, description, price, imageUrl) {
    document.getElementById("modalTitle").innerText = name;
    document.getElementById("modalDescription").innerText = description;
    document.getElementById("modalPrice").innerText = price;
    document.getElementById("modalImage").src = imageUrl;

    document.getElementById("productModal").style.display = "block";
}

function closeModal() {
    document.getElementById("productModal").style.display = "none";
}

// Закрытие окна при клике вне него
window.onclick = function(event) {
    let modal = document.getElementById("productModal");
    if (event.target === modal) {
        closeModal();
    }
};
