using DJLNET.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.EntityFramework.Mappings
{
    public class EntityPermissionMapping : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<EntityPermission>
    {
        public EntityPermissionMapping()
        {
            this.HasKey(x => new { x.EntityID, x.EntityName, x.RoleID });
            this.Property(x => x.EntityName).HasMaxLength(32);
            this.Property(x => x.IsDeleted).IsRequired();
            this.Property(x => x.CreatedBy).IsRequired().HasMaxLength(32);
            this.Property(x => x.UpdatedBy).IsRequired().HasMaxLength(32);
            this.HasRequired(x => x.Role).WithMany().HasForeignKey(x => x.RoleID).WillCascadeOnDelete(true);
        }
    }
}
