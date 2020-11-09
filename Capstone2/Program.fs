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
    let name =
        Console.Write "Enter your name: "
        Console.ReadLine()

    let balance =
        Console.Write "Enter your opening balance: "
        Console.ReadLine() |> Decimal.Parse

    let customer = { Name = name }
    let mutable account = Operations.openAccount balance customer

    while true do
        let operation =
            Console.WriteLine(sprintf "Your account balance is now $%M!" account.Balance)
            Console.Write "What would you like to do? (deposit, withdraw, or exit) "
            Console.ReadLine()

        if operation = "exit" then Environment.Exit 0

        let amount =
            Console.Write(sprintf "What amount would you like to %s? " operation)
            Console.ReadLine() |> Decimal.Parse

        account <-
            if operation = "deposit" then depositWithAudit amount account
            elif operation = "withdraw" then withdrawWithAudit amount account
            else account
    0
