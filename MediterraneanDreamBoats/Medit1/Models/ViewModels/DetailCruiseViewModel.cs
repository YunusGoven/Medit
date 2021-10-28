using System.ComponentModel;

namespace Medit1.Models.ViewModels
{
    public class DetailCruiseViewModel
    {
        public Cruise Cruise { get; set; }
        [DisplayName("Place Restante")]
        public int PlaceDisponible { get; set; }
        public int PlaceTotal { get; set; }
    }
}
