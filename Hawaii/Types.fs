namespace rec SplitwiseSharp.Types

type Debt =
    { ///User ID
      from: Option<int>
      ///User ID
      ``to``: Option<int>
      amount: Option<string>
      currency_code: Option<string> }
    ///Creates an instance of Debt with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): Debt =
        { from = None
          ``to`` = None
          amount = None
          currency_code = None }

[<Fable.Core.StringEnum; RequireQualifiedAccess>]
type Registrationstatus =
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
    ///Creates an instance of Picture with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): Picture =
        { small = None
          medium = None
          large = None }

type User =
    { id: Option<int>
      first_name: Option<string>
      last_name: Option<string>
      email: Option<string>
      registration_status: Option<Registrationstatus>
      picture: Option<Picture> }
    ///Creates an instance of User with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): User =
        { id = None
          first_name = None
          last_name = None
          email = None
          registration_status = None
          picture = None }

[<Fable.Core.StringEnum; RequireQualifiedAccess>]
type CurrentUserRegistrationstatus =
    | [<CompiledName "confirmed">] Confirmed
    | [<CompiledName "dummy">] Dummy
    | [<CompiledName "invited">] Invited
    member this.Format() =
        match this with
        | Confirmed -> "confirmed"
        | Dummy -> "dummy"
        | Invited -> "invited"

type CurrentUserPicture =
    { small: Option<string>
      medium: Option<string>
      large: Option<string> }
    ///Creates an instance of CurrentUserPicture with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): CurrentUserPicture =
        { small = None
          medium = None
          large = None }

type CurrentUser =
    { id: Option<int>
      first_name: Option<string>
      last_name: Option<string>
      email: Option<string>
      registration_status: Option<CurrentUserRegistrationstatus>
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
    ///Creates an instance of CurrentUser with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): CurrentUser =
        { id = None
          first_name = None
          last_name = None
          email = None
          registration_status = None
          picture = None
          notifications_read = None
          notifications_count = None
          notifications = None
          default_currency = None
          locale = None }

[<Fable.Core.StringEnum; RequireQualifiedAccess>]
type Grouptype =
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
    ///Creates an instance of Avatar with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): Avatar =
        { original = None
          xxlarge = None
          xlarge = None
          large = None
          medium = None
          small = None }

type Coverphoto =
    { xxlarge: Option<string>
      xlarge: Option<string> }
    ///Creates an instance of Coverphoto with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): Coverphoto = { xxlarge = None; xlarge = None }

type Group =
    { id: Option<int>
      name: Option<string>
      group_type: Option<Grouptype>
      updated_at: Option<System.DateTimeOffset>
      simplify_by_default: Option<bool>
      members: Option<list<string>>
      original_debts: Option<list<debt>>
      simplified_debts: Option<list<debt>>
      avatar: Option<Avatar>
      custom_avatar: Option<bool>
      cover_photo: Option<Coverphoto>
      ///A link the user can send to a friend to join the group directly
      invite_link: Option<string> }
    ///Creates an instance of Group with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): Group =
        { id = None
          name = None
          group_type = None
          updated_at = None
          simplify_by_default = None
          members = None
          original_debts = None
          simplified_debts = None
          avatar = None
          custom_avatar = None
          cover_photo = None
          invite_link = None }

type UnauthorizedError =
    { error: Option<string> }
    ///Creates an instance of UnauthorizedError with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): UnauthorizedError = { error = None }

type Errors =
    { ``base``: Option<list<string>> }
    ///Creates an instance of Errors with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): Errors = { ``base`` = None }

type ForbiddenError =
    { errors: Option<Errors> }
    ///Creates an instance of ForbiddenError with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): ForbiddenError = { errors = None }

type NotFoundErrorErrors =
    { ``base``: Option<list<string>> }
    ///Creates an instance of NotFoundErrorErrors with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): NotFoundErrorErrors = { ``base`` = None }

type NotFoundError =
    { errors: Option<NotFoundErrorErrors> }
    ///Creates an instance of NotFoundError with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): NotFoundError = { errors = None }

[<Fable.Core.StringEnum; RequireQualifiedAccess>]
type userRegistrationstatus =
    | [<CompiledName "confirmed">] Confirmed
    | [<CompiledName "dummy">] Dummy
    | [<CompiledName "invited">] Invited
    member this.Format() =
        match this with
        | Confirmed -> "confirmed"
        | Dummy -> "dummy"
        | Invited -> "invited"

type userPicture =
    { small: Option<string>
      medium: Option<string>
      large: Option<string> }
    ///Creates an instance of userPicture with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): userPicture =
        { small = None
          medium = None
          large = None }

type useruser =
    { id: int
      first_name: Option<string>
      last_name: Option<string>
      email: Option<string>
      registration_status: Option<userRegistrationstatus>
      picture: Option<userPicture> }

type user =
    { user : useruser }

[<Fable.Core.StringEnum; RequireQualifiedAccess>]
type currentuserRegistrationstatus =
    | [<CompiledName "confirmed">] Confirmed
    | [<CompiledName "dummy">] Dummy
    | [<CompiledName "invited">] Invited
    member this.Format() =
        match this with
        | Confirmed -> "confirmed"
        | Dummy -> "dummy"
        | Invited -> "invited"

type currentuserPicture =
    { small: Option<string>
      medium: Option<string>
      large: Option<string> }
    ///Creates an instance of currentuserPicture with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): currentuserPicture =
        { small = None
          medium = None
          large = None }

type currentuseruser = 
    { id: int
      first_name: Option<string>
      last_name: Option<string>
      email: Option<string>
      registration_status: Option<currentuserRegistrationstatus>
      picture: Option<currentuserPicture>
      ///ISO 8601 date/time indicating the last time notifications were read
      notifications_read: Option<string>
      ///Number of unread notifications since notifiations_read
      notifications_count: Option<int>
      ///User's notification preferences
      notifications: Option<Map<string, bool>>
      default_currency: Option<string>
      ///ISO_639-1 2-letter locale code
      locale: Option<string> }

type currentuser =
    { user: currentuseruser }

type unauthorized =
    { error: Option<string> }
    ///Creates an instance of unauthorized with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): unauthorized = { error = None }

type forbiddenErrors =
    { ``base``: Option<list<string>> }
    ///Creates an instance of forbiddenErrors with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): forbiddenErrors = { ``base`` = None }

type forbidden =
    { errors: forbiddenErrors }

type notfoundErrors =
    { ``base``: Option<list<string>> }
    ///Creates an instance of notfoundErrors with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): notfoundErrors = { ``base`` = None }

type notfound =
    { errors: notfoundErrors }

type debt =
    { ///User ID
      from: Option<int>
      ///User ID
      ``to``: Option<int>
      amount: Option<string>
      currency_code: Option<string> }
    ///Creates an instance of debt with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): debt =
        { from = None
          ``to`` = None
          amount = None
          currency_code = None }

[<Fable.Core.StringEnum; RequireQualifiedAccess>]
type groupGrouptype =
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

type groupAvatar =
    { original: Option<string>
      xxlarge: Option<string>
      xlarge: Option<string>
      large: Option<string>
      medium: Option<string>
      small: Option<string> }
    ///Creates an instance of groupAvatar with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): groupAvatar =
        { original = None
          xxlarge = None
          xlarge = None
          large = None
          medium = None
          small = None }

type groupCoverphoto =
    { xxlarge: Option<string>
      xlarge: Option<string> }
    ///Creates an instance of groupCoverphoto with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): groupCoverphoto = { xxlarge = None; xlarge = None }

type group =
    { id: Option<int>
      name: Option<string>
      group_type: Option<groupGrouptype>
      updated_at: Option<System.DateTimeOffset>
      simplify_by_default: Option<bool>
      members: Option<list<string>>
      original_debts: Option<list<debt>>
      simplified_debts: Option<list<debt>>
      avatar: Option<groupAvatar>
      custom_avatar: Option<bool>
      cover_photo: Option<groupCoverphoto>
      ///A link the user can send to a friend to join the group directly
      invite_link: Option<string> }
    ///Creates an instance of group with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): group =
        { id = None
          name = None
          group_type = None
          updated_at = None
          simplify_by_default = None
          members = None
          original_debts = None
          simplified_debts = None
          avatar = None
          custom_avatar = None
          cover_photo = None
          invite_link = None }

type balance =
    { currency_code: Option<string>
      amount: Option<string> }
    ///Creates an instance of balance with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): balance = { currency_code = None; amount = None }

[<Fable.Core.StringEnum; RequireQualifiedAccess>]
type friendRegistrationstatus =
    | [<CompiledName "confirmed">] Confirmed
    | [<CompiledName "dummy">] Dummy
    | [<CompiledName "invited">] Invited
    member this.Format() =
        match this with
        | Confirmed -> "confirmed"
        | Dummy -> "dummy"
        | Invited -> "invited"

type friendPicture =
    { small: Option<string>
      medium: Option<string>
      large: Option<string> }
    ///Creates an instance of friendPicture with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): friendPicture =
        { small = None
          medium = None
          large = None }

type Groups =
    { group_id: Option<int>
      balance: Option<list<balance>> }
    ///Creates an instance of Groups with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): Groups = { group_id = None; balance = None }

type friend =
    { id: Option<int>
      first_name: Option<string>
      last_name: Option<string>
      email: Option<string>
      registration_status: Option<friendRegistrationstatus>
      picture: Option<friendPicture>
      groups: Option<list<Groups>>
      balance: Option<list<balance>>
      updated_at: Option<System.DateTimeOffset> }
    ///Creates an instance of friend with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): friend =
        { id = None
          first_name = None
          last_name = None
          email = None
          registration_status = None
          picture = None
          groups = None
          balance = None
          updated_at = None }

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
    ///Creates an instance of common with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): common =
        { cost = None
          group_id = None
          description = None
          details = None
          date = None
          repeat_interval = None
          currency_code = None
          category_id = None }

type commentuserPicture =
    { medium: Option<string> }
    ///Creates an instance of commentuserPicture with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): commentuserPicture = { medium = None }

type commentuser =
    { id: Option<int>
      first_name: Option<string>
      last_name: Option<string>
      picture: Option<commentuserPicture> }
    ///Creates an instance of commentuser with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): commentuser =
        { id = None
          first_name = None
          last_name = None
          picture = None }

type share =
    { user: Option<commentuser>
      user_id: Option<int>
      paid_share: Option<string>
      owed_share: Option<string>
      net_balance: Option<string> }
    ///Creates an instance of share with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): share =
        { user = None
          user_id = None
          paid_share = None
          owed_share = None
          net_balance = None }

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
    ///Creates an instance of comment with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): comment =
        { id = None
          content = None
          comment_type = None
          relation_type = None
          relation_id = None
          created_at = None
          deleted_at = None }

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
    ///Creates an instance of Repayments with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): Repayments =
        { from = None
          ``to`` = None
          amount = None }

type Category =
    { id: Option<int>
      ///Translated to the current user's locale
      name: Option<string> }
    ///Creates an instance of Category with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): Category = { id = None; name = None }

type Receipt =
    { large: Option<string>
      original: Option<string> }
    ///Creates an instance of Receipt with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): Receipt = { large = None; original = None }

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
      created_by: Option<string>
      ///The last time the expense was updated.
      updated_at: Option<System.DateTimeOffset>
      updated_by: Option<string>
      ///If the expense was deleted, when it was deleted.
      deleted_at: Option<System.DateTimeOffset>
      deleted_by: Option<string>
      category: Option<Category>
      receipt: Option<Receipt>
      users: Option<list<share>>
      comments: Option<list<comment>> }
    ///Creates an instance of expense with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): expense =
        { cost = None
          group_id = None
          description = None
          details = None
          date = None
          repeat_interval = None
          currency_code = None
          category_id = None
          id = None
          friendship_id = None
          expense_bundle_id = None
          repeats = None
          email_reminder = None
          email_reminder_in_advance = None
          next_repeat = None
          comments_count = None
          payment = None
          transaction_confirmed = None
          repayments = None
          created_at = None
          created_by = None
          updated_at = None
          updated_by = None
          deleted_at = None
          deleted_by = None
          category = None
          receipt = None
          users = None
          comments = None }

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
    ///Creates an instance of equalgroupsplit with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): equalgroupsplit =
        { cost = None
          group_id = None
          description = None
          details = None
          date = None
          repeat_interval = None
          currency_code = None
          category_id = None
          split_equally = None }

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
      group_id: Option<int>
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
      users__1__first_name: Option<string>
      users__1__last_name: Option<string>
      users__1__email: Option<string>
      ///Decimal amount as a string with 2 decimal places. The amount this user paid for the expense
      users__1__paid_share: Option<string>
      ///Decimal amount as a string with 2 decimal places. The amount this user owes for the expense
      users__1__owed_share: Option<string> }
    ///Creates an instance of byshares with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): byshares =
        { cost = None
          group_id = None
          description = None
          details = None
          date = None
          repeat_interval = None
          currency_code = None
          category_id = None
          users__0__user_id = None
          users__0__paid_share = None
          users__0__owed_share = None
          users__1__first_name = None
          users__1__last_name = None
          users__1__email = None
          users__1__paid_share = None
          users__1__owed_share = None }

type Source =
    { ``type``: Option<string>
      id: Option<int>
      url: Option<string> }
    ///Creates an instance of Source with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): Source =
        { ``type`` = None
          id = None
          url = None }

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
    ///Creates an instance of notification with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): notification =
        { id = None
          ``type`` = None
          created_at = None
          created_by = None
          source = None
          image_url = None
          image_shape = None
          content = None }

type Slim =
    { small: Option<string>
      large: Option<string> }
    ///Creates an instance of Slim with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): Slim = { small = None; large = None }

type Square =
    { large: Option<string>
      xlarge: Option<string> }
    ///Creates an instance of Square with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): Square = { large = None; xlarge = None }

type Icontypes =
    { slim: Option<Slim>
      square: Option<Square> }
    ///Creates an instance of Icontypes with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): Icontypes = { slim = None; square = None }

type category =
    { id: Option<int>
      name: Option<string>
      icon: Option<string>
      icon_types: Option<Icontypes> }
    ///Creates an instance of category with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): category =
        { id = None
          name = None
          icon = None
          icon_types = None }

type parentcategoryIcontypesSlim =
    { small: Option<string>
      large: Option<string> }
    ///Creates an instance of parentcategoryIcontypesSlim with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): parentcategoryIcontypesSlim = { small = None; large = None }

type parentcategoryIcontypesSquare =
    { large: Option<string>
      xlarge: Option<string> }
    ///Creates an instance of parentcategoryIcontypesSquare with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): parentcategoryIcontypesSquare = { large = None; xlarge = None }

type parentcategoryIcontypes =
    { slim: Option<parentcategoryIcontypesSlim>
      square: Option<parentcategoryIcontypesSquare> }
    ///Creates an instance of parentcategoryIcontypes with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): parentcategoryIcontypes = { slim = None; square = None }

type parentcategory =
    { id: Option<int>
      name: Option<string>
      icon: Option<string>
      icon_types: Option<parentcategoryIcontypes>
      subcategories: Option<list<category>> }
    ///Creates an instance of parentcategory with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): parentcategory =
        { id = None
          name = None
          icon = None
          icon_types = None
          subcategories = None }

[<RequireQualifiedAccess>]
type GetGetCurrentUser =
    ///OK
    | OK of payload: currentuser
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: unauthorized

[<RequireQualifiedAccess>]
type GetGetUserById =
    ///OK
    | OK of payload: user
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: unauthorized
    ///Forbidden
    | Forbidden of payload: forbidden
    ///Not Found
    | NotFound of payload: notfound

[<RequireQualifiedAccess>]
type PostUpdateUserById =
    ///OK
    | OK of payload: user
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: unauthorized
    ///Forbidden
    | Forbidden of payload: forbidden

type GetGetGroups_OK = { groups: Option<list<group>> }

[<RequireQualifiedAccess>]
type GetGetGroups =
    ///OK
    | OK of payload: GetGetGroups_OK
    ///Invalid API key or OAuth access token
    | Unauthorized of payload: unauthorized

type GetGetGroupById_OK = { group: Option<group> }

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

type PostCreateGroup_OK = { group: Option<group> }
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
      user: Option<user>
      errors: Option<Map<string, list<string>>> }

[<RequireQualifiedAccess>]
type PostAddUserToGroup =
    ///OK
    | OK of payload: PostAddUserToGroup_OK

type PostRemoveUserFromGroupPayload =
    { group_id: int
      user_id: int }
    ///Creates an instance of PostRemoveUserFromGroupPayload with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (group_id: int, user_id: int): PostRemoveUserFromGroupPayload =
        { group_id = group_id
          user_id = user_id }

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
    ///Creates an instance of PostCreateFriendPayload with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (email: string): PostCreateFriendPayload =
        { email = email
          user_first_name = None
          user_last_name = None }

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
    { expenses: Option<list<expense>> }

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
    ///Creates an instance of PostCreateCommentPayload with all optional fields initialized to None. The required fields are parameters of this function
    static member Create (): PostCreateCommentPayload = { expense_id = None; content = None }

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
