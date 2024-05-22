using System;
using System.Collections.Generic;

namespace BasketballProj.Models.DB;

public partial class Conference
{
    public int ConferenceId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Division> Divisions { get; set; } = new List<Division>();
}
