import {moveLeftBy, moveRightBy, Move} from "./domain.js";
import {tryParse} from "./parse.js";

test("Empty string is empty array", () => {
    let input = ""
    expect(tryParse(input)).toHaveLength(0)
})

test("Can parse single instruction", () => {
    let input = "R2"
    let expected: Move[] = [moveRightBy(2)]
    expect(tryParse(input)).toEqual(expected)
})

test("Can parse multiple instructions", () => {
    let input = "R3, L4"
    let expected: Move[] = [
        moveRightBy(3),
        moveLeftBy(4)
    ]
    expect(tryParse(input)).toEqual(expected)
})