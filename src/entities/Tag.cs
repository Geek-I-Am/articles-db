using System;

namespace Geek.Database.Entities
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }

    }
}