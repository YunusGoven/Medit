using System.Collections.Generic;

namespace Medit1.Models.ViewModels
{
    public class IndexCruiseViewModel
    {
        public ICollection<Cruise> Cruises { get; set; }
        public ICollection<TypeCruise> TypeCruises { get; set; }
    }
}
