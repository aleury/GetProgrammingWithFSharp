// Learn more about F# at http://fsharp.org

open System

[<EntryPoint>]
let main argv =
    let items = argv.Length 
    printfn "Passed in %d items: %A" items argv 
    printfn "Hello World from F#!"
    0 // return an integer exit code
