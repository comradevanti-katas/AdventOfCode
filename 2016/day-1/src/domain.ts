export enum Dir {
    Right,
    Left,
}

export interface Instruction {
    readonly dir: Dir;
    readonly dist: number;
}

export const goRight = (n: number) =>
    ({ dir: Dir.Right, dist: n } satisfies Instruction);

export const goLeft = (n: number) =>
    ({ dir: Dir.Left, dist: n } satisfies Instruction);

export const calcShortestDistance = (
    instructions: ReadonlyArray<Instruction>
) => {
    return instructions.reduce((previousValue, b) => previousValue + b.dist, 0);
};
