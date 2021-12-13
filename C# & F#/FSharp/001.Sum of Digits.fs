module FSharp.DigitalRoot

open System
open NUnit.Framework
open FsUnit

let charToInt = System.Globalization.CharUnicodeInfo.GetDigitValue 


let rec digitalRoot (n:int) =
    match n < 10 with
    | true -> n
    | _ -> 
        n.ToString().ToCharArray()
        |> Array.fold (fun sum a -> sum + (charToInt a)) 0
        |> digitalRoot



[<Test>]
let ``Digital Root``() =
    digitalRoot 16 |> should equal 7
    digitalRoot 942 |> should equal 6
    digitalRoot 132189 |> should equal 6
    digitalRoot 493193 |> should equal 2