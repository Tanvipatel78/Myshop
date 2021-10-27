using Myshop.core.Contracts;
using Myshop.core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyshopDataccess.SQL
{
    public class SQLRepository<T> : IRepository<T> where T : BaseEntity
    {
        internal DataContext context;
        internal DbSet<T> dbset;

        public SQLRepository(DataContext context)
        {
            this.context = context;
            this.dbset = context.Set<T>();
        }
        public IQueryable<T> Collection()
        {
            return dbset;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(string Id)
        {
            throw new NotImplementedException();
        }

        public T Find(string Id)
        {
            return dbset.Find(Id);
        }

        public void Insert(T t)
        {
            dbset.Add(t);
        }

        public void Update(T t)
        {
            throw new NotImplementedException();
        }
    }
}
