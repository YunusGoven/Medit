using System.Collections.Generic;
using Medit1.Validation;

namespace Medit1.Models.ViewModels
{
    public class ReservationViewModel
    {
        public Cruise Cruise { get; set; }
        public int CruiseId { get; set; }
        [ParticipationValidation("CruiseId")]
        public List<Participant> Participants { get; set; }
        public int PlaceRestante { get; set; }
    }
}
