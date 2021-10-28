using System.Collections.Generic;

namespace Medit1.Models.ViewModels
{
    public class AdministrationViewModel
    {
        public ICollection<Port> Ports { get; set; }
        public ICollection<Boat> Boats { get; set; }
        public ICollection<Cruise> Cruises { get; set; }
    }
}
