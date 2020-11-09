module Capstone2.Operations

open System
open Capstone2.Domain

type AuditLog = Account -> string -> unit

type AccountOperation = decimal -> Account -> Account

// Open a new account for a customer
let openAccount balance owner =
    { AccountId = Guid.NewGuid()
      Balance = balance
      Owner = owner }

// Deposits an amount into an account
let deposit amount account =
    { account with
          Balance = amount + account.Balance }

// Withdraws an amount from an account
let withdraw amount account =
    if amount > account.Balance then
        account
    else
        { account with
              Balance = account.Balance - amount }

// Audits an operation to an account with a given amount
let auditAs (operationName: string)
            (audit: AuditLog)
            (operation: AccountOperation)
            (amount: decimal)
            (account: Account)
            : Account =
    let updatedAccount = account |> operation amount

    let balanceChanged =
        updatedAccount.Balance <> account.Balance

    if balanceChanged
    then audit account (sprintf "%s $%M" operationName amount)
    else audit account (sprintf "Rejected %s $%M" operationName amount)

    updatedAccount
