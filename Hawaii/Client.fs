namespace rec SplitwiseSharp

open System.Net
open System.Net.Http
open SplitwiseSharp.Types
open SplitwiseSharp.Http

type SplitwiseSharpClient(httpClient: HttpClient) =
    ///<summary>
    ///Get information about the current user
    ///</summary>
    member this.GetGetCurrentUser() =
        let requestParts = []

        let status, content =
            OpenApiHttp.get httpClient "/get_current_user" requestParts

        if status = HttpStatusCode.OK then
            GetGetCurrentUser.OK(Serializer.deserialize content)
        else
            GetGetCurrentUser.Unauthorized(Serializer.deserialize content)

    ///<summary>
    ///Get information about another user
    ///</summary>
    member this.GetGetUserById() =
        let requestParts = []

        let status, content =
            OpenApiHttp.get httpClient "/get_user/{id}" requestParts

        if status = HttpStatusCode.OK then
            GetGetUserById.OK(Serializer.deserialize content)
        else if status = HttpStatusCode.Unauthorized then
            GetGetUserById.Unauthorized(Serializer.deserialize content)
        else if status = HttpStatusCode.Forbidden then
            GetGetUserById.Forbidden(Serializer.deserialize content)
        else
            GetGetUserById.NotFound(Serializer.deserialize content)

    ///<summary>
    ///Update a user
    ///</summary>
    member this.PostUpdateUserById(body: string) =
        let requestParts = [ RequestPart.jsonContent body ]

        let status, content =
            OpenApiHttp.post httpClient "/update_user/{id}" requestParts

        if status = HttpStatusCode.OK then
            PostUpdateUserById.OK(Serializer.deserialize content)
        else if status = HttpStatusCode.Unauthorized then
            PostUpdateUserById.Unauthorized(Serializer.deserialize content)
        else
            PostUpdateUserById.Forbidden(Serializer.deserialize content)

    ///<summary>
    ///**Note**: Expenses that are not associated with a group are listed in a group with ID 0.
    ///</summary>
    member this.GetGetGroups() =
        let requestParts = []

        let status, content =
            OpenApiHttp.get httpClient "/get_groups" requestParts

        if status = HttpStatusCode.OK then
            GetGetGroups.OK(Serializer.deserialize content)
        else
            GetGetGroups.Unauthorized(Serializer.deserialize content)

    ///<summary>
    ///Get information about a group
    ///</summary>
    member this.GetGetGroupById() =
        let requestParts = []

        let status, content =
            OpenApiHttp.get httpClient "/get_group/{id}" requestParts

        if status = HttpStatusCode.OK then
            GetGetGroupById.OK(Serializer.deserialize content)
        else if status = HttpStatusCode.Unauthorized then
            GetGetGroupById.Unauthorized(Serializer.deserialize content)
        else if status = HttpStatusCode.Forbidden then
            GetGetGroupById.Forbidden(Serializer.deserialize content)
        else
            GetGetGroupById.NotFound(Serializer.deserialize content)

    ///<summary>
    ///Creates a new group. Adds the current user to the group by default.
    ///**Note**: group user parameters must be flattened into the format `users__{index}__{property}`, where
    ///`property` is `user_id`, `first_name`, `last_name`, or `email`.
    ///The user's email or ID must be provided.
    ///</summary>
    member this.PostCreateGroup(body: string) =
        let requestParts = [ RequestPart.jsonContent body ]

        let status, content =
            OpenApiHttp.post httpClient "/create_group" requestParts

        if status = HttpStatusCode.OK then
            PostCreateGroup.OK(Serializer.deserialize content)
        else
            PostCreateGroup.BadRequest(Serializer.deserialize content)

    ///<summary>
    ///Delete an existing group. Destroys all associated records (expenses, etc.)
    ///</summary>
    member this.PostDeleteGroupById(id: int) =
        let requestParts = [ RequestPart.path ("id", id) ]

        let status, content =
            OpenApiHttp.post httpClient "/delete_group/{id}" requestParts

        if status = HttpStatusCode.OK then
            PostDeleteGroupById.OK(Serializer.deserialize content)
        else if status = HttpStatusCode.Unauthorized then
            PostDeleteGroupById.Unauthorized(Serializer.deserialize content)
        else if status = HttpStatusCode.Forbidden then
            PostDeleteGroupById.Forbidden(Serializer.deserialize content)
        else
            PostDeleteGroupById.NotFound(Serializer.deserialize content)

    ///<summary>
    ///Restores a deleted group.
    ///**Note**: 200 OK does not indicate a successful response. You must check the `success` value of the response.
    ///</summary>
    member this.PostUndeleteGroupById() =
        let requestParts = []

        let status, content =
            OpenApiHttp.post httpClient "/undelete_group/{id}" requestParts

        if status = HttpStatusCode.OK then
            PostUndeleteGroupById.OK(Serializer.deserialize content)
        else if status = HttpStatusCode.Unauthorized then
            PostUndeleteGroupById.Unauthorized(Serializer.deserialize content)
        else
            PostUndeleteGroupById.Forbidden(Serializer.deserialize content)

    ///<summary>
    ///**Note**: 200 OK does not indicate a successful response. You must check the `success` value of the response.
    ///</summary>
    member this.PostAddUserToGroup() =
        let requestParts = []

        let _, content =
            OpenApiHttp.post httpClient "/add_user_to_group" requestParts

        PostAddUserToGroup.OK(Serializer.deserialize content)

    ///<summary>
    ///Remove a user from a group. Does not succeed if the user has a non-zero balance.
    ///**Note:** 200 OK does not indicate a successful response. You must check the success value of the response.
    ///</summary>
    member this.PostRemoveUserFromGroup(body: PostRemoveUserFromGroupPayload) =
        let requestParts = [ RequestPart.jsonContent body ]

        let _, content =
            OpenApiHttp.post httpClient "/remove_user_from_group" requestParts

        PostRemoveUserFromGroup.OK(Serializer.deserialize content)

    ///<summary>
    ///**Note**: `group` objects only include group balances with that friend.
    ///</summary>
    member this.GetGetFriends() =
        let requestParts = []

        let status, content =
            OpenApiHttp.get httpClient "/get_friends" requestParts

        if status = HttpStatusCode.OK then
            GetGetFriends.OK(Serializer.deserialize content)
        else
            GetGetFriends.Unauthorized(Serializer.deserialize content)

    ///<summary>
    ///Get details about a friend
    ///</summary>
    member this.GetGetFriendById() =
        let requestParts = []

        let status, content =
            OpenApiHttp.get httpClient "/get_friend/{id}" requestParts

        if status = HttpStatusCode.OK then
            GetGetFriendById.OK(Serializer.deserialize content)
        else if status = HttpStatusCode.Unauthorized then
            GetGetFriendById.Unauthorized(Serializer.deserialize content)
        else if status = HttpStatusCode.Forbidden then
            GetGetFriendById.Forbidden(Serializer.deserialize content)
        else
            GetGetFriendById.NotFound(Serializer.deserialize content)

    ///<summary>
    ///Adds a friend. If the other user does not exist, you must supply `user_first_name`.
    ///If the other user exists, `user_first_name` and `user_last_name` will be ignored.
    ///</summary>
    member this.PostCreateFriend(body: PostCreateFriendPayload) =
        let requestParts = [ RequestPart.jsonContent body ]

        let status, content =
            OpenApiHttp.post httpClient "/create_friend" requestParts

        if status = HttpStatusCode.OK then
            PostCreateFriend.OK(Serializer.deserialize content)
        else
            PostCreateFriend.Unauthorized(Serializer.deserialize content)

    ///<summary>
    ///Add multiple friends at once.
    ///For each user, if the other user does not exist, you must supply `friends__{index}__first_name`.
    ///**Note**: user parameters must be flattened into the format `friends__{index}__{property}`, where
    ///`property` is `first_name`, `last_name`, or `email`.
    ///</summary>
    member this.PostCreateFriends() =
        let requestParts = []

        let status, content =
            OpenApiHttp.post httpClient "/create_friends" requestParts

        if status = HttpStatusCode.OK then
            PostCreateFriends.OK(Serializer.deserialize content)
        else if status = HttpStatusCode.BadRequest then
            PostCreateFriends.BadRequest(Serializer.deserialize content)
        else
            PostCreateFriends.Unauthorized(Serializer.deserialize content)

    ///<summary>
    ///Given a friend ID, break off the friendship between the current user and the specified user.
    ///**Note**: 200 OK does not indicate a successful response. You must check the `success` value of the response.
    ///</summary>
    member this.PostDeleteFriendById() =
        let requestParts = []

        let status, content =
            OpenApiHttp.post httpClient "/delete_friend/{id}" requestParts

        if status = HttpStatusCode.OK then
            PostDeleteFriendById.OK(Serializer.deserialize content)
        else if status = HttpStatusCode.Unauthorized then
            PostDeleteFriendById.Unauthorized(Serializer.deserialize content)
        else if status = HttpStatusCode.Forbidden then
            PostDeleteFriendById.Forbidden(Serializer.deserialize content)
        else
            PostDeleteFriendById.NotFound(Serializer.deserialize content)

    ///<summary>
    ///Returns a list of all currencies allowed by the system. These are mostly ISO 4217 codes, but we do
    ///sometimes use pending codes or unofficial, colloquial codes (like BTC instead of XBT for Bitcoin).
    ///</summary>
    member this.GetGetCurrencies() =
        let requestParts = []

        let _, content =
            OpenApiHttp.get httpClient "/get_currencies" requestParts

        GetGetCurrencies.OK(Serializer.deserialize content)

    ///<summary>
    ///Get expense information
    ///</summary>
    member this.GetGetExpenseById() =
        let requestParts = []

        let status, content =
            OpenApiHttp.get httpClient "/get_expense/{id}" requestParts

        if status = HttpStatusCode.OK then
            GetGetExpenseById.OK(Serializer.deserialize content)
        else if status = HttpStatusCode.Unauthorized then
            GetGetExpenseById.Unauthorized(Serializer.deserialize content)
        else if status = HttpStatusCode.Forbidden then
            GetGetExpenseById.Forbidden(Serializer.deserialize content)
        else
            GetGetExpenseById.NotFound(Serializer.deserialize content)

    ///<summary>
    ///List the current user's expenses
    ///</summary>
    ///<param name="groupId">If provided, only expenses in that group will be returned, and `friend_id` will be ignored.</param>
    ///<param name="friendId">ID of another user. If provided, only expenses between the current and provided user will be returned.</param>
    ///<param name="datedAfter"></param>
    ///<param name="datedBefore"></param>
    ///<param name="updatedAfter"></param>
    ///<param name="updatedBefore"></param>
    ///<param name="limit"></param>
    ///<param name="offset"></param>
    member this.GetGetExpenses
        (
            ?groupId: int,
            ?friendId: int,
            ?datedAfter: System.DateTimeOffset,
            ?datedBefore: System.DateTimeOffset,
            ?updatedAfter: string,
            ?updatedBefore: System.DateTimeOffset,
            ?limit: int,
            ?offset: int
        ) =
        let requestParts =
            [ if groupId.IsSome then
                  RequestPart.query ("group_id", groupId.Value)
              if friendId.IsSome then
                  RequestPart.query ("friend_id", friendId.Value)
              if datedAfter.IsSome then
                  RequestPart.query ("dated_after", datedAfter.Value)
              if datedBefore.IsSome then
                  RequestPart.query ("dated_before", datedBefore.Value)
              if updatedAfter.IsSome then
                  RequestPart.query ("updated_after", updatedAfter.Value)
              if updatedBefore.IsSome then
                  RequestPart.query ("updated_before", updatedBefore.Value)
              if limit.IsSome then
                  RequestPart.query ("limit", limit.Value)
              if offset.IsSome then
                  RequestPart.query ("offset", offset.Value) ]

        let status, content =
            OpenApiHttp.get httpClient "/get_expenses" requestParts

        if status = HttpStatusCode.OK then
            GetGetExpenses.OK(Serializer.deserialize content)
        else if status = HttpStatusCode.Unauthorized then
            GetGetExpenses.Unauthorized(Serializer.deserialize content)
        else if status = HttpStatusCode.Forbidden then
            GetGetExpenses.Forbidden(Serializer.deserialize content)
        else
            GetGetExpenses.NotFound(Serializer.deserialize content)

    ///<summary>
    ///Creates an expense. You may either split an expense equally (only with `group_id` provided),
    ///or supply a list of shares.
    ///When splitting equally, the authenticated user is assumed to be the payer.
    ///When providing a list of shares, each share must include `paid_share` and `owed_share`, and must be identified by one of the following:
    ///- `email`, `first_name`, and `last_name`
    ///- `user_id`
    ///**Note**: 200 OK does not indicate a successful response. The operation was successful only if `errors` is empty.
    ///</summary>
    member this.PostCreateExpense() =
        let requestParts = []

        let status, content =
            OpenApiHttp.post httpClient "/create_expense" requestParts

        if status = HttpStatusCode.OK then
            PostCreateExpense.OK(Serializer.deserialize content)
        else if status = HttpStatusCode.Unauthorized then
            PostCreateExpense.Unauthorized(Serializer.deserialize content)
        else
            PostCreateExpense.Forbidden(Serializer.deserialize content)

    ///<summary>
    ///Updates an expense. Parameters are the same as in `create_expense`, but you only need to include parameters
    ///that are changing from the previous values. If any values is supplied for `users__{index}__{property}`, _all_
    ///shares for the expense will be overwritten with the provided values.
    ///**Note**: 200 OK does not indicate a successful response. The operation was successful only if `errors` is empty.
    ///</summary>
    member this.PostUpdateExpenseById() =
        let requestParts = []

        let status, content =
            OpenApiHttp.post httpClient "/update_expense/{id}" requestParts

        if status = HttpStatusCode.OK then
            PostUpdateExpenseById.OK(Serializer.deserialize content)
        else if status = HttpStatusCode.Unauthorized then
            PostUpdateExpenseById.Unauthorized(Serializer.deserialize content)
        else
            PostUpdateExpenseById.Forbidden(Serializer.deserialize content)

    ///<summary>
    ///**Note**: 200 OK does not indicate a successful response. The operation was successful only if `success` is true.
    ///</summary>
    member this.PostDeleteExpenseById() =
        let requestParts = []

        let status, content =
            OpenApiHttp.post httpClient "/delete_expense/{id}" requestParts

        if status = HttpStatusCode.OK then
            PostDeleteExpenseById.OK(Serializer.deserialize content)
        else if status = HttpStatusCode.Unauthorized then
            PostDeleteExpenseById.Unauthorized(Serializer.deserialize content)
        else
            PostDeleteExpenseById.Forbidden(Serializer.deserialize content)

    ///<summary>
    ///**Note**: 200 OK does not indicate a successful response. The operation was successful only if `success` is true.
    ///</summary>
    member this.PostUndeleteExpenseById() =
        let requestParts = []

        let status, content =
            OpenApiHttp.post httpClient "/undelete_expense/{id}" requestParts

        if status = HttpStatusCode.OK then
            PostUndeleteExpenseById.OK(Serializer.deserialize content)
        else if status = HttpStatusCode.Unauthorized then
            PostUndeleteExpenseById.Unauthorized(Serializer.deserialize content)
        else
            PostUndeleteExpenseById.Forbidden(Serializer.deserialize content)

    ///<summary>
    ///Get expense comments
    ///</summary>
    member this.GetGetComments(expenseId: int) =
        let requestParts =
            [ RequestPart.query ("expense_id", expenseId) ]

        let status, content =
            OpenApiHttp.get httpClient "/get_comments" requestParts

        if status = HttpStatusCode.OK then
            GetGetComments.OK(Serializer.deserialize content)
        else if status = HttpStatusCode.Unauthorized then
            GetGetComments.Unauthorized(Serializer.deserialize content)
        else if status = HttpStatusCode.Forbidden then
            GetGetComments.Forbidden(Serializer.deserialize content)
        else
            GetGetComments.NotFound(Serializer.deserialize content)

    ///<summary>
    ///Create a comment
    ///</summary>
    member this.PostCreateComment(body: PostCreateCommentPayload) =
        let requestParts = [ RequestPart.jsonContent body ]

        let status, content =
            OpenApiHttp.post httpClient "/create_comment" requestParts

        if status = HttpStatusCode.OK then
            PostCreateComment.OK(Serializer.deserialize content)
        else if status = HttpStatusCode.Unauthorized then
            PostCreateComment.Unauthorized(Serializer.deserialize content)
        else if status = HttpStatusCode.Forbidden then
            PostCreateComment.Forbidden(Serializer.deserialize content)
        else
            PostCreateComment.NotFound(Serializer.deserialize content)

    ///<summary>
    ///Deletes a comment. Returns the deleted comment.
    ///</summary>
    member this.PostDeleteComment() =
        let requestParts = []

        let status, content =
            OpenApiHttp.post httpClient "/delete_comment" requestParts

        if status = HttpStatusCode.OK then
            PostDeleteComment.OK(Serializer.deserialize content)
        else if status = HttpStatusCode.Unauthorized then
            PostDeleteComment.Unauthorized(Serializer.deserialize content)
        else if status = HttpStatusCode.Forbidden then
            PostDeleteComment.Forbidden(Serializer.deserialize content)
        else
            PostDeleteComment.NotFound(Serializer.deserialize content)

    ///<summary>
    ///Return a list of recent activity on the users account with the most recent items first.
    ///`content` will be suitable for display in HTML and uses only the `&amp;lt;strong&amp;gt;`, `&amp;lt;strike&amp;gt;`, `&amp;lt;small&amp;gt;`,
    ///`&amp;lt;br&amp;gt;` and `&amp;lt;font color="#FFEE44"&amp;gt;` tags.
    ///The `type` value indicates what the notification is about. Notification types may be added in the future
    ///without warning. Below is an incomplete list of notification types.
    ///| Type | Meaning |
    ///| ---- | ------- |
    ///| 0    | Expense added |
    ///| 1    | Expense updated |
    ///| 2	   | Expense deleted |
    ///| 3	   | Comment added |
    ///| 4	   | Added to group |
    ///| 5	   | Removed from group |
    ///| 6	   | Group deleted |
    ///| 7	   | Group settings changed |
    ///| 8	   | Added as friend |
    ///| 9	   | Removed as friend |
    ///| 10	 | News (a URL should be included) |
    ///| 11	 | Debt simplification |
    ///| 12	 | Group undeleted |
    ///| 13	 | Expense undeleted |
    ///| 14	 | Group currency conversion |
    ///| 15	 | Friend currency conversion |
    ///**Note**: While all parameters are optional, the server sets arbitrary (but large) limits
    ///on the number of notifications returned if you set a very old `updated_after` value or `limit` of `0` for a
    ///user with many notifications.
    ///</summary>
    ///<param name="updatedAfter">If provided, returns only notifications after this time.</param>
    ///<param name="limit">Omit (or provide `0`) to get the maximum number of notifications.</param>
    member this.GetGetNotifications(?updatedAfter: System.DateTimeOffset, ?limit: int) =
        let requestParts =
            [ if updatedAfter.IsSome then
                  RequestPart.query ("updated_after", updatedAfter.Value)
              if limit.IsSome then
                  RequestPart.query ("limit", limit.Value) ]

        let status, content =
            OpenApiHttp.get httpClient "/get_notifications" requestParts

        if status = HttpStatusCode.OK then
            GetGetNotifications.OK(Serializer.deserialize content)
        else
            GetGetNotifications.Unauthorized(Serializer.deserialize content)

    ///<summary>
    ///Returns a list of all categories Splitwise allows for expenses. There are parent categories that represent groups of categories with subcategories for more specific categorization.
    ///When creating expenses, you must use a subcategory, not a parent category.
    ///If you intend for an expense to be represented by the parent category and nothing more specific, please use the "Other" subcategory.
    ///</summary>
    member this.GetGetCategories() =
        let requestParts = []

        let _, content =
            OpenApiHttp.get httpClient "/get_categories" requestParts

        GetGetCategories.OK(Serializer.deserialize content)

    ///<summary>
    ///Attempts to create an expense from the input as an English natural language phrase like "groceries $20" or "Jon paid me $50".
    ///If `valid` is `true`, the `expense` value will be a complete and valid expense.
    ///If it is `false`, the `expense` value may be missing some values.
    ///**Note**: By default, the expense is only parsed, not persisted. See the `autosave` parameter.
    ///</summary>
    member this.PostParseSentence() =
        let requestParts = []

        let _, content =
            OpenApiHttp.post httpClient "/parse_sentence" requestParts

        PostParseSentence.OK(Serializer.deserialize content)
