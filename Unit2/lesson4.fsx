open System

let doStuffWithTwoNumbers first second =
    let sum = first + second
    Console.WriteLine("{0} + {1} + {2}", first, second, sum)
    let doubled = sum * 2
    doubled
    

let estimatedAge =
    let age =
        let year = DateTime.Now.Year
        year - 1979
    sprintf "You are about %d years old!" age
    
    
let estimateAges familyName year1 year2 year3 =
    let calculateAge yearOfBirth =
        let year = DateTime.Now.Year
        year - yearOfBirth
         
    let age1 = calculateAge year1
    let age2 = calculateAge year2
    let age3 = calculateAge year3
    
    let averageAge = (age1 + age2 + age3) / 3
    sprintf "Average age for family %s is %d" familyName averageAge
    

estimateAges "Eury" 1960 1988 1989