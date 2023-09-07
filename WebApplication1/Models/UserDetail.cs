using System;
using System.Collections.Generic;

namespace Car_pooling.Models;

public partial class UserDetail
{
    public int UserIdPk { get; set; }

    public string UserName { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public string UserPhonenumber { get; set; } = null!;

    public string UserCity { get; set; } = null!;

    public int? UserSubFk { get; set; }

    public string UserRole { get; set; } = null!;

    public byte? IsDeleted { get; set; }

    public virtual ICollection<PoolingCreater> PoolingCreaters { get; set; } = new List<PoolingCreater>();

    public virtual ICollection<PoolingUser> PoolingUsers { get; set; } = new List<PoolingUser>();

    public virtual Subscribtion? UserSubFkNavigation { get; set; }
}
