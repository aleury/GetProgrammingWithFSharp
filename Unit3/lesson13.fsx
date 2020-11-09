open System
open System.IO

type Customer = { Age: int }

let where filter items =
    seq {
        for item in items do
            if filter item then yield item
    }

let isOver35 customer = customer.Age > 35

let customers =
    [ { Age = 21 }
      { Age = 35 }
      { Age = 36 } ]

customers |> where isOver35

customers |> where (fun c -> c.Age < 35)

customers |> where (fun c -> c.Age >= 35)

//let printCustomerAge customer =
//    if customer.Age < 13 then Console.WriteLine "Child!"
//    elif customer.Age < 20 then Console.WriteLine "Teenager"
//    else Console.WriteLine "Adult!"

let printCustomerAge writer customer =
    if customer.Age < 13 then writer "Child!"
    elif customer.Age < 20 then writer "Teenager!"
    else writer "Adult!"

{ Age = 10 } |> printCustomerAge Console.WriteLine
{ Age = 14 } |> printCustomerAge Console.WriteLine
{ Age = 30 } |> printCustomerAge Console.WriteLine

{ Age = 10 } |> printCustomerAge id = "Child!"
{ Age = 14 } |> printCustomerAge id = "Teenager!"
{ Age = 30 } |> printCustomerAge id = "Adult!"

let printAgeToConsole = printCustomerAge Console.WriteLine
let printAgeToString = printCustomerAge id

{ Age = 10 } |> printAgeToConsole
{ Age = 14 } |> printAgeToConsole
{ Age = 30 } |> printAgeToConsole

{ Age = 10 } |> printAgeToString = "Child!"
{ Age = 14 } |> printAgeToString = "Teenager!"
{ Age = 30 } |> printAgeToString = "Adult!"

let writeToFile text = File.WriteAllText("./output.txt", text)

let printAgeToFile = printCustomerAge writeToFile

{ Age = 16 } |> printAgeToFile
File.ReadAllText("./output.txt")