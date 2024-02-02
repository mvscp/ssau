
function searchEquals(array1, array2) {
    let equals = new Set(array1.filter(x => array2.includes(x)))
    return equals
}

function countEntries(array) {
    let counts = new Map()
    for (const item of array) {
        if (!counts.has(item)) {
            counts.set(item, array.filter(x => x == item).length)
        }
    }
    return counts
}

function countStudentsBiggestGroup(array) {
    let groups = new Map()
    for (const student of array) {
        if (!groups.has(student.group)) {
            groups.set(student.group, array.filter(x => x.group == student.group).length)
        }
    }
    return Math.max(...groups.values())
}

class Student {
    constructor(name, group) {
        this.name = name
        this.group = group
    }
}

let arr1 = [1, 4, 2, 6, 7, 9]
let arr2 = [5, 2, 2, 9, 8, 3, 5, 2]
let students = [
    new Student('John', '1'), new Student('Alex', '2'), 
    new Student('Paul', '3'), new Student('Jay', '1'), 
    new Student('Kyle', '3'), new Student('Rose', '1'),
    new Student('Tom', '2'), new Student('Ben', '1')
]
console.log(searchEquals(arr1, arr2))
console.log(countEntries(arr2))
console.log(countStudentsBiggestGroup(students))
