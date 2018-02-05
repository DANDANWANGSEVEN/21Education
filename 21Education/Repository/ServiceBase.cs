
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

        public virtual void Add(T item)
        {
            CurrentDbSet.Add(item);
            SaveChanges();
        }

        public virtual void AddRange(params T[] items)
        {
            CurrentDbSet.AddRange(items);
            SaveChanges();
        }

        public virtual void BeginTransaction(Action action)
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

        public virtual int Count(Expression<Func<T, bool>> filter)
        {
            if (filter != null)
            {
                return CurrentDbSet.Where(filter).Count();
            }
            return CurrentDbSet.Count();
        }

        public virtual void Dispose()
        {
            DbContext.Dispose();
        }

        public virtual IQueryable<T> Get()
        {
            return CurrentDbSet;
        }

        public virtual IList<T> Get(Expression<Func<T, bool>> filter)
        {
            return CurrentDbSet.Where(filter).ToList();
        }

        public virtual IList<T> Get(Expression<Func<T, bool>> filter, Pagination pagination)
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

        public virtual T Get(params object[] primaryKey)
        {
            return CurrentDbSet.Find(primaryKey);
        }

        public virtual T GetSingle(Expression<Func<T, bool>> filter)
        {
            return CurrentDbSet.Single(filter);
        }

        public virtual void Remove(params object[] primaryKey)
        {
            CurrentDbSet.Remove(CurrentDbSet.Find(primaryKey));
            SaveChanges();
        }

        public virtual void Remove(T item, bool saveImmediately = true)
        {
            CurrentDbSet.Remove(item);
            if (saveImmediately)
            {
                SaveChanges();
            }
        }

        public virtual void Remove(Expression<Func<T, bool>> filter)
        {
            CurrentDbSet.RemoveRange(CurrentDbSet.Where(filter));
            SaveChanges();
        }

        public virtual void RemoveRange(params T[] items)
        {
            CurrentDbSet.RemoveRange(items);
            SaveChanges();
        }

        public virtual void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        public virtual void Update(T item, bool saveImmediately = true)
        {
            CurrentDbSet.Find(item);
            if (saveImmediately)
            {
               SaveChanges();
            }
        }

        public virtual void UpdateRange(params T[] items)
        {
            items.ToList().ForEach(e => {
                Update(e);
            });
        }
    }
}
