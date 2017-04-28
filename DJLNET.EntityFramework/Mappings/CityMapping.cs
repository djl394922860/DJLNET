using DJLNET.Model.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DJLNET.EntityFramework.Mappings
{
    public class CityMapping : EntityTypeConfiguration<City>
    {
        public CityMapping()
        {
            this.ToTable(nameof(City));
            this.HasKey(x => x.ID);

            this.Property(x => x.JumpUrl).IsRequired().HasMaxLength(32);
            this.Property(x => x.Name).IsRequired().HasMaxLength(32);

        }
    }
}
