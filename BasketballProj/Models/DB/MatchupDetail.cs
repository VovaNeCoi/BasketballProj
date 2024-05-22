using System;
using System.Collections.Generic;

namespace BasketballProj.Models.DB;

public partial class MatchupDetail
{
    public int Id { get; set; }

    public int MatchupId { get; set; }

    public int Quarter { get; set; }

    public int TeamAwayScore { get; set; }

    public int TeamHomeScore { get; set; }

    public virtual Matchup Matchup { get; set; } = null!;
}
