namespace rec SplitwiseSharp.Types

open System
open Fable.Core

type Debt =
    { ///User ID
      from: Option<int>
      ///User ID
      ``to``: Option<int>
      amount: Option<string>
      currency_code: Option<string> }

[<StringEnum; RequireQualifiedAccess>]
type RegistrationStatus =
    | [<CompiledName "confirmed">] Confirmed
    | [<CompiledName "dummy">] Dummy
    | [<CompiledName "invited">] Invited
    member this.Format() =
        match this with
        | Confirmed -> "confirmed"
        | Dummy -> "dummy"
        | Invited -> "invited"

type Picture =
    { small: Option<string>
      medium: Option<string>
      large: Option<string> }

type User =
    { id: Option<int>
      first_name: Option<string>
      last_name: Option<string>
      email: Option<string>
      registration_status: Option<RegistrationStatus>
      picture: Option<Picture> }

type CurrentUser =
    { id: Option<int>
      first_name: Option<string>
      last_name: Option<string>
      email: Option<string>
      registration_status: Option<RegistrationStatus>
      picture: Option<Picture>
      ///ISO 8601 date/time indicating the last time notifications were read
      notifications_read: Option<string>
      ///Number of unread notifications since notifiations_read
      notifications_count: Option<int>
      ///User's notification preferences
      notifications: Option<Map<string, bool>>
      default_currency: Option<string>
      ///ISO_639-1 2-letter locale code
      locale: Option<string> }

[<StringEnum; RequireQualifiedAccess>]
type GroupType =
    | [<CompiledName "apartment">] Apartment
    | [<CompiledName "house">] House
    | [<CompiledName "trip">] Trip
    | [<CompiledName "other">] Other
    member this.Format() =
        match this with
        | Apartment -> "apartment"
        | House -> "house"
        | Trip -> "trip"
        | Other -> "other"

type Avatar =
    { original: Option<string>
      xxlarge: Option<string>
      xlarge: Option<string>
      large: Option<string>
      medium: Option<string>
      small: Option<string> }

type CoverPhoto =
    { xxlarge: Option<string>
      xlarge: Option<string> }

type Group =
    { id: Option<int>
      name: Option<string>
      group_type: Option<GroupType>
      updated_at: Option<DateTimeOffset>
      simplify_by_default: Option<bool>
      members: Option<list<string>>
      original_debts: Option<list<Debt>>
      simplified_debts: Option<list<Debt>>
      avatar: Option<Avatar>
      custom_avatar: Option<bool>
      cover_photo: Option<CoverPhoto>
      ///A link the user can send to a friend to join the group directly
      invite_link: Option<string> }

type Unauthorized =
    { error: Option<string> }

type Errors =
    { errors: {| ``base``: Option<list<string>> |} }

type Forbidden =
    Errors

type NotFound =
    Errors

type Balance =
    { currency_code: Option<string>
      amount: Option<string> }

type Groups =
    { group_id: Option<int>
      balance: Option<list<Balance>> }

type Friend =
    { id: Option<int>
      first_name: Option<string>
      last_name: Option<string>
      email: Option<string>
      registration_status: Option<RegistrationStatus>
      picture: Option<Picture>
      groups: Option<list<Groups>>
      balance: Option<list<Balance>>
      updated_at: Option<DateTimeOffset> }

[<StringEnum; RequireQualifiedAccess>]
type RepeatInterval =
    | [<CompiledName "never">] Never
    | [<CompiledName "weekly">] Weekly
    | [<CompiledName "fortnightly">] Fortnightly
    | [<CompiledName "monthly">] Monthly
    | [<CompiledName "yearly">] Yearly
    member this.Format() =
        match this with
        | Never -> "never"
        | Weekly -> "weekly"
        | Fortnightly -> "fortnightly"
        | Monthly -> "monthly"
        | Yearly -> "yearly"

type CommentUser =
    { id: Option<int>
      first_name: Option<string>
      last_name: Option<string>
      picture: Option<{| medium: Option<string> |}> }

type Share =
    { user: Option<CommentUser>
      user_id: Option<int>
      paid_share: Option<string>
      owed_share: Option<string>
      net_balance: Option<string> }

[<StringEnum; RequireQualifiedAccess>]
type CommentType =
    | [<CompiledName "System">] System
    | [<CompiledName "User">] User
    member this.Format() =
        match this with
        | System -> "System"
        | User -> "User"

[<StringEnum; RequireQualifiedAccess>]
type RelationType =
    | [<CompiledName "ExpenseComment">] ExpenseComment
    member this.Format() =
        match this with
        | ExpenseComment -> "ExpenseComment"

type Comment =
    { id: Option<int>
      content: Option<string>
      comment_type: Option<CommentType>
      relation_type: Option<RelationType>
      ///ID of the subject of the comment
      relation_id: Option<int>
      created_at: Option<DateTimeOffset>
      deleted_at: Option<DateTimeOffset> }

type EmailReminderInAdvance =
    | ``Emailreminderinadvance-1`` = -1
    | Emailreminderinadvance0 = 0
    | Emailreminderinadvance1 = 1
    | Emailreminderinadvance2 = 2
    | Emailreminderinadvance3 = 3
    | Emailreminderinadvance4 = 4
    | Emailreminderinadvance5 = 5
    | Emailreminderinadvance6 = 6
    | Emailreminderinadvance7 = 7
    | Emailreminderinadvance14 = 14

type Repayments =
    { ///ID of the owing user
      from: Option<int>
      ///ID of the owed user
      ``to``: Option<int>
      amount: Option<string> }

type Receipt =
    { large: Option<string>
      original: Option<string> }

type Expense =
    { ///A string representation of a decimal value, limited to 2 decimal places
      cost: Option<string>
      ///The group to put this expense in, or `0` to create an expense outside of a group.
      group_id: Option<int>
      ///A short description of the expense
      description: Option<string>
      ///Also known as "notes."
      details: Option<string>
      ///The date and time the expense took place. May differ from `created_at`
      date: Option<DateTimeOffset>
      repeat_interval: Option<RepeatInterval>
      ///A currency code. Must be in the list from `get_currencies`
      currency_code: Option<string>
      ///A category id from `get_categories`
      category_id: Option<int>
      id: Option<int>
      ///Null if the expense is not associated with a friendship.
      friendship_id: Option<int>
      expense_bundle_id: Option<int>
      ///Whether the expense recurs automatically
      repeats: Option<bool>
      ///Whether a reminder will be sent to involved users in advance of the next occurrence of a recurring expense.
      ///Only applicable if the expense recurs.
      email_reminder: Option<bool>
      ///Number of days in advance to remind involved users about the next occurrence of a new expense.
      ///Only applicable if the expense recurs.
      email_reminder_in_advance: Option<EmailReminderInAdvance>
      ///The date of the next occurrence of a recurring expense. Only applicable if the expense recurs.
      next_repeat: Option<string>
      comments_count: Option<int>
      ///Whether this was a payment between users
      payment: Option<bool>
      ///If a payment was made via an integrated third party service, whether it was confirmed by that service.
      transaction_confirmed: Option<bool>
      repayments: Option<list<Repayments>>
      ///The date and time the expense was created on Splitwise
      created_at: Option<DateTimeOffset>
      created_by: Option<User>
      ///The last time the expense was updated.
      updated_at: Option<DateTimeOffset>
      updated_by: Option<User>
      ///If the expense was deleted, when it was deleted.
      deleted_at: Option<DateTimeOffset>
      deleted_by: Option<User>
      category: Option<{| id: Option<int>
                          ///Translated to the current user's locale
                          name: Option<string> |}>
      receipt: Option<Receipt>
      users: Option<list<Share>>
      comments: Option<list<Comment>> }

type EqualGroupSplitExpense =
    { ///A string representation of a decimal value, limited to 2 decimal places
      cost: Option<string>
      ///The group to put this expense in, or `0` to create an expense outside of a group.
      group_id: Option<int>
      ///A short description of the expense
      description: Option<string>
      ///Also known as "notes."
      details: Option<string>
      ///The date and time the expense took place. May differ from `created_at`
      date: Option<DateTimeOffset>
      repeat_interval: Option<RepeatInterval>
      ///A currency code. Must be in the list from `get_currencies`
      currency_code: Option<string>
      ///A category id from `get_categories`
      category_id: Option<int>
      split_equally: Option<bool> }

type BySharesExpense =
    { ///A string representation of a decimal value, limited to 2 decimal places
      cost: Option<string>
      ///The group to put this expense in, or `0` to create an expense outside of a group.
      group_id: int
      ///A short description of the expense
      description: Option<string>
      ///Also known as "notes."
      details: Option<string>
      ///The date and time the expense took place. May differ from `created_at`
      date: Option<DateTimeOffset>
      repeat_interval: Option<RepeatInterval>
      ///A currency code. Must be in the list from `get_currencies`
      currency_code: Option<string>
      ///A category id from `get_categories`
      category_id: Option<int>
      users__0__user_id: Option<int>
      ///Decimal amount as a string with 2 decimal places. The amount this user paid for the expense
      users__0__paid_share: Option<string>
      ///Decimal amount as a string with 2 decimal places. The amount this user owes for the expense
      users__0__owed_share: Option<string>
      users__1__user_id: Option<int>
      ///Decimal amount as a string with 2 decimal places. The amount this user paid for the expense
      users__1__paid_share: Option<string>
      ///Decimal amount as a string with 2 decimal places. The amount this user owes for the expense
      users__1__owed_share: Option<string> }

type PostCreateExpensePayload =
    | EqualGroupSplit of EqualGroupSplitExpense
    | ByShares of BySharesExpense

type Source =
    { ``type``: Option<string>
      id: Option<int>
      url: Option<string> }

[<StringEnum; RequireQualifiedAccess>]
type ImageShape =
    | [<CompiledName "square">] Square
    | [<CompiledName "circle">] Circle
    member this.Format() =
        match this with
        | Square -> "square"
        | Circle -> "circle"

type Notification =
    { id: Option<int>
      ``type``: Option<int>
      created_at: Option<DateTimeOffset>
      created_by: Option<int>
      source: Option<Source>
      image_url: Option<string>
      image_shape: Option<ImageShape>
      content: Option<string> }

type Slim =
    { small: Option<string>
      large: Option<string> }

type Square =
    { large: Option<string>
      xlarge: Option<string> }

type IconTypes =
    { slim: Option<Slim>
      square: Option<Square> }

type Category =
    { id: Option<int>
      name: Option<string>
      icon: Option<string>
      icon_types: Option<IconTypes> }

type ParentVategoryIconTypesSlim =
    { small: Option<string>
      large: Option<string> }

type ParentCategoryIconTypesSquare =
    { large: Option<string>
      xlarge: Option<string> }

type ParentCategoryIconTypes =
    { slim: Option<ParentVategoryIconTypesSlim>
      square: Option<ParentCategoryIconTypesSquare> }

type ParentCategory =
    { id: Option<int>
      name: Option<string>
      icon: Option<string>
      icon_types: Option<ParentCategoryIconTypes>
      subcategories: Option<list<Category>> }

[<RequireQualifiedAccess>]
type GetGetCurrentUser =
    ///OK
    | OK of payload: {| user: CurrentUser |}
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: Unauthorized

type UserPayload =
    { user : User }

[<RequireQualifiedAccess>]
type GetGetUserById =
    ///OK
    | OK of payload: UserPayload
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: Unauthorized
    ///Forbidden
    | Forbidden of payload: Forbidden
    ///Not Found
    | NotFound of payload: NotFound

[<RequireQualifiedAccess>]
type PostUpdateUserById =
    ///OK
    | OK of payload: UserPayload
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: Unauthorized
    ///Forbidden
    | Forbidden of payload: Forbidden

[<RequireQualifiedAccess>]
type GetGetGroups =
    ///OK
    | OK of payload: {| groups: Option<list<Group>> |}
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: Unauthorized

type GroupPayload =
    { group: Option<Group> }

[<RequireQualifiedAccess>]
type GetGetGroupById =
    ///OK
    | OK of payload: GroupPayload
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: Unauthorized
    ///Forbidden
    | Forbidden of payload: Forbidden
    ///Not Found
    | NotFound of payload: NotFound

[<RequireQualifiedAccess>]
type PostCreateGroup =
    ///OK
    | OK of payload: GroupPayload
    ///Bad Request
    | BadRequest of payload: {| errors: Option<{| ``base``: Option<list<string>> |}> |}

type SuccessPayload =
    { success: Option<bool> }

[<RequireQualifiedAccess>]
type PostDeleteGroupById =
    ///OK
    | OK of payload: SuccessPayload
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: Unauthorized
    ///Forbidden
    | Forbidden of payload: Forbidden
    ///Not Found
    | NotFound of payload: NotFound

[<RequireQualifiedAccess>]
type PostUndeleteGroupById =
    ///OK
    | OK of payload: {| success: Option<bool>
                        errors: Option<list<string>> |}
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: Unauthorized
    ///Forbidden
    | Forbidden of payload: Forbidden

[<RequireQualifiedAccess>]
type PostAddUserToGroup =
    | OK of payload: {| success: Option<bool>
                        user: Option<UserPayload>
                        errors: Option<Map<string, list<string>>> |}

type PostRemoveUserFromGroupPayload =
    { group_id: int
      user_id: int }

[<RequireQualifiedAccess>]
type PostRemoveUserFromGroup =
    | OK of payload: {| success: Option<bool>
                        errors: Option<Map<string, list<string>>> |}

[<RequireQualifiedAccess>]
type GetGetFriends =
    ///OK
    | OK of payload: {| friends: Option<list<string>> |}
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: Unauthorized

type FriendPayload =
    { friend: Option<Friend> }

[<RequireQualifiedAccess>]
type GetGetFriendById =
    ///OK
    | OK of payload: FriendPayload
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: Unauthorized
    ///Forbidden
    | Forbidden of payload: Forbidden
    ///Not Found
    | NotFound of payload: NotFound

type PostCreateFriendPayload =
    { email: string
      user_first_name: Option<string>
      user_last_name: Option<string> }

[<RequireQualifiedAccess>]
type PostCreateFriend =
    ///OK
    | OK of payload: FriendPayload
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: Unauthorized

[<RequireQualifiedAccess>]
type PostCreateFriends =
    ///OK
    | OK of payload: {| users: Option<list<string>>
                        errors: Option<list<string>> |}
    ///Bad Request
    | BadRequest of payload: {| users: Option<list<string>>
                                errors: Option<Map<string, list<string>>> |}
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: Unauthorized

[<RequireQualifiedAccess>]
type PostDeleteFriendById =
    ///OK
    | OK of payload: {| success: Option<bool>
                        errors: Option<Map<string, list<string>>> |}
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: Unauthorized
    ///Forbidden
    | Forbidden of payload: Forbidden
    ///Not Found
    | NotFound of payload: NotFound

type Currencies =
    { currency_code: Option<string>
      unit: Option<string> }

[<RequireQualifiedAccess>]
type GetGetCurrencies =
    ///OK
    | OK of payload: {| currencies: Option<list<Currencies>> |}

[<RequireQualifiedAccess>]
type GetGetExpenseById =
    ///OK
    | OK of payload: {| expense: Option<Expense> |}
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: Unauthorized
    ///Forbidden
    | Forbidden of payload: Forbidden
    ///Not Found
    | NotFound of payload: NotFound

type ExpensesPayload =
    { expenses: Option<list<Expense>> }

[<RequireQualifiedAccess>]
type GetGetExpenses =
    ///OK
    | OK of payload: ExpensesPayload
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: Unauthorized
    ///Forbidden
    | Forbidden of payload: Forbidden
    ///Not Found
    | NotFound of payload: NotFound

[<RequireQualifiedAccess>]
type PostCreateExpense =
    ///OK
    | OK of payload: {| expenses: list<Expense>
                        errors: {| ``base``: Option<list<string>> |} |}
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: Unauthorized
    ///Forbidden
    | Forbidden of payload: Forbidden

[<RequireQualifiedAccess>]
type PostUpdateExpenseById =
    ///OK
    | OK of payload: ExpensesPayload
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: Unauthorized
    ///Forbidden
    | Forbidden of payload: Forbidden

[<RequireQualifiedAccess>]
type PostDeleteExpenseById =
    | OK of payload: SuccessPayload
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: Unauthorized
    ///Forbidden
    | Forbidden of payload: Forbidden

[<RequireQualifiedAccess>]
type PostUndeleteExpenseById =
    | OK of payload: SuccessPayload
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: Unauthorized
    ///Forbidden
    | Forbidden of payload: Forbidden

[<RequireQualifiedAccess>]
type GetGetComments =
    ///OK
    | OK of payload: {| comments: Option<list<Comment>> |}
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: Unauthorized
    ///Forbidden
    | Forbidden of payload: Forbidden
    ///Not Found
    | NotFound of payload: NotFound

type PostCreateCommentPayload =
    { expense_id: Option<int>
      content: Option<string> }

type CommentPayload =
    { comment: Option<string> }

[<RequireQualifiedAccess>]
type PostCreateComment =
    ///OK
    | OK of payload: CommentPayload
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: Unauthorized
    ///Forbidden
    | Forbidden of payload: Forbidden
    ///Not Found
    | NotFound of payload: NotFound

[<RequireQualifiedAccess>]
type PostDeleteComment =
    ///OK
    | OK of payload: CommentPayload
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: Unauthorized
    ///Forbidden
    | Forbidden of payload: Forbidden
    ///Not Found
    | NotFound of payload: NotFound

[<RequireQualifiedAccess>]
type GetGetNotifications =
    ///OK
    | OK of payload: {| notifications: Option<list<Notification>> |}
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: Unauthorized

[<RequireQualifiedAccess>]
type GetGetCategories =
    ///OK
    | OK of payload: {| categories: Option<list<ParentCategory>> |}

[<RequireQualifiedAccess>]
type PostParseSentence =
    ///OK
    | OK of payload: {| expense: Option<Expense>
                        valid: Option<bool>
                        confidence: Option<float>
                        error: Option<string> |}
