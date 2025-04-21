import { Effect, pipe, String } from 'effect';
import { EOL } from 'os';
import { readInput } from './aocUtils';
import { solveBathroomCode } from './domain';

const star1Program = pipe(
    readInput(),
    Effect.map(solveBathroomCode),
    Effect.map((code) => `The code is "${code}"`)
);

Effect.runPromise(star1Program).then(console.log).catch(console.error);

const star2Program = pipe(
    readInput(),
    Effect.map(String.split(EOL)),
    Effect.map((lines) => lines.length),
    Effect.map((count) => `There are ${count} lines in the input.`)
);

Effect.runPromise(star2Program).then(console.log).catch(console.error);
