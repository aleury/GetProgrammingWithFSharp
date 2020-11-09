let getDistance destination =
    if destination = "Gas" then 10
    elif destination = "Stadium" then 25
    elif destination = "Home" then 25
    elif destination = "Office" then 50
    else failwith "Unknown destination!"

getDistance "Gas" = 10
getDistance "Stadium" = 25
getDistance "Home" = 25
getDistance "Office" = 50
getDistance "Somewhere Else"

let getRemainingPetrol petrol distance =
    if petrol >= distance then petrol - distance
    else failwith "Oops! You've run out of petrol."
    
getRemainingPetrol 100 (getDistance "Gas") = 90
getRemainingPetrol 100 (getDistance "Office") = 50
getRemainingPetrol 100 (getDistance "Stadium") = 75
getRemainingPetrol 50 (getDistance "Home") = 25
getRemainingPetrol 10 (getDistance "Gas") = 0
getRemainingPetrol 10 (getDistance "Office") // raises exception

let driveTo' petrol destination =
    let distance = getDistance destination
    getRemainingPetrol petrol distance
    
    
driveTo' 100 "Gas" = 90
driveTo' 100 "Stadium" = 75
driveTo' 100 "Home" = 75
driveTo' 100 "Office" = 50

driveTo' 50 "Gas" = 40
driveTo' 50 "Stadium" = 25
driveTo' 50 "Home" = 25
driveTo' 50 "Office" = 0

driveTo' 25 "Gas" = 15
driveTo' 25 "Stadium" = 0
driveTo' 25 "Home" = 0
driveTo' 25 "Office" // raises exception

let driveTo petrol destination = 
    let remaining = 
        getRemainingPetrol petrol (getDistance destination)
    if destination = "Gas" then remaining + 50
    else remaining

let a = driveTo 100 "Office"
let b = driveTo a "Stadium"
let c = driveTo b "Gas"
let answer = driveTo c "Home"