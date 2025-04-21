import { Array, Effect, pipe, String } from 'effect';
import { readInput } from './aocUtils';
import { calcShortestDistance } from './domain';
import { parseInstruction } from './parse';

const program = pipe(
    readInput(),
    Effect.map(String.split(', ')),
    Effect.map(Array.map(parseInstruction)),
    Effect.map(calcShortestDistance),
    Effect.map((dist) => `The shortest distance is ${dist} blocks`)
);

Effect.runPromise(program).then(console.log).catch(console.error);
