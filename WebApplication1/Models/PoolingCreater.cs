using System;
using System.Collections.Generic;

namespace Car_pooling.Models;

public partial class PoolingCreater
{
    public int PoolingCreaterIdPk { get; set; }

    public int? PoolCreaterIdFk { get; set; }

    public int PoolFare { get; set; }

    public string StartingDestination { get; set; } = null!;

    public string EndingDestination { get; set; } = null!;

    public string VehicleName { get; set; } = null!;

    public string VehicleRegNumber { get; set; } = null!;

    public int SeatNumbers { get; set; }

    public string PoolDate { get; set; } = null!;

    public string PoolTime { get; set; } = null!;

    public byte? IsDeleted { get; set; }

    public virtual UserDetail? PoolCreaterIdFkNavigation { get; set; }

    public virtual ICollection<PoolingUser> PoolingUsers { get; set; } = new List<PoolingUser>();
}
