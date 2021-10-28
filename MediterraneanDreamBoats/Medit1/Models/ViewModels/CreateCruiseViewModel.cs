using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Medit1.Validation;
using Microsoft.AspNetCore.Http;

namespace Medit1.Models.ViewModels
{
    public class CreateCruiseViewModel
    {
        public ICollection<TypeCruise>TypeCruises { get; set; }
        public ICollection<Port> Ports { get; set; }
        public ICollection<Boat> Boats { get; set; }
        public ICollection<Commodite> Commodites { get; set; }
        public Cruise Cruise { get; set; }
        [Required(ErrorMessage = "Un bateau est nécessaire pour la croissière")]
        [BoatVerifaction("Cruise")]
        public int BoatId{ get; set; }
        [Required(ErrorMessage = "Le type de la croissiere est obligatoire")]
        public int TypeCruiseId{ get; set; }
        [Required(ErrorMessage = "Le port de départ est nécessaire")]
        public int DeparturePortId{ get; set; }
        [Required(ErrorMessage = "Un port de destination est obligatoire")]
        public int ArrivalPortId{ get; set; }
        public ICollection<int> TransitPortId{ get; set; }
        public ICollection<int> CommoditesIds{ get; set; }
        public ICollection<IFormFile> File { get; set; }
    }
}
