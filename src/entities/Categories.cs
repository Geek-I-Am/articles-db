using System;

namespace Geekiam.Database.Entities;

public class Categories
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Permalink { get; set; }
    public DateTime Created { get; set; }
}