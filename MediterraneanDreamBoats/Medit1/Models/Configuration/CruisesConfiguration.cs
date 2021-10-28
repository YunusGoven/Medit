using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medit1.Models.Configuration
{
    public class CruisesConfiguration : IEntityTypeConfiguration<Cruise>
    {
        public void Configure(EntityTypeBuilder<Cruise> builder)
        {
            builder.ToTable("Cruise");
            builder.HasData(
                new 
                {
                    CruiseId=100,
                    Name = "La croisière du futur",
                    Description="Une tournée aux bords de la mer méditéerannéene avec votre famille",
                    DateDepart= new DateTime(2030,12,15),
                    DateArrivee= new DateTime(2030,12,30),
                    BoatId = 2,
                    TypeCruiseId = 1,
                    PortDepartPortId = 1,
                    ArrivalPortPortId = 2,
                    DistanceTotal=0.0f,
                    AdultOnly =true
                },
                new
                {
                    CruiseId = 101,
                    Name = "Medit'On Flux v2",
                    Description = "Vous avez kiffé la v1 nous vous propossons la v2 biensur avec les meme conditions que la v1",
                    DateDepart = new DateTime(2023, 12, 15),
                    DateArrivee = new DateTime(2023, 12, 30),
                    BoatId = 1,
                    TypeCruiseId = 2,
                    PortDepartPortId = 6,
                    ArrivalPortPortId = 7,
                    AdultOnly=false,
                    DistanceTotal= 0.0f
                },
                new
                {
                    CruiseId = 102,
                    Name = "Hotel Boats Dream",
                    Description = "Une croisière de luxe avec des lits afin que vous poussiez dormir tranquillement pendant vous voyager",
                    DateDepart = new DateTime(2030, 12, 15),
                    DateArrivee = new DateTime(2030, 12, 30),
                    BoatId = 3,
                    TypeCruiseId = 3,
                    PortDepartPortId = 10,
                    ArrivalPortPortId = 10,
                    DistanceTotal= 0.0f,
                    AdultOnly =false
                }
            );
        }
    }
}
