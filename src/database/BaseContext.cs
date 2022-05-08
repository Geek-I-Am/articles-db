using System;
using Geekiam.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Geekiam.Database;

public abstract class BaseContext<T> : DbContext where T : DbContext
{
    protected BaseContext(DbContextOptions<T> options) : base(options)
    {
        this.ChangeTracker.StateChanged += ChangeTracker_StateChanged;
    }

    private static void ChangeTracker_StateChanged(object sender, EntityStateChangedEventArgs e)
    {
        var entity = (BaseEntity)e.Entry.Entity;

        switch (e.NewState)
        {
            case EntityState.Added:
                entity.Created = DateTime.Now;
              break;

            case EntityState.Modified:
                entity.Modified = DateTime.UtcNow;
                break;

            case EntityState.Detached:
            case EntityState.Unchanged:
            case EntityState.Deleted:
            default:
                break;
        }
    }
}
