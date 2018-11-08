using System.Linq;
using SametKabay.Core.Interface;

namespace SametKabay.Application.Extensions
{
    static class Extensions
    {
        public static IQueryable<T> WhereIsDeleted<T>(this IQueryable<T> query, bool deleted)
            where T : IDeletable
        {
            return query.Where(p => !p.IsDeleted);
        }

        public static IQueryable<T> WhereIsActive<T>(this IQueryable<T> query, bool active)
                    where T : IActivable
        {
            return query.Where(p => p.IsActive);
        }



        //public static IQueryable<BlogPost> WhereByIsDeleted(
        //    this IQueryable<IBaseEntity> query, bool isDeleted)
        //{
        //    return (IQueryable<BlogPost>)query.Where(p => p.IsDeleted == isDeleted);
        //}

        //public static IQueryable<BlogPost> WhereByIsActive(
        //    this IQueryable<IBaseEntity> query, bool isActive)
        //{
        //    return (IQueryable<BlogPost>)query.Where(p => p.IsActive == isActive);
        //}
    }

}
