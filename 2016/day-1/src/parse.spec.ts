import { expect, it } from 'vitest';
import { Dir } from './domain';
import { parseDir } from './parse';

it('should parse right', () => {
    let dir = parseDir('R');
    expect(dir).to.equal(Dir.Right);
});

it('should parse left', () => {
    let dir = parseDir('L');
    expect(dir).to.equal(Dir.Left);
});
