import {Effect, pipe, String, Array} from 'effect';
import {readInput} from './aocUtils';
import {parseInstruction} from "./parse";
import {calcShortestDistance} from "./domain";

const program = pipe(
  readInput(),
  Effect.map(String.split(", ")),
  Effect.map(Array.map(parseInstruction)),
  Effect.map((instructionArray) => calcShortestDistance(instructionArray))
);

Effect.runPromise(program).then(console.log).catch(console.error);


