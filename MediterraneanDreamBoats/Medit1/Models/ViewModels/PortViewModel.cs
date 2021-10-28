
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Medit1.Validation;

namespace Medit1.Models.ViewModels
{
    public class PortViewModel
    {
        public int PortId { get; set; }
        [Required(ErrorMessage = "Le nom du port est obligatoire")]
        [DisplayName("Nom")]
        [MinLength(3, ErrorMessage = "Le nom doit contenir 3 caractères ou plus")]
        public string Name { get; set; }
        //-----------------------------------------------------------------------------
        [Required(ErrorMessage = "La latitude est obligatoire")]
        [DisplayName("Latitude (séparer avec ',' pour les nombres à virgules)")]
        [IsFloating(ErrorMessage = "La latitude ne peut pas contenir des lettres")]
        public string Latitude { get; set; }
        //-----------------------------------------------------------------------------
        [DisplayName("Longitude (séparer avec ',' pour les nombres à virgules)")]
        [Required(ErrorMessage = "La longitude est obligatoire")]
        [IsFloating(ErrorMessage = "La longitute ne peut pas contenir des lettres")]
        public string Longitude { get; set; }
    }
}
