using System;
using System.Collections.Generic;

namespace Geekiam.Database.Entities
{
    public class Articles : BaseEntity
    {
      
        public string Title { get; set; }
      
        public string Summary { get; set; }
        
        public string Content { get; set; }
        public DateTime Published { get; set; }
        public string Url { get; set; }
        

        public ICollection<ArticleCategories> ArticleCategories { get; set; }
        public ICollection<ArticleTags> ArticleTags { get; set; }
    }
}