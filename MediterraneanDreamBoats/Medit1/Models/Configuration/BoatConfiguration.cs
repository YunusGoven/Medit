using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medit1.Models.Configuration
{
    public class BoatConfiguration: IEntityTypeConfiguration<Boat>
    {
        public void Configure(EntityTypeBuilder<Boat> builder)
        {
            builder.ToTable("Boat");
            builder.HasData(
                new Boat
                {
                    BoatId = 1,
                    Description = "https://www.lindependant.fr/2018/06/25/port-vendres-le-plus-grand-voilier-de-luxe-au-monde-ancre-dans-les-eaux-catalanes,4564616.php",
                    Name = "La Maltese Falcon",
                    NbConvives = 10,
                    Type = "Monocoque"
                },
                new Boat
                {
                    BoatId = 2,
                    Description = "https://journalduluxe.fr/catamaran-hemisphere/",
                    Name = "Hémisphère",
                    NbConvives = 11,
                    Type = "Catamaran"
                },
                new Boat
                {
                    BoatId = 3,
                    Description = "https://www.bateaux.com/article/20117/Le-Neel-65-nouveau-trimaran-de-croisiere-rapide-du-chantier-Neel-Trimaran",
                    Name = "Neel 65",
                    NbConvives = 10,
                    Type = "Trimaran"
                }
            );
        }
    }
}
