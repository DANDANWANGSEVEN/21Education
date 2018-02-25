using _21Education.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using _21Education.IOC;
namespace _21Education.Repository
{
    public interface IService<T> : IDisposable, IDependency
        where T : class
    {
        void BeginTransaction(Action action);
        void Add(T item);
        void AddRange(params T[] items);
        IQueryable<T> Get();
        T GetSingle(Expression<Func<T, bool>> filter);
        IList<T> Get(Expression<Func<T, bool>> filter);
        IList<T> Get(Expression<Func<T, bool>> filter, Pagination pagination);
        T Get(params object[] primaryKey);
        int Count(Expression<Func<T, bool>> filter);
        void Update(T item, bool saveImmediately = true);
        void UpdateRange(params T[] items);
        void Remove(params object[] primaryKey);
        void Remove(T item, bool saveImmediately = true);
        void Remove(Expression<Func<T, bool>> filter);
        void RemoveRange(params T[] items);
        void SaveChanges();
    }
}
