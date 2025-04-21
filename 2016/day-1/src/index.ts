import { Array, Effect, pipe, String } from 'effect';
import { readInput } from './aocUtils';
import {
    calcShortestDistance,
    calcShortestDistanceToDuplicatedLocation,
} from './domain';
import { parseInstruction } from './parse';

const getInstructions = pipe(
    readInput(),
    Effect.map(String.split(', ')),
    Effect.map(Array.map(parseInstruction))
);

const star1Program = pipe(
    getInstructions,
    Effect.map(calcShortestDistance),
    Effect.map((dist) => `The shortest distance is ${dist} blocks`)
);

Effect.runPromise(star1Program).then(console.log).catch(console.error);

const star2Program = pipe(
    getInstructions,
    Effect.map(calcShortestDistanceToDuplicatedLocation),
    Effect.map(
        (dist) =>
            `The shortest distance to a twice visited block is ${dist} blocks`
    )
);

Effect.runPromise(star2Program).then(console.log).catch(console.error);
