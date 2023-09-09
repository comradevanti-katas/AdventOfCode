import {MoveInstruction} from "./domain";

function tryParseInstruction(s: string): MoveInstruction | null {
    if (s.length < 2) return null

    let direction = s.substring(0, 1)
    if (!(direction === 'R' || direction === 'L')) return null

    let stepCountString = s.substring(1)
    let stepCount = parseInt(stepCountString)

    if (isNaN(stepCount)) return null

    return {turnDirection: direction, stepCount}
}

export function tryParse(s: string): MoveInstruction[] | null {
    if (s.length === 0) return []

    let parts = s.split(", ")
    let instructions = parts.map(tryParseInstruction)

    if (instructions.some(it => it === null))
        return null
    return instructions
}