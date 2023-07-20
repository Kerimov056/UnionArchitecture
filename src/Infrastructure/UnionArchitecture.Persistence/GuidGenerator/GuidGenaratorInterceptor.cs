﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace UnionArchitecture.Persistence.GuidGenerator
{
    public class GuidGenaratorInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData,
                                                              InterceptionResult<int> result)
        {
            GenerateIdProperties(eventData.Context.ChangeTracker.Entries());
            return result;
        }

        private static void GenerateIdProperties(IEnumerable<EntityEntry> entities)
        {
            foreach (var entry in entities)
            {
                if (entry.State == EntityState.Added)
                {
                    foreach (var propertes in entry.Properties)
                    {
                        if (propertes.Metadata.Name == "Id" && propertes.CurrentValue == null)
                        {
                            propertes.CurrentValue = Guid.NewGuid();
                            break;
                        }
                    }
                }
            }
        }
    }
}
