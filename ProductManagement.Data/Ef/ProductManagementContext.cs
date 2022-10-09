using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Data.Ef.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductManagement.Data.Ef
{
    public class ProductManagementContext : DbContext, IContext
    {
        public ProductManagementContext(string connectionString) : base(GetOptions(connectionString))
        {
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }


        public ProductManagementContext(DbContextOptions<ProductManagementContext> options) : base(options)
        {

        }
       // public DbSet<DeliveryPoint> DeliveryPoints() => GetDbSet<DeliveryPoint>();
  
        public DbSet<T> GetDbSet<T>() where T : class
        {
            return this.Set<T>();
        }
        public IQueryable<T> GetDataFromRawSql<T>(string query) where T : class
        {
            return this.Set<T>().FromSqlRaw(query).AsQueryable();
        }

        public IQueryable<T> All<T>() where T : Entity
        {
            return GetDbSet<T>().AsQueryable();
        }

        public IQueryable<T> ByPage<T>(int index, int pageSize) where T : Entity
        {
            return GetDbSet<T>().AsQueryable().Skip(index).Take(pageSize);
        }

        public int Count<T>() where T : Entity
        {
            return GetDbSet<T>().CountAsync().Result; // bakılacak
        }

        public void DeleteCustom<T>(T entity) where T : Entity<T>
        {
            //GetDbSet<T>().Remove(entity); // bakılacak
            entity.ModifiedDate = System.DateTime.Now;
            entity.IsDeleted = true;
            //    this.Entry<T>(entity).State = EntityState.Modified;
            GetDbSet<T>().Update(entity);
        }

        public T Get<T>(int id) where T : Entity
        {
            return GetDbSet<T>().Find(id);
        }


        
        //https://stackoverflow.com/questions/51808912/the-child-dependent-side-could-not-be-determined-for-the-one-to-one-relationship/51809814
        //https://stackoverflow.com/questions/53681739/how-to-define-foreign-key-relationship-in-ef-core-2-1
        //https://www.jerriepelser.com/blog/store-dictionary-as-json-using-ef-core-21/
        //https://stackoverflow.com/questions/42355481/auto-create-database-in-entity-framework-core
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //     modelBuilder.Entity<DeliveryPoint>();
          


        
         
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public void AddCustom<T>(T entity) where T : Entity<T>
        {
            //entity.ModifiedDate = System.DateTime.Now.ToUniversalTime();
            entity.CreatedDate = System.DateTime.Now.ToUniversalTime();
            entity.IsValid();
            GetDbSet<T>().Add(entity);
        }



        public void UpdateCustom<T>(T entity) where T : Entity<T>
        {
            entity.ModifiedDate = System.DateTime.Now.ToUniversalTime();
            entity.IsValid();
            GetDbSet<T>().Update(entity);
        }

        IQueryable<T> IContext.All<T>()
        {
            throw new NotImplementedException();
        }

        IQueryable<T> IContext.ByPage<T>(int index, int pageSize)
        {
            throw new NotImplementedException();
        }

        IQueryable<T> IContext.GetDataFromRawSql<T>(string query)
        {
            throw new NotImplementedException();
        }

        public SqlTransaction _transaction;
    }
}
