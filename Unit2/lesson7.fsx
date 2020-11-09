open System
open System.IO

let describeAge age =
    let greeting = "Hello"

    let ageDescription =
        if age < 18 then "Child!"
        elif age < 65 then "Adult!"
        else "OAP!"
    
    Console.WriteLine("{0}! You are a '{1}'.", greeting, ageDescription)

describeAge 16
describeAge 32
describeAge 60
describeAge 68

// unit literal
let x = ()
let ageDescription = describeAge 30
x = ageDescription // values are equal

// ignore allows you to execute an expression
// similarly to a statement by throwing away the result.
let writeTextToDisk text =
    let path = Path.GetTempFileName()
    File.WriteAllText(path, text)
    path
    
let createManyFiles () =
    writeTextToDisk "The quick brown fox jumped over the lazy dog." |> ignore
    writeTextToDisk "The quick brown fox jumped over the lazy dog." |> ignore
    writeTextToDisk "The quick brown fox jumped over the lazy dog." |> ignore
    