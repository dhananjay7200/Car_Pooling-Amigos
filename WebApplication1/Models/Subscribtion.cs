using System;
using System.Collections.Generic;

namespace Car_pooling.Models;

public partial class Subscribtion
{
    public int SubId { get; set; }

    public string? SubType { get; set; }

    public int? SubCalls { get; set; }

    public virtual ICollection<UserDetail> UserDetails { get; set; } = new List<UserDetail>();
}
