import {afterMove, distanceOf, origin} from "../src/traversal";
import {Direction, intersectionAt, locationAt, moveLeftBy, moveRightBy} from "../src/domain";

test("Origin has distance 0", () => {
    let intersection = origin
    let distance = 0
    expect(distanceOf(intersection)).toEqual(distance)
})

test.each([
    [intersectionAt(1, 1), 2],
    [intersectionAt(2, 3), 5],
    [intersectionAt(-2, 3), 5]
])("Distance is the absolute combined x and y components", (intersection, distance) => {
    expect(distanceOf(intersection)).toEqual(distance)
})

test("Moving 0 steps does not change intersection", () => {
    let location = locationAt(origin, Direction.North)
    let move = moveLeftBy(0)
    expect(afterMove(location, move).intersection).toEqual(location.intersection)
})

test.each([
    [locationAt(origin, Direction.North), moveLeftBy(2), Direction.West],
    [locationAt(origin, Direction.South), moveRightBy(4), Direction.West],
    [locationAt(origin, Direction.West), moveRightBy(1), Direction.North],
])("Moving changes facing direction", (location, move, expectedDirection) => {
    expect(afterMove(location, move).facing).toEqual(expectedDirection)
})

test.each([
    [locationAt(intersectionAt(0, 0), Direction.North), moveLeftBy(2), intersectionAt(-2, 0)],
    [locationAt(intersectionAt(1, 2), Direction.East), moveRightBy(3), intersectionAt(1, 5)],
    [locationAt(intersectionAt(-3, 1), Direction.West), moveRightBy(1), intersectionAt(-3, 0)],
])("Moving changes intersection", (location, move, expectedIntersection) => {
    expect(afterMove(location, move).intersection).toEqual(expectedIntersection)
})

test.each([
    [[moveRightBy(2), moveLeftBy(3)], 5],
    [[moveRightBy(2), moveRightBy(2), moveRightBy(2)], 2],
    [[moveRightBy(5), moveLeftBy(5), moveRightBy(5), moveRightBy(3)], 12]
])("Sequence of moves results in correct distance", (moves, expectedDistance) => {
    let start = locationAt(origin, Direction.North)
    let end = moves.reduce(afterMove, start)
    let distance = distanceOf(end.intersection)
    expect(distance).toEqual(expectedDistance)
})