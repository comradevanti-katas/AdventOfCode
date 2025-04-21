import fc from 'fast-check';
import { EOL } from 'os';
import { expect, it } from 'vitest';
import { solveBathroomCode } from './domain';

const direction = fc.constantFrom('U', 'R', 'D', 'L');

const dirSequence = fc
    .array(direction, { minLength: 1, maxLength: 100 })
    .map((arr) => arr.join());

const repeat = <T>(it: T, times: number) =>
    Array.from({ length: times }).map(() => it);

it('should give null for no input', () => {
    let password = solveBathroomCode('');
    expect(password).to.toBeNull();
});

it('should give result for single input', () => {
    let password = solveBathroomCode('U');
    expect(password).to.equal(2);
});

it('should give result for single corner input', () => {
    let password = solveBathroomCode('UR');
    expect(password).to.equal(3);
});

it('password length matches line count', () =>
    fc.assert(
        fc.property(fc.integer({ min: 1, max: 20 }), (count) => {
            let input = repeat('U', count).join(EOL);
            let password = solveBathroomCode(input);

            expect(password?.toString()).to.have.length(count);
        })
    ));

it('should be able to walk back and forth n times', () =>
    fc.assert(
        fc.property(fc.integer({ min: 1, max: 20 }), (n) => {
            // The input is n times RL, ie. walking back and forth
            let input = repeat('RL', n).join();

            let password = solveBathroomCode(input);

            // Which should bring us back to where we started
            expect(password).to.equal(5);
        })
    ));

it('should be able to walk in a circle n times', () =>
    fc.assert(
        fc.property(fc.integer({ min: 1, max: 20 }), (n) => {
            // The input is n times ULDR, ie. walking in a circle
            let input = repeat('ULDR', n).join();

            let password = solveBathroomCode(input);

            // Which should bring us back to where we started
            expect(password).to.equal(5);
        })
    ));

it('should end up on bottom edge if we go down a bunch', () =>
    fc.assert(
        fc.property(dirSequence, (sequence) => {
            // We go some random sequence and then down a bunch
            let input = sequence + 'DDDD';

            let password = solveBathroomCode(input);

            // We should be at the bottom edge now

            expect(password).to.be.greaterThanOrEqual(7);
            expect(password).to.be.lessThanOrEqual(9);
        })
    ));

it('should strip leading white-space', () => {
    let input = '    U';

    let password = solveBathroomCode(input);

    expect(password).to.equal(2);
});
