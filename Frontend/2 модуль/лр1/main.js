
function isNonHypotenuse(n)
{
    if (n <= 0)
        return true
    while (n % 2 == 0) {
        n = Math.floor(n / 2)
    }
    for (var i = 3; i <= Math.sqrt(n); i = i + 2) {
        if (n % i == 0) {
            if ((i - 1) % 4 == 0)
                return false

            while (n % i == 0) {
                n = Math.floor(n / i)
            }
        }
    }
    if (n > 2 && (n - 1) % 4 == 0)
        return false
    else
        return true
}

const c = document.getElementById('input1')
const result = document.getElementById('result')
const submitBtn = document.getElementById('submit')
submitBtn.onclick = () => {
    if (isNonHypotenuse(parseInt(c.value)))
        result.textContent = 'Число является негипотенузным'
    else
        result.textContent = 'Число является гипотенузным'
}
