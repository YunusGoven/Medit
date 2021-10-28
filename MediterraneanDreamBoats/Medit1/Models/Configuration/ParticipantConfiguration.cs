using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medit1.Models.Configuration
{
    public class ParticipantConfiguration : IEntityTypeConfiguration<Participant>
    {
        public void Configure(EntityTypeBuilder<Participant> builder)
        {
            builder.ToTable("Participant");
            builder.HasData(
                new
                {
                    BirthDate = new DateTime(2000, 1, 03), 
                    FirstName = "Yunus", 
                    Name = "GVN", 
                    ParticipantId = 755
                },
                new
                {
                    BirthDate = new DateTime(1999, 11, 03),
                    FirstName = "Chritian",
                    Name = "PasDior",
                    ParticipantId = 756
                },
                new
                {
                    BirthDate = new DateTime(2001, 1, 15),
                    FirstName = "Bremit",
                    Name = "Bremit",
                    ParticipantId = 757
                }
            );
        }
    }
}
