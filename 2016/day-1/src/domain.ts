export enum Dir {
    Right,
    Left,
}

export interface Instruction {
    readonly dir: Dir;
    readonly dist: number;
}

export const calcShortestDistance = (instructions: ReadonlyArray<Instruction>) => {
    throw new Error('Not implemented');
};
