using System;

namespace Geekiam.Database.Entities
{
    public class ArticleTags
    {
        public Guid Id { get; set; }
        public Guid ArticleId { get; set; }
        public Guid TagId { get; set; }
    }
}