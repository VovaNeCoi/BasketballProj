using System;
using System.Collections.Generic;

namespace BasketballProj.Models.DB;

public partial class Picture
{
    public int Id { get; set; }

    public byte[] Img { get; set; } = null!;

    public string? Description { get; set; }

    public int NumberOfLike { get; set; }

    public DateTime CreateTime { get; set; }
}
