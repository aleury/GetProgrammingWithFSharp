// partial function application
let tupledAdd (a, b) = a + b
let answer = tupledAdd (5, 10)

let curriedAdd a b = a + b
let answer2 = curriedAdd 5 10

//let add first second = first + second
//let addFive = add 5
//let fifteen = addFive 10

// constraining functions
open System

let buildDt year month day = DateTime(year, month, day)
let buildDtThisYear = buildDt DateTime.UtcNow.Year
let buildDtThisMonth = buildDtThisYear DateTime.UtcNow.Month

// challenge
open System.IO

let writeToFile (date: DateTime) filename text =
    let path =
        sprintf "%s-%s.txt" (date.ToString "yyMMdd") filename

    File.WriteAllText(path, text)

let writeToToday = writeToFile DateTime.UtcNow.Date

let writeToTomorrow =
    writeToFile (DateTime.UtcNow.Date.AddDays 1.)

let writeToTodayHelloWorld = writeToToday "hello-world"


writeToToday "first-file" "The quick brown fox jumped over the lazy dog."
writeToTomorrow "second-file" "The quick brown fox jumped over the lazy dog."
writeToTodayHelloWorld "The quick brown fox jumped over the lazy dog."

// piplines

let checkCreation (date: DateTime) =
    let sevenDaysAgo = DateTime.UtcNow.Date.AddDays -7.
    if date >= sevenDaysAgo then "New" else "Old"

let time' =
    let directory = Directory.GetCurrentDirectory()
    Directory.GetCreationTime directory

checkCreation time'

Directory.GetCurrentDirectory()
|> Directory.GetCreationTime
|> checkCreation

// sample pipeline dsl
let add a b = a + b
let timesBy a b = a * b
let result =
    10
    |> add 5
    |> timesBy 2
    |> add 20
    |> add 7
    |> timesBy 3
    
let drive distance petrol =
    if distance = "far" then petrol / 2.0
    elif distance = "medium" then petrol - 10.0
    else petrol - 1.0

let startingPetrol = 100.0

let endingPetrol = 
    startingPetrol
    |> drive "far"
    |> drive "medium"
    |> drive "short"
    
// composing functions together
let checkCurrentDirectoryAge =
    Directory.GetCurrentDirectory
    >> Directory.GetCreationTime
    >> checkCreation
let description = checkCurrentDirectoryAge()