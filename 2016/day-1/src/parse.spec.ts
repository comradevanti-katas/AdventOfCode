import { expect, it } from 'vitest';
import { Dir } from './domain';
import { parseDir, parseInstruction } from './parse';

it('should parse right', () => {
    let dir = parseDir('R');
    expect(dir).to.equal(Dir.Right);
});

it('should parse left', () => {
    let dir = parseDir('L');
    expect(dir).to.equal(Dir.Left);
});

it('should parse left instruction', () => {
    let instruction = parseInstruction('L3');
    expect(instruction).to.deep.equal({
        dir: Dir.Left,
        dist: 3,
    });
});

it('should parse left instruction', () => {
    let instruction = parseInstruction('R7');
    expect(instruction).to.deep.equal({
        dir: Dir.Right,
        dist: 7,
    });
});
