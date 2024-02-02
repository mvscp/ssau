
class Student {
    constructor(firstName, lastName, marks) {
        this.firstName = firstName
        this.lastName = lastName
        this.marks = marks
    }

    getMeanMark() {
        let meanMarks = []
        let subjects = []
        for (const item of this.marks) {
            if (!subjects.includes(item.subject)) {
                subjects.push(item.subject)
                let subjectMarks = this.marks.filter(mark => mark.subject == item.subject).map(mark => mark.mark)
                let meanMark = subjectMarks.reduce((a, b) => a + b, 0) / subjectMarks.length
                meanMarks.push(new Mark(item.subject, meanMark))
            }
        }
        return meanMarks
    }

    getSubjectMarks(subject) {
        marks = []
        for (const item of this.marks) {
            if (item.subject == subject)
                marks.push(item.mark)
        }
        return marks
    }

    addMark(subject, mark) {
        this.marks.push(new Mark(subject, mark))
    }

    deleteMarks(subject) {
        this.marks = this.marks.filter(mark => mark.subject != subject)
    }
}

class Mark {
    constructor(subject, mark) {
        this.subject = subject
        this.mark = mark
    }
}

jsonObj = '{"firstName":"John", "lastName":"Dow", "marks": [{"subject": "math", "mark": 5}, {"subject": "physics", "mark": 5}, {"subject": "computer science", "mark": 5}, {"subject": "physics", "mark": 4}]}'
studentData = JSON.parse(jsonObj)
let marks = []
for (const item of studentData.marks)
    marks.push(new Mark(item.subject, item.mark))
let student = new Student(studentData.firstName, studentData.lastName, marks)
student.deleteMarks('math')
console.log(student.getMeanMark('physics'))
console.log(student.getSubjectMarks('physics'))
student.addMark('math', 4)
console.log(student)
