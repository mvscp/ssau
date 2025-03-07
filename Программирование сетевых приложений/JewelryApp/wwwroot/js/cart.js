import "./purchase.js"
import {formatNumber} from "./utils.js"

let cart = document.querySelector('.cart');
let cartItems = document.querySelector('.cart-items');

let itemsTotalPrice = document.querySelector('.total-price');
let itemsTotalCount = document.querySelector('.items-total-count');


//Инициализация событий кнопок удаления
let itemDeleteBtn = document.querySelectorAll('.cart-item-btn-delete');
for(let deleteBtn of itemDeleteBtn) {
    deleteBtn.addEventListener('click', function(evt){
        if(itemsTotalCount.textContent == 0) {
            clearAllItems();
        }
        else{
            this.parentElement.parentElement.remove();
        }
        setTotalPrice();
        setTotalItemsCount();
    });
}

//Инициализация событий счетчиков элементов
for(let itemCounter of document.querySelectorAll('.cart-item-count')) {
    itemCounter.addEventListener('click', function(evt) {
        setItemTotalPrice(itemCounter.parentElement.parentElement);
        setTotalPrice();
        setTotalItemsCount();
    });
}


function setItemTotalPrice(cartItem) {
    let unitPrice = cartItem.querySelector('.cart-item-unit-price').textContent.replaceAll(' ', '');
    let itemCount = cartItem.querySelector('.cart-item-count').value;

    cartItem.querySelector('.cart-item-price-total').textContent = formatNumber(unitPrice * itemCount);
}


function clearAllItems() {
    cartItems.replaceChildren("");
}



//Устанавливают итоговые значения
function setTotalItemsCount() {
    let counter = 0;
    for(let itemCount of document.querySelectorAll('.cart-item-count')) {
        counter += parseInt(itemCount.value);
    }
    itemsTotalCount.textContent = counter;
}

function setTotalPrice() {
    let counter = 0;
    for(let cartItemPrice of cartItems.querySelectorAll('.cart-item-price-total')) {
        counter += parseInt(cartItemPrice.textContent.replaceAll(' ', ''));
    }
    itemsTotalPrice.textContent = formatNumber(counter);
}



//ВРЕМЕННОЕ РЕШЕНИЕ, В БУДУЩЕМ ЛУЧШЕ СДЕЛАТЬ АВТООБНОВЛЕНИЕ
//Установка базовых значений
setTotalPrice();
setTotalItemsCount();

for(let cartItem of cartItems.querySelectorAll('.cart-item')) {
    setItemTotalPrice(cartItem);
}


export {clearAllItems, cartItems};