using System;

namespace Geekiam.Database.Entities
{
    public class ArticleTags : BaseEntity
    {
    
        public Guid ArticleId { get; set; }
        public Guid TagId { get; set; }
    }
}