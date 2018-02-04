
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using _21Education.DATA;
using _21Education.Extend;

namespace _21Education.Repository
{
    public abstract class ServiceBase<T> : IService<T> where T : class
    {
        public ServiceBase(DbContext dbContext)
        {
            DbContext = dbContext;
        }
        public virtual DbContext DbContext
        {
            get;
            set;
        }
        public abstract DbSet<T> CurrentDbSet { get; }

        public void Add(T item)
        {
            CurrentDbSet.Add(item);
            DbContext.SaveChanges();
        }

        public void AddRange(params T[] items)
        {
            CurrentDbSet.AddRange(items);
            DbContext.SaveChanges();
        }

        public void BeginTransaction(Action action)
        {
            using (var transaction = DbContext.Database.BeginTransaction())
            {
                try
                {
                    action.Invoke();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public int Count(Expression<Func<T, bool>> filter)
        {
            if (filter != null)
            {
                return CurrentDbSet.Where(filter).Count();
            }
            return CurrentDbSet.Count();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Get()
        {
            return CurrentDbSet;
        }

        public IList<T> Get(Expression<Func<T, bool>> filter)
        {
            return CurrentDbSet.Where(filter).ToList();
        }

        public IList<T> Get(Expression<Func<T, bool>> filter, Pagination pagination)
        {
            pagination.RecordCount = Count(filter);
            IQueryable<T> result;
            if (filter != null)
            {
                result = CurrentDbSet.Where(filter);
            }
            else
            {
                result = CurrentDbSet;
            }
            if (pagination.OrderBy != null || pagination.OrderByDescending != null)
            {
                if (pagination.OrderBy != null)
                {
                    result = result.OrderBy(pagination.OrderBy);
                }
                else
                {
                    result = result.OrderByDescending(pagination.OrderByDescending);
                }
            }
            return result.Skip(pagination.PageIndex * pagination.PageSize).Take(pagination.PageSize).ToList();
        }

        public T Get(params object[] primaryKey)
        {
            return CurrentDbSet.Find(primaryKey);
        }

        public T GetSingle(Expression<Func<T, bool>> filter)
        {
            return CurrentDbSet.Single(filter);
        }

        public void Remove(params object[] primaryKey)
        {
            throw new NotImplementedException();
        }

        public void Remove(T item, bool saveImmediately = true)
        {
            throw new NotImplementedException();
        }

        public void Remove(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(params T[] items)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(T item, bool saveImmediately = true)
        {
            CurrentDbSet.Find(item);
            if (saveImmediately)
            {
                DbContext.SaveChanges();
            }
        }

        public void UpdateRange(params T[] items)
        {
            throw new NotImplementedException();
        }
    }
}
