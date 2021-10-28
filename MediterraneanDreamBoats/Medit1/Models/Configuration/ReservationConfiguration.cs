using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medit1.Models.Configuration
{
    public class ReservationConfiguration:IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservation");
            builder.HasData(
                new
                {
                    ReservationId=215,
                    CruiseId = 100,
                    UserId = "1",
                    
                },
                new
                {
                    ReservationId = 216,
                    CruiseId = 101,
                    UserId = "1",

                }
                );
        }
    }
}
