using System;
using System.Collections.Generic;

namespace BasketballProj.Models.DB;

public partial class PostSeason
{
    public int TeamId { get; set; }

    public int SeasonId { get; set; }

    public int Rank { get; set; }

    public virtual Season Season { get; set; } = null!;

    public virtual Team Team { get; set; } = null!;
}
