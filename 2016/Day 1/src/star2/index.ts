import 'dotenv/config'
import {readFile} from "fs/promises"
import {tryParse} from '../common/parse'
import {Direction, Intersection, Location, locationAt, Move, NonEmptyArray, Path} from "../common/domain";
import {origin, afterMove, distanceOf, extendPath} from '../common/traversal';

function tryFindDuplicate(intersections: Intersection[]): Intersection | null {
    return intersections.find((current, index) => {
        return intersections.slice(index + 1).some(other => other.x === current.x && other.y === current.y)
    }) ?? null
}

function findDuplicateIntersection(path: Path, moves: Move[]): Intersection {
    if (moves.length === 0)
        throw new Error("Did not find duplicate")

    let nextMove = moves[0]
    let newPath = extendPath(path, nextMove)
    let duplicate = tryFindDuplicate(newPath.map(it => it.intersection))

    if (duplicate !== null) return duplicate
    return findDuplicateIntersection(newPath, moves.slice(1))
}

async function star2() {
    let inputPath = process.env.INPUT
    if (inputPath === undefined) throw new Error("No input path")

    let inputString = await readFile(inputPath, "utf-8")

    let moves = tryParse(inputString)
    if (moves === null) throw new Error("Could not parse input")

    let start = locationAt(origin, Direction.North)
    let duplicate = findDuplicateIntersection([start], moves);
    let distance = distanceOf(duplicate)

    console.log(`Distance to first duplicate location is ${distance}`)
}

star2()