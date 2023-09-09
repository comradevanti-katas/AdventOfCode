import {MoveInstruction} from "../src/domain";
import {tryParse} from "../src/parse";

test("Empty string is empty array", () => {
    let input = ""
    expect(tryParse(input)).toHaveLength(0)
})

test("Can parse single instruction", () => {
    let input = "R2"
    let expected: MoveInstruction[] = [{turnDirection: 'R', stepCount: 2}]
    expect(tryParse(input)).toEqual(expected)
})

test("Can parse multiple instructions", () => {
    let input = "R3, L4"
    let expected: MoveInstruction[] = [
        {turnDirection: 'R', stepCount: 3},
        {turnDirection: 'L', stepCount: 4}
    ]
    expect(tryParse(input)).toEqual(expected)
})