import { expect, it } from 'vitest';
import { solveBathroomCode } from './domain';

it('should give result for single input', () => {
    let password = solveBathroomCode('U');
    expect(password).to.equal(2);
});

it('should give result for single corner input', () => {
    let password = solveBathroomCode('UR');
    expect(password).to.equal(3);
});

