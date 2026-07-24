using System;
using System.Collections.Generic;

namespace EF_Practice_1.Models;

public partial class Body
{
    public int BodyId { get; set; }

    public string BodyName { get; set; } = null!;

    public virtual ICollection<VehicleDetail> VehicleDetails { get; set; } = new List<VehicleDetail>();
}
