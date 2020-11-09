module Car 

let getDistance destination =
    if destination = "Gas" then 10
    elif destination = "Stadium" then 25
    elif destination = "Home" then 25
    elif destination = "Office" then 50
    else failwith "Unknown destination!"

let getRemainingPetrol petrol distance =
    if petrol >= distance then petrol - distance
    else failwith "Oops! You've run out of petrol."

// Drives to a given destination given a starting amount of petrol
let driveTo petrol destination =
    let distance = getDistance destination
    let remaining = getRemainingPetrol petrol distance
    
    if destination = "Gas" then remaining + 50
    else remaining
    