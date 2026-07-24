using System;
using System.Collections.Generic;

namespace EF_Practice_1.Models;

public partial class DriverType
{
    public int DriveTypeId { get; set; }

    public string DriveTypeName { get; set; } = null!;

    public virtual ICollection<VehicleDetail> VehicleDetails { get; set; } = new List<VehicleDetail>();
}
