
class Figure {
    #x 
    #y
    constructor(x, y) {
        this.#x = x
        this.#y = y
    }

    square() {
        return undefined
    }
}

class Circle extends Figure {
    #r
    constructor(x, y, r) {
        super(x, y)
        this.#r = r
    }

    square() {
        return Math.PI * this.#r ** 2
    }

    setR(r) {
        this.#r = r 
    }

    getR() {
        return this.#r
    }
}

class Rectangle extends Figure {
    #h
    #w
    constructor(x, y, h, w) {
        super(x, y)
        this.#h = h
        this.#w = w
    }

    square() {
        return this.#h * this.#w
    }

    setH(h) {
        this.#h = h
    }

    getH() {
        return this.#h
    }

    setW(w) {
        this.#w = w
    }

    getW() {
        return this.#w
    }
}

let circle = new Circle(4, 5, 5)
let rectangle = new Rectangle(3, 3, 5, 6)
circle.setR(7)
rectangle.setW(10)
console.log(circle.square(), circle.getR())
console.log(rectangle.square(), rectangle.getH(), rectangle.getW())
