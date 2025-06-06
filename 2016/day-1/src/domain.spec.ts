import fc from 'fast-check';
import { expect, it } from 'vitest';
import {
    calcShortestDistance,
    calcShortestDistanceToDuplicatedLocation,
    goLeft,
    goRight,
} from './domain';

it('should be zero for empty instructions', () => {
    const distance = calcShortestDistance([]);

    expect(distance).to.equal(0);
});

it('should be the number if we just walk in a straight line', () =>
    fc.assert(
        fc.property(
            fc.integer().filter((n) => n > 0),
            (dist) => {
                const instruction = goRight(dist);
                const actual = calcShortestDistance([instruction]);
                expect(actual).to.equal(dist);
            }
        )
    ));

it('should be zero if we walk in circle', () => {
    const actual = calcShortestDistance([
        goRight(10),
        goRight(10),
        goRight(10),
        goRight(10),
    ]);

    expect(actual).to.equal(0);
});

it('should solve example', () => {
    const actual = calcShortestDistance([
        goRight(5),
        goLeft(5),
        goRight(5),
        goRight(3),
    ]);

    expect(actual).to.equal(12);
});

it('should be zero if no location is visited twice', () => {
    const actual = calcShortestDistanceToDuplicatedLocation([
        goRight(2),
        goRight(5),
    ]);
    expect(actual).to.equal(0);
});

it('should be the number of the shortest distance to the first location visited twice', () => {
    const actual = calcShortestDistanceToDuplicatedLocation([
        goRight(8),
        goRight(4),
        goRight(4),
        goRight(8),
    ]);
    expect(actual).to.equal(4);
});
