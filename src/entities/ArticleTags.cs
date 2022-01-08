using System;
using System.Collections.Generic;

namespace Geekiam.Database.Entities
{
    public class ArticleTags : BaseEntity
    {
    
        public Guid ArticleId { get; set; }
        public Guid TagId { get; set; }
        
        public ICollection<Articles> Articles { get; set; }
        public ICollection<Tags> Tags { get; set; }
    }
}