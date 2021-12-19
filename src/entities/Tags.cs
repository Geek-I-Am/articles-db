using System;

namespace Geekiam.Database.Entities
{
    public class Tags
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Permalink { get; set; }
        public DateTime Created { get; set; }
    }
}