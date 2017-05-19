using DJLNET.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.EntityFramework.Mappings
{
    public class NavigateMapping : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Navigate>
    {
        public NavigateMapping()
        {
            this.HasKey(x => x.ID);
            this.Property(x => x.ActionName).HasMaxLength(32).IsOptional();
            this.Property(x => x.ControllerName).HasMaxLength(32).IsOptional();
            this.Property(x => x.Name).HasMaxLength(32).IsRequired();
            this.Property(x => x.IconClassCode).HasMaxLength(32).IsRequired();
            this.Property(x => x.Active).IsRequired();
            this.Property(x => x.SortOrder).IsRequired();
            this.HasOptional(x => x.Parent).WithMany(x => x.Children).HasForeignKey(x => x.ParentID);
        }
    }
}
