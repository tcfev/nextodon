﻿using System;
using System.Collections.Generic;

namespace Nextodon.Data.PostgreSQL.Models;

public partial class FollowRequest
{
    public long Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long AccountId { get; set; }

    public long TargetAccountId { get; set; }

    public bool? ShowReblogs { get; set; }

    public string? Uri { get; set; }

    public bool Notify { get; set; }

    public string[]? Languages { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Account TargetAccount { get; set; } = null!;
}
