import {
    Direction,
    Intersection,
    intersectionAt,
    Left,
    Location,
    locationAt, makeMove,
    Move,
    Path,
    TurnDirection
} from "./domain.js";

export const origin = intersectionAt(0, 0)

export function distanceOf(intersection: Intersection): number {
    return Math.abs(intersection.x) + Math.abs(intersection.y)
}

function afterTurn(direction: Direction, turn: TurnDirection): Direction {
    let turned = direction + (turn === Left ? -1 : 1);

    if (turned === -1) turned = 3
    else if (turned === 4) turned = 0

    return turned
}

function moveX(intersection: Intersection, change: number) {
    return intersectionAt(intersection.x + change, intersection.y)
}

function moveY(intersection: Intersection, change: number) {
    return intersectionAt(intersection.x, intersection.y + change)
}

function movedInDirection(intersection: Intersection, direction: Direction, stepCount: number): Intersection {
    switch (direction) {
        case Direction.North:
            return moveY(intersection, -stepCount)
        case Direction.East:
            return moveX(intersection, stepCount)
        case Direction.South:
            return moveY(intersection, stepCount)
        case Direction.West:
            return moveX(intersection, -stepCount)
    }
}

export function afterMove(location: Location, move: Move): Location {

    const facing = afterTurn(location.facing, move.direction)
    const intersection = movedInDirection(location.intersection, facing, move.stepCount)

    return locationAt(intersection, facing)
}

export function extendPath(path: Path, move: Move): Path {
    let currentLocation = path[path.length - 1]
    let nextLocations = Array.from({length: move.stepCount}, (_, i) => i + 1)
        .map(stepCount => makeMove(move.direction, stepCount))
        .map(subMove => afterMove(currentLocation, subMove))
    return [...path, ...nextLocations]
}