import { Effect, pipe, String } from 'effect';
import { EOL } from 'os';
import { readInput } from './aocUtils';

const prepareInput = pipe(readInput(), Effect.map(String.split(EOL)));

const star1Program = pipe(
    prepareInput,
    Effect.map((lines) => lines.length),
    Effect.map((count) => `There are ${count} lines in the input.`)
);

Effect.runPromise(star1Program).then(console.log).catch(console.error);

const star2Program = pipe(
    prepareInput,
    Effect.map((lines) => lines.length),
    Effect.map((count) => `There are ${count} lines in the input.`)
);

Effect.runPromise(star2Program).then(console.log).catch(console.error);
