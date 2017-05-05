using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.EntityFramework
{
    public class DJLNETDBContext : DbContext, IDbContext
    {
        private static readonly string _conn = "Default";

        static DJLNETDBContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DJLNETDBContext>());
        }

        public DJLNETDBContext() : base($"name={_conn}")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // 移除表名复数
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
