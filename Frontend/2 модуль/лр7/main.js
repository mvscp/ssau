
class Student {
    constructor(firstName, lastName) {
        this.firstName = firstName
        this.lastName = lastName
    }
}

function binarySearch(array, firstName, lastName) {
    array.sort((a, b) => {
        if (a.lastName > b.lastName) {
            return 1;
        }
        if (a.lastName < b.lastName) {
            return -1;
        }
        // a.lastName == b.lastName
        if (a.firstName > b.firstName) {
            return 1;
        }
        if (a.firstName < b.firstName) {
            return -1;
        }
        return 0
    })
    let left = 0
    let right = array.length - 1
    while (left <= right) {
        const mid = Math.floor((left + right) / 2)
        if (array[mid].lastName == lastName)
            if (array[mid].firstName == firstName)
                return mid
            else if (array[mid].firstName < firstName)
                left = mid + 1
            else
                right = mid - 1
        else if (array[mid].lastName < lastName)
            left = mid + 1
        else
            right = mid - 1
    }
    return -1
}

let students = [
    new Student('John', 'Dow'), new Student('Alex', 'Bracken'), new Student('Paul', 'Logan'),
    new Student('Tom', 'Bezos'), new Student('Rose', 'Watson'), new Student('Jay', 'Bracken')
]
// Tom Bezos, Alex Bracken, Jay Bracken, John Dow, Paul Logan, Rose Watson 
console.log(binarySearch(students, 'Jay', 'Bracken'))
console.log(students)
