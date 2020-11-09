// Learn more about F# at http://fsharp.org

open System
open Capstone2
open Capstone2.Domain

let depositWithAudit =
    Operations.auditAs "deposit" Auditing.console Operations.deposit

let withdrawWithAudit =
    Operations.auditAs "withdraw" Auditing.console Operations.withdraw

[<EntryPoint>]
let main (_argv: string []): int =
    Console.Write "Enter your name: "
    let name = Console.ReadLine()

    Console.Write "Enter your opening balance: "
    let balance = Decimal.Parse(Console.ReadLine())

    let customer = { Name = name }
    let mutable account = Operations.openAccount balance customer
    
    let validOps = List.ofArray([|"deposit"; "withdraw"|])

    while true do
        Console.Write "What would you like to do? (deposit or withdraw) "
        let operation = Console.ReadLine()
        
        if List.contains operation validOps then
            Console.Write(sprintf "What amount would you like to %s? " operation)
            let amount = Decimal.Parse(Console.ReadLine())
            
            Console.WriteLine(sprintf "Performing `%s` of %M from your account.." operation amount)
            match operation with
            | "deposit" -> account <- depositWithAudit amount account
            | "withdraw" -> account <- withdrawWithAudit amount account
            | _ -> account <- account // TODO: Remove this eventually.

            Console.WriteLine(sprintf "Your account balance is now $%M!" account.Balance)
        else
            Console.WriteLine "I don't recognize that operation. Please try again..."

    0
