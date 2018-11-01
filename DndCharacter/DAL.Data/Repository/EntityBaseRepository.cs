using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Data.Repository
{
    public class EntityBaseRepository
    {
        protected DbContext _context;
        public EntityBaseRepository(DndCharacterManagerContext context)
        {
            _context = context;
        }

        #region SyncMethods
        public virtual IEnumerable<T> GetAll<T>(Expression<Func<T, T>> select = null, bool asNoTracking = false) where T:class, new()
        {
            IQueryable<T> query = _context.Set<T>();
            if(select != null)
            {
                query = query.Select(select);
            }
            return (asNoTracking ? query.AsNoTracking().AsEnumerable() : query.AsEnumerable());
        }

        public virtual IEnumerable<T> GetAllIncluding<T>(params Expression<Func<T, object>>[] includeProperties) where T : class
        {
            IQueryable<T> query = _context.Set<T>();
            foreach(var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.AsEnumerable();
        }

        public virtual IEnumerable<T> GetAllWhere<T>(List<Expression<Func<T, bool>>> whereExpressions, Expression<Func<T, T>> select = null, bool asNoTracking = false, params Expression<Func<T, object>>[] includeProperties) where T : class, new()
        {
            return GetAllQueryable(whereExpressions, select, asNoTracking, includeProperties).AsEnumerable();
        }

        public virtual int Count<T>() where T : class, new()
        {
            return _context.Set<T>().Count();
        }

        public T GetSingle<T>(Expression<Func<T, bool>> predicate, bool asNoTracking = false, params Expression<Func<T, object>>[] includeProperties) where T : class, new()
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            var entity = (asNoTracking ? query.AsNoTracking().FirstOrDefault(predicate) : query.FirstOrDefault(predicate));
            return entity;
        }

        public T GetSingleLocal<T>(Expression<Func<T, bool>> predicate, bool asNoTracking = false, params Expression<Func<T, object>>[] includeProperties) where T : class, new()
        {
            IQueryable<T> query = _context.Set<T>().Local.AsQueryable();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return (asNoTracking ? query.AsNoTracking().FirstOrDefault(predicate) : query.FirstOrDefault(predicate));
        }

        public T GetSingle<T>(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> select) where T : class, new()
        {
            IQueryable<T> query = _context.Set<T>();

            if (select != null)
                query = query.AsNoTracking().Where(predicate).Select(select);
            else
                query = query.Where(predicate);

            return query.FirstOrDefault();
        }

        public virtual IEnumerable<T> FindBy<T>(Expression<Func<T, bool>> predicate) where T : class, new()
        {
            return _context.Set<T>().Where(predicate);
        }

        public virtual void Add<T>(T entity) where T : class, new()
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            _context.Set<T>().Add(entity);
        }

        public virtual void Add<T>(object entityObject) where T : class, new()
        {
            T entity = (T)entityObject;
            EntityEntry dbEntityEntry = _context.Entry(entity);
            _context.Set<T>().Add(entity);
        }

        public virtual void AddRange(IEnumerable<object> entityList)
        {
            _context.AddRange(entityList);
        }

        public virtual void Update<T>(T entity) where T : class, new()
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void UpdateRange(IEnumerable<object> entityList)
        {
            _context.UpdateRange(entityList);
        }

        public virtual void Delete<T>(T entity) where T : class, new()
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public virtual void DeleteWhere<T>(Expression<Func<T, bool>> predicate) where T : class, new()
        {
            IEnumerable<T> entities = _context.Set<T>().Where(predicate);
            _context.RemoveRange(entities);
        }

        public virtual void DeleteRange<T>(IEnumerable<T> entityList) where T : class, new()
        {
            _context.RemoveRange(entityList);
        }

        public List<T> GetEntityList<T>(List<Expression<Func<T, bool>>> whereExpressions = null, Func<T, object> orderByExpression = null, int skip = 0, int take = 0, bool asNoTracking = false, params Expression<Func<T, object>>[] includeProperties) where T : class, new()
        {
            var query = GetAllQueryable(whereExpressions, null, asNoTracking, includeProperties).Skip(skip).Take(take);

            if (orderByExpression != null)
                return query.OrderBy(orderByExpression).ToList();
            else
                return query.ToList();
        }

        public virtual void Commit()
        {
            _context.SaveChanges();
        }
        #endregion

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Attach<T>(T entity) where T : class, new()
        {
            _context.Attach(entity);
        }

        public virtual EntityBaseRepository GetInstance()
        {
            return this;
        }

        private IQueryable<T> GetAllQueryable<T>(List<Expression<Func<T, bool>>> whereExpressions, Expression<Func<T, T>> select = null, bool asNoTracking = false, params Expression<Func<T, object>>[] includeProperties) where T : class, new()
        {
            IQueryable<T> query = _context.Set<T>();

            if (select != null)
            {
                if (whereExpressions != null)
                {
                    foreach (var item in whereExpressions)
                    {
                        query = query.Where(item);
                    }
                }

                query = query.Select(select);
                return query.AsNoTracking();
            }
            else
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }

                if (whereExpressions != null)
                {
                    foreach (var item in whereExpressions)
                    {
                        query = query.Where(item);
                    }
                }

                return (asNoTracking ? query.AsNoTracking() : query);
            }
        }

        public IQueryable<T> GetAllWhereQueryableIncludes<T>(List<Expression<Func<T, bool>>> whereExpressions, bool asNoTracking = false, List<string> includeProperties = null) where T : class, new()
        {
            IQueryable<T> query = _context.Set<T>();

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            if (whereExpressions != null)
            {
                foreach (var item in whereExpressions)
                {
                    query = query.Where(item);
                }
            }

            return (asNoTracking ? query.AsNoTracking() : query);

        }
    }
    public class DndRepository : EntityBaseRepository
    {
        public DndRepository(DndCharacterManagerContext context) : base(context) { }
    }

    
}
