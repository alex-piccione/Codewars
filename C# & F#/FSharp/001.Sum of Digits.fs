module FSharp.DigitalRoot

open System
open NUnit.Framework
open FsUnit

let charToInt = System.Globalization.CharUnicodeInfo.GetDigitValue 


let rec digitalRoot (n:int) =
    let digits = List.ofArray(n.ToString().ToCharArray())

    let count sum a =
        sum + (charToInt a)

    digits |> List.fold count 0



[<Test>]
let ``Digital Root``() =
    digitalRoot 16 |> should equal 7