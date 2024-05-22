﻿using System;
using System.Collections.Generic;

namespace BasketballProj.Models.DB;

public partial class Team
{
    public int TeamId { get; set; }

    public string TeamName { get; set; } = null!;

    public int DivisionId { get; set; }

    public string Coach { get; set; } = null!;

    public string Abbr { get; set; } = null!;

    public string? Stadium { get; set; }

    public byte[] Logo { get; set; } = null!;

    public virtual Division Division { get; set; } = null!;

    public virtual ICollection<MatchupLog> MatchupLogs { get; set; } = new List<MatchupLog>();

    public virtual ICollection<Matchup> MatchupTeamAwayNavigations { get; set; } = new List<Matchup>();

    public virtual ICollection<Matchup> MatchupTeamHomeNavigations { get; set; } = new List<Matchup>();

    public virtual ICollection<PlayerInTeam> PlayerInTeams { get; set; } = new List<PlayerInTeam>();

    public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; } = new List<PlayerStatistic>();

    public virtual ICollection<PostSeason> PostSeasons { get; set; } = new List<PostSeason>();
}
