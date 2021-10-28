using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medit1.Models.Configuration
{
    public class CommoditeConfiguration : IEntityTypeConfiguration<Commodite>
    {
        public void Configure(EntityTypeBuilder<Commodite> builder)
        {
            builder.ToTable("Commodite");
            builder.HasData(
                new Commodite()
                {
                    CommoditeId = 1,
                    Name = "Internet"
                }, 
                new Commodite()
                {
                    CommoditeId = 2,
                    Name = "Réseaux EU"
                },
                new Commodite()
                {
                    CommoditeId = 3,
                    Name = "Réseaux AN"
                },
                new Commodite()
                {
                    CommoditeId = 4,
                    Name = "Réseaux USA"
                }
            );
        }
    }
}
