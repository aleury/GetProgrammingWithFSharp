open System
open System.IO

type Customer = { Name: string }

type Account =
    { AccountId: System.Guid
      Balance: decimal
      Owner: Customer }

// Deposits an amount into an account
let deposit amount account: Account =
    { account with
          Balance = amount + account.Balance }

// Withdraws an amount from an account
let withdraw amount account: Account =
    if amount > account.Balance then
        account
    else
        { account with
              Balance = account.Balance - amount }

let adam = { Name = "Adam Eury" }

let account =
    { AccountId = Guid.NewGuid()
      Balance = 100m
      Owner = adam }

let fileSystemAudit account message =
    let directory = sprintf "./%s" account.Owner.Name
    if Directory.Exists(directory) = false
    then Directory.CreateDirectory(directory) |> ignore

    let path =
        account.AccountId.ToString()
        |> sprintf "%s/%s.txt" directory

    File.AppendAllLines(path, [| message |])

fileSystemAudit account "withdraw: 10"
fileSystemAudit account "deposit: 20"
fileSystemAudit account "withdraw: 30"
fileSystemAudit account "withdraw: 100"

let console account message =
    message
    |> sprintf "%s: %s" (account.AccountId.ToString())
    |> Console.WriteLine

console account "Testing console audit"

type AccountOp = decimal -> Account -> Account
type AuditLog = Account -> string -> unit

let auditAs (operationName: string)
             (audit: AuditLog)
             (operation: AccountOp)
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


let depositWithConsoleAudit = auditAs "deposit" console deposit
let withdrawWithConsoleAudit = auditAs "withdraw" console withdraw


let depositWithFileAudit = auditAs "deposit" fileSystemAudit deposit
let withdrawWithFileAudit = auditAs "withdraw" fileSystemAudit withdraw

account
|> depositWithConsoleAudit 40M
|> depositWithConsoleAudit 10M
|> withdrawWithConsoleAudit 10M
|> withdrawWithConsoleAudit 20M


account
|> depositWithFileAudit 20M
|> depositWithFileAudit 20M
|> depositWithFileAudit 30M
|> depositWithFileAudit 100M
|> withdrawWithFileAudit 10M
|> withdrawWithFileAudit 50M
|> withdrawWithFileAudit 100M
|> withdrawWithFileAudit 100M
|> withdrawWithFileAudit 100M