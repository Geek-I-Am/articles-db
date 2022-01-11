using System;
using System.Collections.Generic;

namespace Geekiam.Database.Entities
{
    public class Tags : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Permalink { get; set; }

        public ICollection<ArticleTags> ArticleTags { get; set; }
    }
    
}