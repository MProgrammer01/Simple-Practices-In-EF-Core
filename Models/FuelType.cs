using System;
using System.Collections.Generic;

namespace EF_Practice_1.Models;

public partial class FuelType
{
    public int FuelTypeId { get; set; }

    public string FuelTypeName { get; set; } = null!;

    public virtual ICollection<VehicleDetail> VehicleDetails { get; set; } = new List<VehicleDetail>();
}
