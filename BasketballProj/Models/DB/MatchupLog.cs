﻿using System;
using System.Collections.Generic;

namespace BasketballProj.Models.DB;

public partial class MatchupLog
{
    public int Id { get; set; }

    public int MatchupId { get; set; }

    public int Quarter { get; set; }

    public string OccurTime { get; set; } = null!;

    public int TeamId { get; set; }

    public int PlayerId { get; set; }

    public int ActionTypeId { get; set; }

    public string? Remark { get; set; }

    public virtual ActionType ActionType { get; set; } = null!;

    public virtual Matchup Matchup { get; set; } = null!;

    public virtual Player Player { get; set; } = null!;

    public virtual Team Team { get; set; } = null!;
}
