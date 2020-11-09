// immutability

let name = "isaac"  // create immutable value
name = "kate"  // attempt to change immutable value fails
printfn "%s" name

// attempt mutate immutable value fails
// name <- "kate"

// mutable value
let mutable name' = "isaac"
name' <- "kate"
printfn "%s" name'

// managing state with mutable variables
//let mutable petrol = 100.0
//let drive distance =
//    if distance = "far" then petrol <- petrol / 2.0
//    elif distance = "medium" then petrol <- petrol - 10.0
//    else petrol <- petrol - 1.0
//
//drive "far"
//drive "medium"
//drive "short"
//petrol

// managing state with immutable variables
let drive petrol distance =
    if distance > 50 then petrol / 2.0
    elif distance > 25 then petrol - 10.0
    elif distance > 0 then petrol - 1.0
    else petrol
    
let petrol = 100.0
let firstState = drive petrol 55
let secondState = drive firstState 30
let finalState = drive secondState 10
