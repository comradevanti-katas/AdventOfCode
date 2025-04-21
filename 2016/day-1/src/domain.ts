export enum Dir {
    Right,
    Left,
}

export interface Instruction {
    readonly dir: Dir;
    readonly dist: number;
}

export const calcShortestDistance = (instructions: ReadonlyArray<Instruction>) => {
    return instructions.reduce((previousValue,b) => previousValue + b.dist, 0);
};
