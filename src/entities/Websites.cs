using System;
using System.Collections.Generic;

namespace Geekiam.Database.Entities;

public class Websites : BaseEntity
{
    public string Name { get; set; }
    public string Url { get; set; }

    public bool Active { get; set; }
    public bool Moderate { get; set; }

    public ICollection<Feeds> Feeds { get; set; }
    
    
}