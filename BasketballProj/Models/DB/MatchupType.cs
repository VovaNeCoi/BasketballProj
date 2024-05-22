using System;
using System.Collections.Generic;

namespace BasketballProj.Models.DB;

public partial class MatchupType
{
    public int MatchupTypeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Matchup> Matchups { get; set; } = new List<Matchup>();
}
