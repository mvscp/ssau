function formatNumber(number) {
    return number.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ' ');
}

export {formatNumber};

document.addEventListener('DOMContentLoaded', function () {
    const inputs = document.querySelectorAll('input, textarea');

    const regexPatterns = {
        name: /^[A-Za-zА-Яа-яЁё\s\-]{1,50}$/,
        email: /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/, 
        telephone: /^\+?\d{1,2}\s?\(?\d{3}\)?\s?\d{3}-?\d{2}-?\d{2}$|^\d{11}$/,
        message: /^.{10,}$/,
        zipcode: /^\d{3}-\d{3}$/
    };

    inputs.forEach(input => {
        input.addEventListener('input', function () {
            const fieldName = input.getAttribute('name');
            const pattern = regexPatterns[fieldName];
            const errorDiv = input.nextElementSibling;

            if (pattern && !pattern.test(input.value)) {
                input.classList.add('error');
                if (!errorDiv || !errorDiv.classList.contains('error-message')) {
                    const errorMsg = document.createElement('div');
                    errorMsg.classList.add('error-message');
                    errorMsg.textContent = 'Поле заполнено некорректно';
                    input.insertAdjacentElement('afterend', errorMsg);
                }
            } else {
                input.classList.remove('error');
                if (errorDiv && errorDiv.classList.contains('error-message')) {
                    errorDiv.remove();
                }
            }
        });
    });
});
