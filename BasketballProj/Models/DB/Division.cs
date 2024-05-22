using System;
using System.Collections.Generic;

namespace BasketballProj.Models.DB;

public partial class Division
{
    public int DivisionId { get; set; }

    public string Name { get; set; } = null!;

    public int ConferenceId { get; set; }

    public virtual Conference Conference { get; set; } = null!;

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
