import { Array, flow, Iterable, Option, pipe, String } from 'effect';

const pad = [
    [1, 2, 3],
    [4, 5, 6],
    [7, 8, 9],
];
const startPos: [number, number] = [1, 1];

const splitIntoLines = flow(String.trim, String.split(/[\n\r]+/));

export const solveBathroomCode = (input: string) => {
    if (input.length === 0) {
        return null;
    }

    const lines = splitIntoLines(input);
    let password = '';
    let currentPos: [number, number] = startPos;

    if (lines !== undefined) {
        for (let i = 0; i < lines.length; i++) {
            const currentLine = lines[i]!.trim();

            if (currentLine !== undefined) {
                for (let j = 0; j < currentLine!.length; j++) {
                    switch (currentLine![j]) {
                        case 'U':
                            currentPos = [
                                currentPos[0],
                                currentPos[1] !== 0
                                    ? currentPos[1] - 1
                                    : currentPos[1],
                            ];
                            break;
                        case 'R':
                            currentPos = [
                                currentPos[0] !== 2
                                    ? currentPos[0] + 1
                                    : currentPos[0],
                                currentPos[1],
                            ];
                            break;
                        case 'D':
                            currentPos = [
                                currentPos[0],
                                currentPos[1] !== 2
                                    ? currentPos[1] + 1
                                    : currentPos[1],
                            ];
                            break;
                        case 'L':
                            currentPos = [
                                currentPos[0] !== 0
                                    ? currentPos[0] - 1
                                    : currentPos[0],
                                currentPos[1],
                            ];
                            break;
                    }
                }
            }

            password += pad[currentPos[1]]![currentPos[0]];
        }

        return parseInt(password);
    }
};

const advancedPad = [
    [undefined, undefined, '1', undefined, undefined],
    [undefined, '2', '3', '4', undefined],
    ['5', '6', '7', '8', '9'],
    [undefined, 'A', 'B', 'C', undefined],
    [undefined, undefined, 'D', undefined, undefined],
] as const;

function* iterChars(s: string) {
    for (let i = 0; i < s.length; i++) yield s[i]!;
}

type Dir = 'U' | 'R' | 'D' | 'L';

type Pos = readonly [number, number];

const movePos = ([x, y]: Pos, dir: Dir) => {
    switch (dir) {
        case 'U':
            return [x, y - 1] as const;
        case 'R':
            return [x + 1, y] as const;
        case 'D':
            return [x, y + 1] as const;
        case 'L':
            return [x - 1, y] as const;
    }
};

const parseDir = (s: string) => s as Dir;

const getPadAt = ([x, y]: Pos) => advancedPad[y]?.[x]!;

export const solveAdvancedBathroomCode = (input: string) => {
    const solveLine = (startPos: Pos, line: string) =>
        pipe(
            line,
            iterChars,
            Iterable.map(parseDir),
            Iterable.reduce(startPos, (pos, dir) => {
                const nextPos = movePos(pos, dir);

                const moveIsPossible = getPadAt(nextPos) !== undefined;

                return moveIsPossible ? nextPos : pos;
            })
        );

    return pipe(
        input,
        splitIntoLines,
        Array.reduce([[0, 2] as Pos], (positions, line) => {
            const startPos = Option.getOrThrow(Array.last(positions));

            const nextPos = solveLine(startPos, line);

            return [...positions, nextPos];
        }),
        Array.drop(1),
        Array.map(getPadAt),
        Array.join('')
    );
};
