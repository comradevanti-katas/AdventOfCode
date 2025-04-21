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
    ({ dir: Dir.Right, dist: n }) satisfies Instruction;

export const goLeft = (n: number) =>
    ({ dir: Dir.Left, dist: n }) satisfies Instruction;

interface Position {
    x: number;
    y: number;
    lookDirection: LookDir;
}

export const calcShortestDistance = (
    instructions: ReadonlyArray<Instruction>
) => {
    const startPos: Position = { x: 0, y: 0, lookDirection: LookDir.North };
    const finalPos = instructions.reduce(calcNextPosition, startPos);
    return finalPos.x + finalPos.y;
};

const calcNextPosition = (prev: Position, movement: Instruction): Position => {
    switch (prev.lookDirection) {
        case LookDir.North:
            return {
                x:
                    prev.x +
                    movement.dist * (movement.dir === Dir.Left ? -1 : 1),
                y: prev.y,
                lookDirection:
                    movement.dir === Dir.Left ? LookDir.West : LookDir.East,
            };

        case LookDir.East:
            return {
                x: prev.x,
                y:
                    prev.y +
                    movement.dist * (movement.dir === Dir.Left ? 1 : -1),
                lookDirection:
                    movement.dir === Dir.Left ? LookDir.North : LookDir.South,
            };
        case LookDir.South:
            return {
                x:
                    prev.x +
                    movement.dist * (movement.dir === Dir.Left ? 1 : -1),
                y: prev.y,
                lookDirection:
                    movement.dir === Dir.Left ? LookDir.East : LookDir.West,
            };
        case LookDir.West:
            return {
                x: prev.x,
                y:
                    prev.y +
                    movement.dist * (movement.dir === Dir.Left ? -1 : 1),
                lookDirection:
                    movement.dir === Dir.Left ? LookDir.South : LookDir.North,
            };
    }
};
