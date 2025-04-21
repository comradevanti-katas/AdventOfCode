import { expect, it } from 'vitest';
import { calcShortestDistance } from './domain';

it('should be zero for empty instructions', () => {
    const distance = calcShortestDistance([]);

    expect(distance).to.equal(0);
});
