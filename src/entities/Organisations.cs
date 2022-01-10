using System;

namespace Geekiam.Database.Entities;

public class Organisations : BaseEntity
{
    public string Name { get; set; }
    public string Url { get; set; }
    public string Description  { get; set; }
    public DateTime Registered { get; set; }
   
    
}