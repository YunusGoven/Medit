using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medit1.Models
{
    public class Reservation
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservationId { get; set; }
        [DisplayName("Liste des participants")]
        public List<ParticipantReservation> Participants { get; set; }

        public Cruise Cruise { get; set; }
        public string UserId { get; set; }

    }
}
