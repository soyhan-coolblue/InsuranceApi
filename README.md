## Prerequisites

I updated `ASP .NET Core` from `3.1` to `5.0`, to take advantage of some C# 9 language features therefore [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0) is required to be installed.

## Architecture Design

I have split the solution into four separate projects, `Api`, `Application` , `Domain` and `Infrastructure`.

`Api` - ASP .NET Core Web Api that exposes our endpoints to clients. Ive included  `MediatR` library to decouple domain entities to the public and also leverage the behaviours that we could provide ie. `PerformanceBehaviour` to proactively log when requests exceed a defined criteria such as 500 milliseconds.

`Application` - A class Library that encapsulate all business logic. Ive implemented the builder pattern for building up the business rules on the insurance rules to easily expand on the logic without affecting already implemented rules.

`Domain` - A class Library that contains all objects types reusable throughout our solution.

`Infrasture` - A class Library that abstracts and the underlying providers all dependancies external to our core application and allows us to easiy replace one implementation for another ie. Nhibernate instead of EntityFramework.

## Assumptions

### Task 3 - Feature 1

> I created an endpoint that would allow multiple products to be sent at once.
I've decided to get product one at time and get all the product types once making less server requests.

### Task 5 - Feature 3

> There is no endpoint provided to execute this task that would allow me to expose an endpoint that would update the source data when retrieving the data back, I could provide a 'mock' endpoint that would accept the surcharge and later apply correct implementation but Im not happy with storying that data in memory and applying them on the fly, I think if a persistance layer were to be added, I'd be more comfortable adding such a feature.


## Comments