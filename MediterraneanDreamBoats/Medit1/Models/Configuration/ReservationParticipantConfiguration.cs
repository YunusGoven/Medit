using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medit1.Models.Configuration
{
    public class ReservationParticipantConfiguration : IEntityTypeConfiguration<ParticipantReservation>
    {
        public void Configure(EntityTypeBuilder<ParticipantReservation> builder)
        {
            builder.ToTable("ParticipantReservation");
            builder.HasData(
                new
                {
                    ReservationId = 215,
                    ParticipantId = 755

                },
                new
                {
                    ReservationId = 215,
                    ParticipantId = 756

                },
                new
                {
                    ReservationId = 216,
                    ParticipantId = 757

                }
            );
        }
    }
}
