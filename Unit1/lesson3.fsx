open System.IO

let text = "Hello, World"
text.Length

let greetPerson name age =
    sprintf "Hello, %s. You are %d years old." name age
    
greetPerson "Adam" 32
greetPerson "Tiffany" 30
greetPerson "Mark" 32


let countWords (text: string) =
    let count = text.Split().Length
    let result = sprintf "%s, %d\n" text count
    File.WriteAllText("./wordCounts.txt", result)
    
countWords "Hello, World. My name is Adam Eury!"