open System
open SplitwiseSharp
open System.Net.Http
open SplitwiseSharp.Types
open System.Net.Http.Headers

let apiKey, friendId, userId =
    Environment.GetEnvironmentVariable("SPLITWISE_APIKEY"),
    Environment.GetEnvironmentVariable("SPLITWISE_FRIEND_ID") |> int,
    Environment.GetEnvironmentVariable("SPLITWISE_USER_ID")   |> int

let httpClient =
    new HttpClient(BaseAddress = (Uri "https://secure.splitwise.com/api/v3.0"))

httpClient.DefaultRequestHeaders.Authorization <-
    AuthenticationHeaderValue("Bearer", apiKey)
    
let client =
    SplitwiseSharpClient(httpClient)

let expenseByShares =
    { cost                 = Some "10.00"
      group_id             = 0
      description          = Some "Description"
      details              = None
      date                 = Some DateTimeOffset.Now
      repeat_interval      = Some bysharesRepeatinterval.Never
      currency_code        = Some "GBP"
      category_id          = Some 2
      users__0__user_id    = Some friendId
      users__0__paid_share = Some "0.00"
      users__0__owed_share = Some "10.00"
      users__1__user_id    = Some userId
      users__1__paid_share = Some "10.00"
      users__1__owed_share = Some "0.00" } |> PostCreateExpensePayload.ByShares

match client.PostCreateExpense(expenseByShares) with
| PostCreateExpense.OK           ok  -> ok |> printfn "%A"
| PostCreateExpense.Unauthorized err -> printfn $"Unauthorized: {err}"
| PostCreateExpense.Forbidden    err -> printfn $"Forbidden: {err}"