using System;
using System.Collections.Generic;

namespace EF_Practice_1.Models;

public partial class Make
{
    public int MakeId { get; set; }

    public string MakeName { get; set; } = null!;

    public virtual ICollection<MakeModel> MakeModels { get; set; } = new List<MakeModel>();
}
