import { clearAllItems, cartItems } from "./cart.js";

let cartBtn = document.querySelector('.cart-submit-btn');

let modal = document.querySelector('.modal');
let modalContent = document.querySelector('.modal-window');
let modalOverlay = document.querySelector('.overlay');
let modalCloseBtn = document.querySelector('.modal-btn-close');
let modalSubmitBtn = document.querySelector('.modal-btn-submit');

let modalInputs = document.querySelectorAll('.modal-window input');

function setModalToComplete() {    
    let message = document.createElement("div");
    message.classList.add('modal-window');
    let messageHeader = document.createElement('h2');
    messageHeader.textContent = "Заказ оформлен!";
    let messageDesc = document.createElement('p');
    messageDesc.textContent = "В ближайшее время с вами свяжутся наши сотрудники для уточнения подробностей";

    message.appendChild(modalCloseBtn);
    message.appendChild(messageHeader);
    message.appendChild(messageDesc);

    modalContent.replaceWith(message);
}


cartBtn.addEventListener('click', function(evt) {
    if(cartItems.children.length != 0) {
        modal.classList.remove('hidden');
    }
})

modalOverlay.addEventListener('click', function(evt) {
    modal.classList.add('hidden');
})

modalCloseBtn.addEventListener('click', function(evt) {
    modal.classList.add('hidden');
})


modalSubmitBtn.addEventListener('click', function(evt) {
    for(let input of modalInputs) {
        if(input.checkValidity() === false) {
            return 0;
        }
    }
    setModalToComplete();
    clearAllItems();
})