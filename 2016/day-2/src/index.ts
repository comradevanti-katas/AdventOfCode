import { Effect, pipe, String } from 'effect';
import { EOL } from 'os';
import { readInput } from './aocUtils';
import { solveAdvancedBathroomCode, solveBathroomCode } from './domain';

const star1Program = pipe(
    readInput(),
    Effect.map(solveBathroomCode),
    Effect.map((code) => `The code is "${code}"`)
);

Effect.runPromise(star1Program).then(console.log).catch(console.error);

const star2Program = pipe(
    readInput(),
    Effect.map(solveAdvancedBathroomCode),
    Effect.map((code) => `The advanced code is "${code}"`)
);

Effect.runPromise(star2Program).then(console.log).catch(console.error);
