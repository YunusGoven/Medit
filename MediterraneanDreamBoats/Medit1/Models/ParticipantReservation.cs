

namespace Medit1.Models
{
    public class ParticipantReservation
    {
        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
    }
}
