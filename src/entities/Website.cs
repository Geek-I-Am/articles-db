using System;

namespace Geek.Database.Entities
{
    public class Website
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string  Url { get; set; }
        public string Tagline { get; set; }
        
        
    }
}