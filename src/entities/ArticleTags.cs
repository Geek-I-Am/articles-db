using System;
using System.Collections.Generic;

namespace Geekiam.Database.Entities;

public class ArticleTags
{
    public Guid ArticleId { get; set; }
    public Articles Article { get; set; }
    public Guid TagId { get; set; }
    public Tags Tag { get; set; }
    
    public ICollection<ArticleTags> Articles { get; set; }
}