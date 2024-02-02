
function foo(name, rank='Рядовой')
{
    return `Имя: ${name}` + `\nЗвание: ${rank}`
}

console.log(foo())
console.log(foo('Алексей', 'Сержант'))
console.log(foo('Андрей'))
