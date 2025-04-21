import { Effect } from 'effect';
import fs from 'fs/promises';
import { argv } from 'process';

/**
 * Reads all text from the input file. The file path is retrieved from the
 * first command-line argument.
 * @returns The input.
 */
export const readInput = () =>
    Effect.promise(() => {
        const inputPath = argv[2];
        if (inputPath === undefined) {
            throw new Error('Input file path omitted.');
        }

        return fs.readFile(inputPath, 'utf-8');
    });
