using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medit1.Models
{
    public class Port
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PortId { get; set; }
        //-----------------------------------------------------------------------------
        [Required(ErrorMessage = "Le nom du port est obligatoire")]
        [DisplayName("Nom")]
        [MinLength(3,ErrorMessage = "Le nom doit contenir 3 caractères ou plus")]
        public string Name { get; set; }
        //-----------------------------------------------------------------------------
        [Required(ErrorMessage = "La latitude est obligatoire")]
        public float Latitude { get; set; }
        //-----------------------------------------------------------------------------
        [Required(ErrorMessage = "La longitude est obligatoire")]
        public float Longitude { get; set; }
        public ICollection<CruisePort> TransitPorts { get; set; }
    }
}
