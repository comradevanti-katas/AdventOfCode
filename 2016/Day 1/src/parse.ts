import {Left, makeMove, Move, Right} from "./domain";

function tryParseMove(s: string): Move | null {
    if (s.length < 2) return null

    let direction = s.substring(0, 1)
    if (!(direction === Right || direction === Left)) return null

    let stepCountString = s.substring(1)
    let stepCount = parseInt(stepCountString)

    if (isNaN(stepCount)) return null

    return makeMove(direction, stepCount)
}

export function tryParse(s: string): Move[] | null {
    if (s.length === 0) return []

    let parts = s.split(", ")
    let move = parts.map(tryParseMove)

    if (move.some(it => it === null))
        return null
    return move as Move[]
}