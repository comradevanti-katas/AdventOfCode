import { Dir } from "./domain";

export const parseDir = (s: string) => {
    if(s === "R"){
        return Dir.Right;
    }

    if(s === "L"){
        return Dir.Left;
    }

    throw new Error("Bad Direction Input");
};
