using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using Interns.Core;
using AppContext = Interns.DataAccessLayer.Context.AppContext;

namespace Interns.DataAccessLayer.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppContext context;
        private readonly DbSet<T> table;

        public Repository()
        {
            context = new AppContext();
            table = context.Set<T>();
        }

        public Repository(AppContext context)
        {
            this.context = context;

            try
            {
                table = context.Set<T>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual IQueryable<T> GetAll()
        {
            try
            {
                return table;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public T GetById(object id)
        {
            try
            {
                return table.Find(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Insert(T item)
        {
            try
            {
                using (context)
                {
                    if (item != null)
                    {
                        table.Add(item);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new ArgumentNullException(nameof(item));
                    }
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                throw dbEx;
            }
        }

        public void Update(T item)
        {
            try
            {
                using (context)
                {
                    var entity = context.Set<T>().FirstOrDefault(t => t.Id == item.Id);
                    if (entity != null)
                    {
                        context.Entry(entity).CurrentValues.SetValues(item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                throw dbEx;
            }
        }


        public void Delete(T item)
        {
            try
            {
                using (context)
                {
                    var entity = context.Set<T>().FirstOrDefault(t => t.Id == item.Id);
                    if (entity != null)
                    {
                        context.Set<T>().Remove(entity);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new ArgumentNullException(nameof(item));
                    }
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                throw dbEx;
            }
        }
    }
}