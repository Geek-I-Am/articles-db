using System;

namespace Geekiam.Database.Entities;

public class ArticleCategories : BaseEntity
{
 
    public Guid ArticleId { get; set; }
    public Guid CategoryId { get; set; }
}