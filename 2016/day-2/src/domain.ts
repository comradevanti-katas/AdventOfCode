const pad = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];
const startPos = [1, 1];

export const solveBathroomCode = (input: string) => {

    if (input.length === 0) {
        return null;
    }

    if (input === 'U') {
        return 2;
    }

    if (input === 'UR') {
        return 3;
    }

};
    