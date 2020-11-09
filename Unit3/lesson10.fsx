type Address =
    { Street: string
      Town: string
      City: string }

type Customer =
    { Forename: string
      Surname: string
      Age: int
      Address: Address
      EmailAddress: string }

let customer =
    { Forename = "Joe"
      Surname = "Bloggs"
      Age = 30
      Address =
          { Street = "The Street"
            Town = "The Town"
            City = "The City" }
      EmailAddress = "joe@bloggs.com" }

customer.Address.City

let printAddress address =
    printfn "Address is %s, %s" address.Street address.City

printAddress customer.Address

type Car =
    { Manufacturer: string
      Engine: string
      Doors: int }

let car =
    { Manufacturer = "Honda"
      Engine = "V6"
      Doors = 4 }

sprintf "%s %s with %d doors" car.Manufacturer car.Engine car.Doors

// updating records
let updatedCustomer =
    { customer with
          Age = 31
          EmailAddress = "joe@bloggs.co.uk" }


// equality checking
let address =
    { Street = "21029 Bear Creek Church RD"
      Town = "Millingport"
      City = "New London" }

let explicitAddress: Address =
    { Street = "21029 Bear Creek Church RD"
      Town = "Millingport"
      City = "New London" }

let isSameAddress = (address = explicitAddress)


let customer2 =
    { Forename = "Joe"
      Surname = failwith "todo"
      Age = failwith "todo"
      Address = failwith "todo"
      EmailAddress = failwith "todo" }
