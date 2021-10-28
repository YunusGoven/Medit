using System.Collections.Generic;

namespace Medit1.Models.ViewModels
{
    public class AdministrationReservationViewModel
    {
        public ICollection<ParticipantReservation> ParticipantReservations { get; set; }
        public Cruise Cruise { get; set; }
    }
}
