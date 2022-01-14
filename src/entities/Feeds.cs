using System;

namespace Geekiam.Database.Entities;

public class Feeds : BaseEntity
{

    public Guid WebsiteID { get; set; }
    public Websites Website { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }
    public string FeedType { get; set; }

  
}