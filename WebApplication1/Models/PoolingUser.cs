using System;
using System.Collections.Generic;

namespace Car_pooling.Models;

public partial class PoolingUser
{
    public int PoolingIdPk { get; set; }

    public int PoolCreateIdFk { get; set; }

    public int? PoolUserIdFk { get; set; }

    public int PoolFare { get; set; }

    public string StartingDestination { get; set; } = null!;

    public string EndingDestination { get; set; } = null!;

    public byte? IsDeleted { get; set; }

    public virtual PoolingCreater PoolCreateIdFkNavigation { get; set; } = null!;

    public virtual UserDetail? PoolUserIdFkNavigation { get; set; }
}
