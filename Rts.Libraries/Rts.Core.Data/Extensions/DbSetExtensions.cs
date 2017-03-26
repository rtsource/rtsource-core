using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rts.Core.Model;

namespace Rts.Core.Data.Extensions
{
    public static class DbSetExtensions
    {
        public static async Task<T> AddOrUpdateByName<T>(this DbSet<T> set, string name, Action<T> setProperties)
            where T : NamedEntity, new()
        {
            var entity = await set.FirstOrDefaultAsync(_ => string.Equals(_.Name, name));
            var add = entity == null;
            if (add)
                entity = new T {Name = name,};
            setProperties(entity);
            if (add)
                await set.AddAsync(entity);
            return entity;
        }
    }
}
