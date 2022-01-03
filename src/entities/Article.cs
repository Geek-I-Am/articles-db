using System;

namespace Geekiam.Database.Entities
{
    public class Articles : BaseEntity
    {
      
        public string Title { get; set; }
        public Authors Author { get; set; }
        public string Summary { get; set; }
        
        public string Content { get; set; }
        public DateTime Published { get; set; }
        public string Url { get; set; }
        
        public DateTime Created { get; set; }

       
    }
}