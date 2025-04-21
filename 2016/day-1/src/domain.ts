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

interface Pos {
    x: number;
    y: number;
}

interface State extends Pos {
    lookDirection: LookDir;
}

const startState: State = { x: 0, y: 0, lookDirection: LookDir.North };

export const calcShortestDistance = (
    instructions: ReadonlyArray<Instruction>
) => {
    const endState = instructions.reduce(calcNextState, startState);
    return endState.x + endState.y;
};

function* positionsBetween(pos1: Pos, pos2: Pos) {
    if (pos1.y === pos2.y) {
        if (pos1.x < pos2.x)
            for (let x = pos1.x; x < pos2.x; x++)
                yield { x, y: pos1.y } satisfies Pos;
        else
            for (let x = pos1.x; x > pos2.x; x--)
                yield { x, y: pos1.y } satisfies Pos;
    } else if (pos1.x === pos2.x) {
        if (pos1.y < pos2.y)
            for (let y = pos1.y; y < pos2.y; y++)
                yield { x: pos1.x, y } satisfies Pos;
        else
            for (let y = pos1.y; y > pos2.y; y--)
                yield { x: pos1.x, y } satisfies Pos;
    } else throw new Error('Positions are not in vertical or horizontal line');
}

export const calcShortestDistanceToDuplicatedLocation = (
    instructions: ReadonlyArray<Instruction>
) => {
    const solve = (
        visited: ReadonlyArray<Pos>,
        remaining: ReadonlyArray<Instruction>,
        state: State
    ) => {
        const currentPos = { x: state.x, y: state.y } satisfies Pos;
        let instruction = remaining[0];

        // No instructions left
        // We went the whole path and found no intersection
        if (instruction === undefined) return null;

        const nextState = calcNextState(state, instruction);
        const newVisited = [...positionsBetween(currentPos, nextState)];

        let intersection = newVisited.find((pos) =>
            visited.some((it) => it.x === pos.x && it.y === pos.y)
        );
        if (intersection !== undefined) return intersection;

        return solve(
            [...visited, ...newVisited],
            remaining.slice(1),
            nextState
        );
    };

    const intersection = solve([], instructions, startState);

    if (intersection === null) return 0;

    return intersection.x + intersection.y;
};

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
