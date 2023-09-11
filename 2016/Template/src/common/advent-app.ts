import {open, readFile} from "fs/promises"
import {EOL} from 'os'
import {resolvePlugin} from "@babel/core";

export type Reader<TInput extends string | string[]> = () => Promise<TInput | null>

export type Parser<TInput, TParsed extends {}> = (input: TInput) => TParsed | null

export type Solver<TParsed, TOutput> = (parsed: TParsed) => TOutput

export type Printer<TOutput> = (output: TOutput) => string

export type AdventApp = () => Promise<string>


export const readText: Reader<string> = async () => {
    let inputPath = process.env.INPUT
    if (inputPath === undefined) return null
    return await readFile(inputPath, "utf-8")
}

export const readLines: Reader<string[]> = async () => {
    let text = await readText()
    if (text === null) return null
    return text.split(EOL).filter(Boolean)
}

export function parseEachWith<T, U extends {}>(parse: Parser<T, U>): Parser<T[], U[]> {
    return items => {
        let parsed = items.map(parse);
        if (parsed.includes(null)) return null
        return parsed as U[]
    }
}

export const tryParseInt: Parser<string, number> = (s: string) => {
    let parsed = parseInt(s)
    return isNaN(parsed) ? null : parsed
};
export const tryParseFloat: Parser<string, number> = (s: string) => {
    let parsed = parseFloat(s)
    return isNaN(parsed) ? null : parsed
};

export function makeAdventApp<TInput extends string | string[], TParsed extends {}, TOutput>(
    read: Reader<TInput>,
    parse: Parser<TInput, TParsed>,
    solve: Solver<TParsed, TOutput>,
    print: Printer<TOutput>
): AdventApp {
    return async () => {
        let input = await read()
        if (input === null) return "Could not read input"

        let parsed = parse(input)
        if (parsed === null) return "Could not parse"

        let output = solve(parsed)
        return print(output)
    }
}
