using System;
using System.Collections.Generic;

namespace EF_Practice_1.Models;

public partial class SubModel
{
    public int SubModelId { get; set; }

    public int ModelId { get; set; }

    public string SubModelName { get; set; } = null!;

    public virtual MakeModel Model { get; set; } = null!;

    public virtual ICollection<VehicleDetail> VehicleDetails { get; set; } = new List<VehicleDetail>();
}
