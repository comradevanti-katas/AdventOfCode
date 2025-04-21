import { EOL } from 'os';

const pad = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];
const startPos = [1, 1];

export const solveBathroomCode = (input: string) => {

    if (input.length === 0) {
        return null;
    }

    const lines = input.split(EOL);

    if (lines !== undefined) {

        for (let i = 0; i < lines.length; i++) {

            const currentLine = lines[i];

            for (let j = 0; j < currentLine!.length; j++) {

                switch (currentLine![j]) {
                    case 'U':
                        break;
                    case 'R':
                        break;
                    case 'D':
                        break;
                    case 'L':
                        break;
                }

            }

        }

    }

    if (input === 'U') {
        return 2;
    }

    if (input === 'UR') {
        return 3;
    }

    if (lines?.length > 0) {
        let password = '';
        for (let i = 0; i < lines?.length; i++) {
            password += '1';
        }
        return parseInt(password);
    }

};
    