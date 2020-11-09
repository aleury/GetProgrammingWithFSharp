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

    while true do
        Console.WriteLine(sprintf "Your account balance is now $%M!" account.Balance)
        
        Console.Write "What would you like to do? (deposit or withdraw) "
        let operation = Console.ReadLine()
        
        if operation = "exit" then Environment.Exit 0
        
        Console.Write(sprintf "What amount would you like to %s? " operation)
        let amount = Decimal.Parse(Console.ReadLine())
    
        account <-
            if operation = "deposit" then depositWithAudit amount account
            elif operation = "withdraw" then withdrawWithAudit amount account
            else account
    0
