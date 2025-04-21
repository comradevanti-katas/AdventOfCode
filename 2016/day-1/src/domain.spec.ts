import fc from 'fast-check';
import { expect, it } from 'vitest';
import { calcShortestDistance, Dir, type Instruction } from './domain';

it('should be zero for empty instructions', () => {
    const distance = calcShortestDistance([]);

    expect(distance).to.equal(0);
});

it('should be the number if we just walk in a straight line', () =>
    fc.assert(
        fc.property(fc.integer(), (dist) => {
            const instruction = { dir: Dir.Left, dist } satisfies Instruction;
            const actual = calcShortestDistance([instruction]);
            expect(actual).to.equal(dist);
        })
    ));
