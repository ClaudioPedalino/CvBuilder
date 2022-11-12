using CvBuilder.Core.Helpers;
using CvBuilder.Core.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CvBuilder.Core.Extensions
{
    public static class EntitiesExtension
    {
        public static bool IsByUser(this EntityEntry entityEntry)
            => entityEntry.Entity
                .GetType()
                .GetInterfaces()
                .Any(x => x.Name == nameof(IByUser));


        public static bool IsNew(this EntityEntry entityEntry)
            => entityEntry.State == EntityState.Added;


        //public static bool IsUpdate(this EntityEntry entityEntry)
        //    => entityEntry.State == EntityState.Modified;


        public static void SetTenant(this EntityEntry entityEntry, Guid userId)
            => entityEntry.Entity.GetType()
                                 .GetProperties()
                                 .FirstOrDefault(x => x.Name == "UserId")?
                                 .SetValue(entityEntry.Entity, userId);


        //public static void SetUpdateDate(this EntityEntry entityEntry)
        //    => entityEntry.Entity.GetType()
        //                         .GetProperties()
        //                         .FirstOrDefault(x => x.Name == "UpdateDate")?
        //                         .SetValue(entityEntry.Entity, DateTimeHelper.GetSystemDate());


        public static void SetCreatedDate(this EntityEntry entityEntry)
            => Array.Find(entityEntry.Entity
                .GetType()
                .GetProperties(), x => x.Name == "CreatedAt")?
                .SetValue(entityEntry.Entity, DateTimeHelper.GetSystemDate());
    }
}
