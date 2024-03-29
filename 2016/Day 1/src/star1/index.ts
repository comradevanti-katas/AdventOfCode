import 'dotenv/config'
import {readFile} from "fs/promises"
import {tryParse} from '../common/parse.js'
import {Direction, locationAt} from "../common/domain.js";
import {afterMove, distanceOf, origin} from "../common/traversal.js";

async function star1() {
    let inputPath = process.env.INPUT
    if (inputPath === undefined) throw new Error("No input path")

    let inputString = await readFile(inputPath, "utf-8")
    
    let moves = tryParse(inputString)
    if (moves === null) throw new Error("Could not parse input")
    
    let start = locationAt(origin, Direction.North)
    let end = moves.reduce(afterMove, start)
    let distance = distanceOf(end.intersection)
    
    console.log(`Final distance is ${distance}`)
}

star1()