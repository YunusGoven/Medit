using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medit1.Models.Configuration
{
    public class PortConfiguration : IEntityTypeConfiguration<Port>
    {
        public void Configure(EntityTypeBuilder<Port> builder)
        {
            builder.ToTable("Port");
            builder.HasData(
                new Port
                {
                    PortId = 1,
                    Latitude = float.Parse("42,520793"),
                    Longitude = float.Parse("3,113759"),
                    Name = "Port-Vendres"
                },
                new Port
                {
                    PortId = 2,
                    Latitude = float.Parse("43,014457"),
                    Longitude = float.Parse("3,062417"),
                    Name = "Port-la-Nouvelle"
                },
                new Port
                {
                    PortId = 3,
                    Latitude = float.Parse("41,919164"),
                    Longitude = float.Parse("8,743635"),
                    Name = "Ajaccio"
                },
                new Port
                {
                    PortId = 4,
                    Latitude = float.Parse("41,385992"),
                    Longitude = float.Parse("9,151511"),
                    Name = "Bonifacio"
                },
                new Port
                {
                    PortId = 5,
                    Latitude = float.Parse("43,679644"),
                    Longitude = float.Parse("7,230929"),
                    Name = "Nice"
                },
                new Port
                {
                    PortId = 6,
                    Latitude = float.Parse("44,409962"),
                    Longitude = float.Parse("8,909803"),
                    Name = "Port de Gênes"
                },
                new Port
                {
                    PortId = 7,
                    Latitude = float.Parse("40,843009"),
                    Longitude = float.Parse("14,263150"),
                    Name = "Naples"
                },
                new Port
                {
                    PortId = 8,
                    Latitude = float.Parse("40,672827"),
                    Longitude = float.Parse("14,769201"),
                    Name = "Salerne"
                },
                new Port
                {
                    PortId = 9,
                    Latitude = float.Parse("38,130196"),
                    Longitude = float.Parse("13,363785"),
                    Name = "Palerme"
                },
                new Port
                {
                    PortId = 10,
                    Latitude = float.Parse("39,208360"),
                    Longitude = float.Parse("9,105776"),
                    Name = "Cagliari"
                },
                new Port
                {
                    PortId = 11,
                    Latitude = float.Parse("37,065410"),
                    Longitude = float.Parse("15,278924"),
                    Name = "Syracuse"
                },
                new Port
                {
                    PortId = 12,
                    Latitude = float.Parse("40,636024"),
                    Longitude = float.Parse("22,921649"),
                    Name = "Salonique"
                },
                new Port
                {
                    PortId = 13,
                    Latitude = float.Parse("37,938101"),
                    Longitude = float.Parse("23,648191"),
                    Name = "La Pirée"
                },
                new Port
                {
                    PortId = 14,
                    Latitude = float.Parse("36,834308"),
                    Longitude = float.Parse("30,606443"),
                    Name = "Antalya"
                }, new Port
                {
                    PortId = 15,
                    Latitude = float.Parse("34,666806"),
                    Longitude = float.Parse("33,041072"),
                    Name = "Limassol"
                }


                );
        }
    }
}
