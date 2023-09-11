export const Left = 'L'

export const Right = 'R'

export type TurnDirection = typeof Left | typeof Right

export type Move = {
    readonly direction: TurnDirection,
    readonly stepCount: number
}

export type Intersection = {
    readonly x: number,
    readonly  y: number
}

export enum Direction {
    North,
    East,
    South,
    West
}

export type Location = {
    intersection: Intersection,
    facing: Direction
}

export type NonEmptyArray<T> = [T, ...T[]];

export type Path = NonEmptyArray<Location>

export function makeMove(direction: TurnDirection, stepCount: number): Move {
    return {direction, stepCount}
}

export function moveLeftBy(stepCount: number) {
    return makeMove(Left, stepCount)
}

export function moveRightBy(stepCount: number) {
    return makeMove(Right, stepCount)
}

export function intersectionAt(x: number, y: number): Intersection {
    return {x, y}
}

export function locationAt(intersection: Intersection, facing: Direction): Location {
    return {intersection, facing}
}