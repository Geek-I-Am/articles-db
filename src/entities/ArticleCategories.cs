using System;

namespace Geekiam.Database.Entities;

public class ArticleCategories
{
    public Guid Id { get; set; }
    public Guid ArticleId { get; set; }
    public Guid CategoryId { get; set; }
}