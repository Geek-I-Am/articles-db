using System;
using System.Collections.Generic;

namespace Geekiam.Database.Entities;

public class Authors : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Biography { get; set; }

    public ICollection<Articles> Articles { get; set; }
}