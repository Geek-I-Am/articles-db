using System;
using System.Collections.Generic;

namespace Geekiam.Database.Entities
{
    public class Articles : BaseEntity
    {
      
        public string Title { get; set; }
        public Guid AuthorId { get; set; }
        public Authors Author { get; set; }
        public string Summary { get; set; }
        
        public string Content { get; set; }
        public DateTime Published { get; set; }
        public string Url { get; set; }
        
        public DateTime Created { get; set; }

        public ICollection<Categories> Categories { get; set; }
        public ICollection<Tags> Tags { get; set; }
    }
}