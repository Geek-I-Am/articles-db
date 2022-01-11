using System;
using System.Collections.Generic;

namespace Geekiam.Database.Entities;

public class Categories : BaseEntity
{
   
    public string Name { get; set; }
    public string Description { get; set; }
    public string Permalink { get; set; }

    public ICollection<ArticleCategories> ArticleCategories { get; set; }
}