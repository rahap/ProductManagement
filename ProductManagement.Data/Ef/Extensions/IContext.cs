using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductManagement.Data.Ef.Extensions
{
  public   interface IContext
    {
        public IQueryable<T> All<T>() where T : Entity;
        public IQueryable<T> ByPage<T>(int index, int pageSize) where T : Entity;
        public T Get<T>(int id) where T : Entity;

        public void AddCustom<T>(T entity) where T : Entity<T>;
        public void UpdateCustom<T>(T entity) where T : Entity<T>;
        public void DeleteCustom<T>(T entity) where T : Entity<T>;

        public int Count<T>() where T : Entity;
        public IQueryable<T> GetDataFromRawSql<T>(string query) where T : class;
    }
}
