using System;
using System.Collections.Generic;

namespace BasketballProj.Models.DB;

public partial class Player
{
    public int PlayerId { get; set; }

    public string Name { get; set; } = null!;

    public int PositionId { get; set; }

    public DateOnly JoinYear { get; set; }

    public decimal Height { get; set; }

    public decimal Weight { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public string? College { get; set; }

    public string CountryCode { get; set; } = null!;

    public byte[]? Img { get; set; }

    public bool IsRetirment { get; set; }

    public DateOnly? RetirmentTime { get; set; }

    public virtual Country CountryCodeNavigation { get; set; } = null!;

    public virtual ICollection<MatchupLog> MatchupLogs { get; set; } = new List<MatchupLog>();

    public virtual ICollection<PlayerInTeam> PlayerInTeams { get; set; } = new List<PlayerInTeam>();

    public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; } = new List<PlayerStatistic>();

    public virtual Position Position { get; set; } = null!;
}
