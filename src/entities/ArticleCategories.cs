using System;
using System.Collections.Generic;

namespace Geekiam.Database.Entities;

public class ArticleCategories
{
    public Guid ArticleId { get; set; }
    public Articles Article { get; set; }
    public Guid CategoryId { get; set; }
    public Categories Category { get; set; }
    
    
}