using DJLNET.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.EntityFramework.Mappings
{
    public class PlatformMapping : EntityTypeConfiguration<Platform>
    {
        public PlatformMapping()
        {
            this.ToTable(nameof(Platform));
            this.HasKey(x => x.ID);
            this.Property(x => x.ChineseName).IsRequired().HasMaxLength(32);
            this.Property(x => x.EnglishName).IsRequired().HasMaxLength(32);
            this.Property(x => x.DomainUrl).IsRequired().HasMaxLength(32);
        }
    }
}
