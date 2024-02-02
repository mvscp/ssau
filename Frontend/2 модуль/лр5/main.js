
function countEntriesAfter(array) {
    let counts = []
    for (let i=1; i < array.length; i++) {
        counts.push(array.slice(i).filter(x => x == array[i-1]).length)
    }
    return counts
}

function negativeSums(array) {
    let sums = []
    let sum
    for (let col=0; col < array[0].length; col++) {
        sum = 0
        for (let row=0; row < array.length; row++) {
            if (array[row][col] < 0)
                sum += array[row][col]
        }
        sums.push(sum)
    }
    return sums
}

let arr = [1, 4, 2, 5, 6, 7, 2, 3, 3, 4, 2]
console.log(countEntriesAfter(arr))

let arr2d = [
    [1, -5, 2], 
    [4, 7, -3], 
    [-1, -2, -6],
    [4, 9, -5]
]
console.log(negativeSums(arr2d))
