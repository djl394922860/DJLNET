using DJLNET.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.EntityFramework.Mappings
{
    public class UserMapping : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            this.HasKey(x => x.ID);
            this.Property(x => x.Name).IsRequired().HasMaxLength(32);
            this.Property(x => x.Password).IsRequired().HasMaxLength(32);
            this.Property(x => x.IsActive).IsRequired();
            this.Property(x => x.IsDeleted).IsRequired();
            this.Property(x => x.CreatedBy).IsRequired().HasMaxLength(32);
            this.Property(x => x.UpdatedBy).IsRequired().HasMaxLength(32);
            this.HasMany(x => x.Roles).WithMany(x => x.Users).Map(config =>
            {
                config.ToTable("UserRole");
                config.MapLeftKey("UserID");
                config.MapRightKey("RoleID");
            });
        }
    }
}
