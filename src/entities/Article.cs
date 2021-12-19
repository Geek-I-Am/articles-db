﻿using System;

namespace Geekiam.Database.Entities
{
    public class Articles
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Summary { get; set; }
        public DateTime Published { get; set; }
        public string Url { get; set; }
        
        public DateTime Created { get; set; }

       
    }
}