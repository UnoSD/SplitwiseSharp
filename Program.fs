open System
open FSharp.Data
open System.Text.Json
open FSharp.Data.HttpRequestHeaders
let apiKey =
    Environment.GetEnvironmentVariable("SPLITWISE_APIKEY")
    
let friendId =
    Environment.GetEnvironmentVariable("SPLITWISE_FRIEND_ID")
    
let userId =
    Environment.GetEnvironmentVariable("SPLITWISE_USER_ID")
    
let request method path body =
    Http.RequestString($"https://secure.splitwise.com/api/v3.0/{path}",
                       headers    = [ Authorization $"Bearer {apiKey}"
                                      ContentType   HttpContentTypes.Json ],
                       httpMethod = method,
                       body       = (JsonSerializer.Serialize body |> TextRequest))

let post path body =
    request HttpMethod.Post path body

let tap fn x =
    fn x
    x

let expense =
    {|
        cost                 = "10.00"
        group_id             = 0
        description          = "Description"
        details              = ""
        date                 = DateTime.Now.ToString("O")
        repeat_interval      = "never"
        currency_code        = "GBP"
        category_id          = "2" // Uncategorized
        users__0__user_id    = friendId
        users__0__paid_share = "0"
        users__0__owed_share = "10.00"
        users__1__user_id    = userId
        users__1__paid_share = "10.00"
        users__1__owed_share = "0"
    |}

//expense
//|> tap (printfn "%A")
//|> post "create_expense"
//|> printfn "%A"

open SplitwiseSharp
open System.Net.Http
open SplitwiseSharp.Types
open System.Net.Http.Headers

let httpClient =
    new HttpClient(BaseAddress = (Uri "https://secure.splitwise.com/api/v3.0"))

httpClient.DefaultRequestHeaders.Authorization <-
    AuthenticationHeaderValue("Bearer", apiKey)
    
let client =
    SplitwiseSharpClient(httpClient)

match client.GetGetCurrentUser() with
| GetGetCurrentUser.OK currentuser   -> currentuser |> printfn "%A"
| GetGetCurrentUser.Unauthorized err -> printfn $"Unauthorized: {err}"