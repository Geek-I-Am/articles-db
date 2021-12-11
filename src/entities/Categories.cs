using System;

namespace Geek.Database.Entities;

public class Categories
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime Created { get; set; }
}