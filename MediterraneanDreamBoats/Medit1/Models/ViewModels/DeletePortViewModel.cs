

using System.Collections.Generic;

namespace Medit1.Models.ViewModels
{
    public class DeletePortViewModel:Port
    {
        public ICollection<string> CruisesName { get; set; }
    }
}
