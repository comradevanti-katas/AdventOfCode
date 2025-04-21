import { flow, String } from 'effect';

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

export const solveAdvancedBathroomCode = (input: string) => {
    const lines = splitIntoLines(input);

    return Array.from({ length: lines.length })
        .map(() => 'A')
        .join('');
};

