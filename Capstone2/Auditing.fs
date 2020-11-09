module Capstone2.Auditing

open System
open System.IO
open Capstone2.Domain

let console account message =
    message
    |> sprintf "%s: %s" (account.AccountId.ToString())
    |> Console.WriteLine


let filesystem account message =
    let directory = sprintf "./%s" account.Owner.Name
    if not (Directory.Exists directory)
    then Directory.CreateDirectory(directory) |> ignore

    let path =
        account.AccountId.ToString()
        |> sprintf "%s/%s.txt" directory

    File.AppendAllLines(path, [| message |])
