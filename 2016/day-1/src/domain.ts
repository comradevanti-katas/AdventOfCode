export enum Dir {
    Right,
    Left,
}

export enum LookDir {
    North,
    East,
    South,
    West,
}

export interface Instruction {
    readonly dir: Dir;
    readonly dist: number;
}

export const goRight = (n: number) =>
    ({ dir: Dir.Right, dist: n } satisfies Instruction);

export const goLeft = (n: number) =>
    ({ dir: Dir.Left, dist: n } satisfies Instruction);

interface State {
    x: number;
    y: number;
    lookDirection: LookDir;
}

export const calcShortestDistance = (
    instructions: ReadonlyArray<Instruction>
) => {
    const startState: State = { x: 0, y: 0, lookDirection: LookDir.North };
    const endState = instructions.reduce(calcNextState, startState);
    return endState.x + endState.y;
};

export const calcShortestDistanceToDuplicatedLocation = (
    instructions: ReadonlyArray<Instruction>
) => {};

const turn = (facing: LookDir, dir: Dir) => {
    switch (facing) {
        case LookDir.North:
            return dir === Dir.Left ? LookDir.West : LookDir.East;
        case LookDir.East:
            return dir === Dir.Left ? LookDir.North : LookDir.South;
        case LookDir.South:
            return dir === Dir.Left ? LookDir.East : LookDir.West;
        case LookDir.West:
            return dir === Dir.Left ? LookDir.South : LookDir.North;
    }
};

const calcNextState = (prev: State, movement: Instruction): State => {
    const nextLookDir = turn(prev.lookDirection, movement.dir);
    switch (prev.lookDirection) {
        case LookDir.North:
            return {
                x:
                    prev.x +
                    movement.dist * (movement.dir === Dir.Left ? -1 : 1),
                y: prev.y,
                lookDirection: nextLookDir,
            };

        case LookDir.East:
            return {
                x: prev.x,
                y:
                    prev.y +
                    movement.dist * (movement.dir === Dir.Left ? 1 : -1),
                lookDirection: nextLookDir,
            };
        case LookDir.South:
            return {
                x:
                    prev.x +
                    movement.dist * (movement.dir === Dir.Left ? 1 : -1),
                y: prev.y,
                lookDirection: nextLookDir,
            };
        case LookDir.West:
            return {
                x: prev.x,
                y:
                    prev.y +
                    movement.dist * (movement.dir === Dir.Left ? -1 : 1),
                lookDirection: nextLookDir,
            };
    }
};
