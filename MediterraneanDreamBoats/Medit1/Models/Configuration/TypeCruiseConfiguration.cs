using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medit1.Models.Configuration
{
    public class TypeCruiseConfiguration:IEntityTypeConfiguration<TypeCruise>
    {
        public void Configure(EntityTypeBuilder<TypeCruise> builder)
        {
            builder.ToTable("TypeCruise");
            builder.HasData(
                new TypeCruise
                {
                    TypeCruiseId = 1,
                    AdultOnly = true,
                    Description = "Soirées mémorables aux sons de la salsa.",
                    Name = "Rencontre"
                },
                new TypeCruise
                {
                    TypeCruiseId = 2,
                    AdultOnly = false,
                    Description = "Court trajet et escales longues afin de découvrir la culture locale.",
                    Name = "Découverte"
                },
                new TypeCruise
                {
                    TypeCruiseId = 3,
                    AdultOnly = false,
                    Description = "Voyage paisible avec escales pour ravitailler",
                    Name = "Farniente"
                }
                );
        }
    }
}
