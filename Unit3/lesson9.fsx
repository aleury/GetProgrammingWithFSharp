open System

let parseName (name: string) =
    let parts = name.Split(' ')
    let forename = parts.[0]
    let surname = parts.[1]
    forename, surname
    
let name = parseName "Isaac Abraham"
let forename, surname = name
let fname, sname = parseName "Isaac Abraham"

let a = "isaac", "abraham", 35


let parse (person: string) =
    let parts = person.Split(' ')
    let playerName = parts.[0]
    let game = parts.[1]
    let score = int parts.[2]
    playerName, game, score

let personName, game, score = parse "Mary Asteroids 2500"
let personName2, game2, score2 = parse "Adam Tetris 9000"


let nameAndAge = "Joe", "Bloggs", 28
let forename', surname', _ = nameAndAge

let nameAndAgeNested = ("Joe", "Bloggs"), 28

let name', age = nameAndAgeNested
let (fname', sname'), age' = nameAndAgeNested

let number = "1234"
let parsed, result = Int32.TryParse number
