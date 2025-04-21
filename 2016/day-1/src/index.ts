import {Effect, pipe, String} from 'effect';
import {readInput} from './aocUtils';

const program = pipe(
  readInput(),
  Effect.map(String.split(", ")),
  Effect.map((lines) => lines.length),
  Effect.map((count) => `There are ${count} lines in the input.`)
);

Effect.runPromise(program).then(console.log).catch(console.error);


