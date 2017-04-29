using DJLNET.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.EntityFramework.Mappings
{
    public class PermissionMapping : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Permission>
    {
        public PermissionMapping()
        {
            this.HasKey(x => x.ID);

            this.Property(x => x.Name).IsRequired().HasMaxLength(32);
            this.Property(x => x.Category).IsRequired().HasMaxLength(32);
            this.Property(x => x.Description).IsRequired().HasMaxLength(32);

            this.Property(x => x.IsDeleted).IsRequired();
            this.Property(x => x.CreatedBy).IsRequired().HasMaxLength(32);
            this.Property(x => x.UpdatedBy).IsRequired().HasMaxLength(32);

        }
    }
}
