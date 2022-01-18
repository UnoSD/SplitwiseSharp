open System
open SplitwiseSharp
open System.Net.Http
open SplitwiseSharp.Types
open System.Net.Http.Headers

let apiKey, friendId, userId =
    Environment.GetEnvironmentVariable("SPLITWISE_APIKEY"),
    Environment.GetEnvironmentVariable("SPLITWISE_FRIEND_ID"),
    Environment.GetEnvironmentVariable("SPLITWISE_USER_ID")

let httpClient =
    new HttpClient(BaseAddress = (Uri "https://secure.splitwise.com/api/v3.0"))

httpClient.DefaultRequestHeaders.Authorization <-
    AuthenticationHeaderValue("Bearer", apiKey)
    
let client =
    SplitwiseSharpClient(httpClient)

match client.GetGetCurrentUser() with
| GetGetCurrentUser.OK currentuser   -> currentuser |> printfn "%A"
| GetGetCurrentUser.Unauthorized err -> printfn $"Unauthorized: {err}"