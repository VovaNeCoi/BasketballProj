﻿using System;
using System.Collections.Generic;

namespace BasketballProj.Models.DB;

public partial class Role
{
    public string RoleId { get; set; } = null!;

    public string RoleName { get; set; } = null!;

    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();
}
