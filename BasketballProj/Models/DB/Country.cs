using System;
using System.Collections.Generic;

namespace BasketballProj.Models.DB;

public partial class Country
{
    public string CountryCode { get; set; } = null!;

    public string CountryName { get; set; } = null!;

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();
}
