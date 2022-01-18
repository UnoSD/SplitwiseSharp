namespace rec SplitwiseSharp.Types

type Debt =
    { ///User ID
      from: Option<int>
      ///User ID
      ``to``: Option<int>
      amount: Option<string>
      currency_code: Option<string> }

[<Fable.Core.StringEnum; RequireQualifiedAccess>]
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

type CurrentUserPicture =
    { small: Option<string>
      medium: Option<string>
      large: Option<string> }

type CurrentUser =
    { id: Option<int>
      first_name: Option<string>
      last_name: Option<string>
      email: Option<string>
      registration_status: Option<RegistrationStatus>
      picture: Option<CurrentUserPicture>
      ///ISO 8601 date/time indicating the last time notifications were read
      notifications_read: Option<string>
      ///Number of unread notifications since notifiations_read
      notifications_count: Option<int>
      ///User's notification preferences
      notifications: Option<Map<string, bool>>
      default_currency: Option<string>
      ///ISO_639-1 2-letter locale code
      locale: Option<string> }

[<Fable.Core.StringEnum; RequireQualifiedAccess>]
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
      updated_at: Option<System.DateTimeOffset>
      simplify_by_default: Option<bool>
      members: Option<list<string>>
      original_debts: Option<list<Debt>>
      simplified_debts: Option<list<Debt>>
      avatar: Option<Avatar>
      custom_avatar: Option<bool>
      cover_photo: Option<CoverPhoto>
      ///A link the user can send to a friend to join the group directly
      invite_link: Option<string> }

type UnauthorizedError =
    { error: Option<string> }

type Errors =
    { ``base``: Option<list<string>> }

type ForbiddenError =
    { errors: Option<Errors> }

type NotFoundError =
    { errors: Option<Errors> }

type UserById_OK =
    { user : User }

type GetGetCurrentUser_OK =
    { user: CurrentUser }

type unauthorized =
    { error: Option<string> }

type forbiddenErrors =
    { ``base``: Option<list<string>> }

type forbidden =
    { errors: forbiddenErrors }

type notfoundErrors =
    { ``base``: Option<list<string>> }

type notfound =
    { errors: notfoundErrors }

type groupAvatar =
    { original: Option<string>
      xxlarge: Option<string>
      xlarge: Option<string>
      large: Option<string>
      medium: Option<string>
      small: Option<string> }

type groupCoverphoto =
    { xxlarge: Option<string>
      xlarge: Option<string> }

type balance =
    { currency_code: Option<string>
      amount: Option<string> }

type friendPicture =
    { small: Option<string>
      medium: Option<string>
      large: Option<string> }

type Groups =
    { group_id: Option<int>
      balance: Option<list<balance>> }

type friend =
    { id: Option<int>
      first_name: Option<string>
      last_name: Option<string>
      email: Option<string>
      registration_status: Option<RegistrationStatus>
      picture: Option<friendPicture>
      groups: Option<list<Groups>>
      balance: Option<list<balance>>
      updated_at: Option<System.DateTimeOffset> }

[<Fable.Core.StringEnum; RequireQualifiedAccess>]
type Repeatinterval =
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

type common =
    { ///A string representation of a decimal value, limited to 2 decimal places
      cost: Option<string>
      ///The group to put this expense in, or `0` to create an expense outside of a group.
      group_id: Option<int>
      ///A short description of the expense
      description: Option<string>
      ///Also known as "notes."
      details: Option<string>
      ///The date and time the expense took place. May differ from `created_at`
      date: Option<System.DateTimeOffset>
      repeat_interval: Option<Repeatinterval>
      ///A currency code. Must be in the list from `get_currencies`
      currency_code: Option<string>
      ///A category id from `get_categories`
      category_id: Option<int> }

type commentuserPicture =
    { medium: Option<string> }

type commentuser =
    { id: Option<int>
      first_name: Option<string>
      last_name: Option<string>
      picture: Option<commentuserPicture> }

type share =
    { user: Option<commentuser>
      user_id: Option<int>
      paid_share: Option<string>
      owed_share: Option<string>
      net_balance: Option<string> }

[<Fable.Core.StringEnum; RequireQualifiedAccess>]
type Commenttype =
    | [<CompiledName "System">] System
    | [<CompiledName "User">] User
    member this.Format() =
        match this with
        | System -> "System"
        | User -> "User"

[<Fable.Core.StringEnum; RequireQualifiedAccess>]
type Relationtype =
    | [<CompiledName "ExpenseComment">] ExpenseComment
    member this.Format() =
        match this with
        | ExpenseComment -> "ExpenseComment"

type comment =
    { id: Option<int>
      content: Option<string>
      comment_type: Option<Commenttype>
      relation_type: Option<Relationtype>
      ///ID of the subject of the comment
      relation_id: Option<int>
      created_at: Option<System.DateTimeOffset>
      deleted_at: Option<System.DateTimeOffset> }

[<Fable.Core.StringEnum; RequireQualifiedAccess>]
type expenseRepeatinterval =
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

[<Fable.Core.StringEnum; RequireQualifiedAccess>]
type RepeatintervalFromexpense =
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

type Emailreminderinadvance =
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

type Category =
    { id: Option<int>
      ///Translated to the current user's locale
      name: Option<string> }

type Receipt =
    { large: Option<string>
      original: Option<string> }

type expense =
    { ///A string representation of a decimal value, limited to 2 decimal places
      cost: Option<string>
      ///The group to put this expense in, or `0` to create an expense outside of a group.
      group_id: Option<int>
      ///A short description of the expense
      description: Option<string>
      ///Also known as "notes."
      details: Option<string>
      ///The date and time the expense took place. May differ from `created_at`
      date: Option<System.DateTimeOffset>
      repeat_interval: Option<expenseRepeatinterval>
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
      email_reminder_in_advance: Option<Emailreminderinadvance>
      ///The date of the next occurrence of a recurring expense. Only applicable if the expense recurs.
      next_repeat: Option<string>
      comments_count: Option<int>
      ///Whether this was a payment between users
      payment: Option<bool>
      ///If a payment was made via an integrated third party service, whether it was confirmed by that service.
      transaction_confirmed: Option<bool>
      repayments: Option<list<Repayments>>
      ///The date and time the expense was created on Splitwise
      created_at: Option<System.DateTimeOffset>
      created_by: Option<User>
      ///The last time the expense was updated.
      updated_at: Option<System.DateTimeOffset>
      updated_by: Option<User>
      ///If the expense was deleted, when it was deleted.
      deleted_at: Option<System.DateTimeOffset>
      deleted_by: Option<User>
      category: Option<Category>
      receipt: Option<Receipt>
      users: Option<list<share>>
      comments: Option<list<comment>> }

[<Fable.Core.StringEnum; RequireQualifiedAccess>]
type equalgroupsplitRepeatinterval =
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

type equalgroupsplit =
    { ///A string representation of a decimal value, limited to 2 decimal places
      cost: Option<string>
      ///The group to put this expense in, or `0` to create an expense outside of a group.
      group_id: Option<int>
      ///A short description of the expense
      description: Option<string>
      ///Also known as "notes."
      details: Option<string>
      ///The date and time the expense took place. May differ from `created_at`
      date: Option<System.DateTimeOffset>
      repeat_interval: Option<equalgroupsplitRepeatinterval>
      ///A currency code. Must be in the list from `get_currencies`
      currency_code: Option<string>
      ///A category id from `get_categories`
      category_id: Option<int>
      split_equally: Option<bool> }

[<Fable.Core.StringEnum; RequireQualifiedAccess>]
type bysharesRepeatinterval =
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

type byshares =
    { ///A string representation of a decimal value, limited to 2 decimal places
      cost: Option<string>
      ///The group to put this expense in, or `0` to create an expense outside of a group.
      group_id: int
      ///A short description of the expense
      description: Option<string>
      ///Also known as "notes."
      details: Option<string>
      ///The date and time the expense took place. May differ from `created_at`
      date: Option<System.DateTimeOffset>
      repeat_interval: Option<bysharesRepeatinterval>
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
    | EqualGroupSplit of equalgroupsplit
    | ByShares of byshares

type Source =
    { ``type``: Option<string>
      id: Option<int>
      url: Option<string> }

[<Fable.Core.StringEnum; RequireQualifiedAccess>]
type Imageshape =
    | [<CompiledName "square">] Square
    | [<CompiledName "circle">] Circle
    member this.Format() =
        match this with
        | Square -> "square"
        | Circle -> "circle"

type notification =
    { id: Option<int>
      ``type``: Option<int>
      created_at: Option<System.DateTimeOffset>
      created_by: Option<int>
      source: Option<Source>
      image_url: Option<string>
      image_shape: Option<Imageshape>
      content: Option<string> }

type Slim =
    { small: Option<string>
      large: Option<string> }

type Square =
    { large: Option<string>
      xlarge: Option<string> }

type Icontypes =
    { slim: Option<Slim>
      square: Option<Square> }

type category =
    { id: Option<int>
      name: Option<string>
      icon: Option<string>
      icon_types: Option<Icontypes> }

type parentcategoryIcontypesSlim =
    { small: Option<string>
      large: Option<string> }

type parentcategoryIcontypesSquare =
    { large: Option<string>
      xlarge: Option<string> }

type parentcategoryIcontypes =
    { slim: Option<parentcategoryIcontypesSlim>
      square: Option<parentcategoryIcontypesSquare> }

type parentcategory =
    { id: Option<int>
      name: Option<string>
      icon: Option<string>
      icon_types: Option<parentcategoryIcontypes>
      subcategories: Option<list<category>> }

[<RequireQualifiedAccess>]
type GetGetCurrentUser =
    ///OK
    | OK of payload: GetGetCurrentUser_OK
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: unauthorized

[<RequireQualifiedAccess>]
type GetGetUserById =
    ///OK
    | OK of payload: UserById_OK
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: unauthorized
    ///Forbidden
    | Forbidden of payload: forbidden
    ///Not Found
    | NotFound of payload: notfound

[<RequireQualifiedAccess>]
type PostUpdateUserById =
    ///OK
    | OK of payload: UserById_OK
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: unauthorized
    ///Forbidden
    | Forbidden of payload: forbidden

type GetGetGroups_OK = { groups: Option<list<Group>> }

[<RequireQualifiedAccess>]
type GetGetGroups =
    ///OK
    | OK of payload: GetGetGroups_OK
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: unauthorized

type GetGetGroupById_OK = { group: Option<Group> }

[<RequireQualifiedAccess>]
type GetGetGroupById =
    ///OK
    | OK of payload: GetGetGroupById_OK
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: unauthorized
    ///Forbidden
    | Forbidden of payload: forbidden
    ///Not Found
    | NotFound of payload: notfound

type PostCreateGroup_OK = { group: Option<Group> }
type PostCreateGroup_BadRequestErrors = { ``base``: Option<list<string>> }

type PostCreateGroup_BadRequest =
    { errors: Option<PostCreateGroup_BadRequestErrors> }

[<RequireQualifiedAccess>]
type PostCreateGroup =
    ///OK
    | OK of payload: PostCreateGroup_OK
    ///Bad Request
    | BadRequest of payload: PostCreateGroup_BadRequest

type PostDeleteGroupById_OK = { success: Option<bool> }

[<RequireQualifiedAccess>]
type PostDeleteGroupById =
    ///OK
    | OK of payload: PostDeleteGroupById_OK
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: unauthorized
    ///Forbidden
    | Forbidden of payload: forbidden
    ///Not Found
    | NotFound of payload: notfound

type PostUndeleteGroupById_OK =
    { success: Option<bool>
      errors: Option<list<string>> }

[<RequireQualifiedAccess>]
type PostUndeleteGroupById =
    ///OK
    | OK of payload: PostUndeleteGroupById_OK
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: unauthorized
    ///Forbidden
    | Forbidden of payload: forbidden

type PostAddUserToGroup_OK =
    { success: Option<bool>
      user: Option<UserById_OK>
      errors: Option<Map<string, list<string>>> }

[<RequireQualifiedAccess>]
type PostAddUserToGroup =
    ///OK
    | OK of payload: PostAddUserToGroup_OK

type PostRemoveUserFromGroupPayload =
    { group_id: int
      user_id: int }

type PostRemoveUserFromGroup_OK =
    { success: Option<bool>
      errors: Option<Map<string, list<string>>> }

[<RequireQualifiedAccess>]
type PostRemoveUserFromGroup =
    ///OK
    | OK of payload: PostRemoveUserFromGroup_OK

type GetGetFriends_OK = { friends: Option<list<string>> }

[<RequireQualifiedAccess>]
type GetGetFriends =
    ///OK
    | OK of payload: GetGetFriends_OK
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: unauthorized

type GetGetFriendById_OK = { friend: Option<friend> }

[<RequireQualifiedAccess>]
type GetGetFriendById =
    ///OK
    | OK of payload: GetGetFriendById_OK
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: unauthorized
    ///Forbidden
    | Forbidden of payload: forbidden
    ///Not Found
    | NotFound of payload: notfound

type PostCreateFriendPayload =
    { email: string
      user_first_name: Option<string>
      user_last_name: Option<string> }

type PostCreateFriend_OK = { friend: Option<friend> }

[<RequireQualifiedAccess>]
type PostCreateFriend =
    ///OK
    | OK of payload: PostCreateFriend_OK
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: unauthorized

type PostCreateFriends_OK =
    { users: Option<list<string>>
      errors: Option<list<string>> }

type PostCreateFriends_BadRequest =
    { users: Option<list<string>>
      errors: Option<Map<string, list<string>>> }

[<RequireQualifiedAccess>]
type PostCreateFriends =
    ///OK
    | OK of payload: PostCreateFriends_OK
    ///Bad Request
    | BadRequest of payload: PostCreateFriends_BadRequest
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: unauthorized

type PostDeleteFriendById_OK =
    { success: Option<bool>
      errors: Option<Map<string, list<string>>> }

[<RequireQualifiedAccess>]
type PostDeleteFriendById =
    ///OK
    | OK of payload: PostDeleteFriendById_OK
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: unauthorized
    ///Forbidden
    | Forbidden of payload: forbidden
    ///Not Found
    | NotFound of payload: notfound

type Currencies =
    { currency_code: Option<string>
      unit: Option<string> }

type GetGetCurrencies_OK =
    { currencies: Option<list<Currencies>> }

[<RequireQualifiedAccess>]
type GetGetCurrencies =
    ///OK
    | OK of payload: GetGetCurrencies_OK

type GetGetExpenseById_OK = { expense: Option<expense> }

[<RequireQualifiedAccess>]
type GetGetExpenseById =
    ///OK
    | OK of payload: GetGetExpenseById_OK
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: unauthorized
    ///Forbidden
    | Forbidden of payload: forbidden
    ///Not Found
    | NotFound of payload: notfound

type GetGetExpenses_OK = { expenses: Option<list<expense>> }

[<RequireQualifiedAccess>]
type GetGetExpenses =
    ///OK
    | OK of payload: GetGetExpenses_OK
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: unauthorized
    ///Forbidden
    | Forbidden of payload: forbidden
    ///Not Found
    | NotFound of payload: notfound

type PostCreateExpense_OK =
    { expenses: list<expense>
      errors: Errors }

[<RequireQualifiedAccess>]
type PostCreateExpense =
    ///OK
    | OK of payload: PostCreateExpense_OK
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: unauthorized
    ///Forbidden
    | Forbidden of payload: forbidden

type PostUpdateExpenseById_OK =
    { expenses: Option<list<expense>> }

[<RequireQualifiedAccess>]
type PostUpdateExpenseById =
    ///OK
    | OK of payload: PostUpdateExpenseById_OK
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: unauthorized
    ///Forbidden
    | Forbidden of payload: forbidden

type PostDeleteExpenseById_OK =
    { success: Option<bool> }

[<RequireQualifiedAccess>]
type PostDeleteExpenseById =
    | OK of payload: PostDeleteExpenseById_OK
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: unauthorized
    ///Forbidden
    | Forbidden of payload: forbidden

type PostUndeleteExpenseById_OK = { success: Option<bool> }

[<RequireQualifiedAccess>]
type PostUndeleteExpenseById =
    | OK of payload: PostUndeleteExpenseById_OK
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: unauthorized
    ///Forbidden
    | Forbidden of payload: forbidden

type GetGetComments_OK = { comments: Option<list<comment>> }

[<RequireQualifiedAccess>]
type GetGetComments =
    ///OK
    | OK of payload: GetGetComments_OK
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: unauthorized
    ///Forbidden
    | Forbidden of payload: forbidden
    ///Not Found
    | NotFound of payload: notfound

type PostCreateCommentPayload =
    { expense_id: Option<int>
      content: Option<string> }

type PostCreateComment_OK = { comment: Option<string> }

[<RequireQualifiedAccess>]
type PostCreateComment =
    ///OK
    | OK of payload: PostCreateComment_OK
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: unauthorized
    ///Forbidden
    | Forbidden of payload: forbidden
    ///Not Found
    | NotFound of payload: notfound

type PostDeleteComment_OK = { comment: Option<string> }

[<RequireQualifiedAccess>]
type PostDeleteComment =
    ///OK
    | OK of payload: PostDeleteComment_OK
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: unauthorized
    ///Forbidden
    | Forbidden of payload: forbidden
    ///Not Found
    | NotFound of payload: notfound

type GetGetNotifications_OK =
    { notifications: Option<list<notification>> }

[<RequireQualifiedAccess>]
type GetGetNotifications =
    ///OK
    | OK of payload: GetGetNotifications_OK
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: unauthorized

type GetGetCategories_OK =
    { categories: Option<list<parentcategory>> }

[<RequireQualifiedAccess>]
type GetGetCategories =
    ///OK
    | OK of payload: GetGetCategories_OK

type PostParseSentence_OK =
    { expense: Option<expense>
      valid: Option<bool>
      confidence: Option<float>
      error: Option<string> }

[<RequireQualifiedAccess>]
type PostParseSentence =
    ///OK
    | OK of payload: PostParseSentence_OK
