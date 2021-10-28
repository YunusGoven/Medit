using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medit1.Models
{
    public class Boat
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int BoatId { get; set; }
        [DisplayName("Nom du bateau")]
        [Required(ErrorMessage = "Le nom du bateau est requis")]
        [MinLength(4, ErrorMessage = "Le nom doit comporter au minimum 4 caractères")]
        public string Name { get; set; }
        [Required(ErrorMessage = "La description est obligatoire")]
        [MinLength(15, ErrorMessage = "La description doit contenir au minimum 15 caractères")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Le type de bateau est requis")]
        [MinLength(4,ErrorMessage = "Le type doit comporter minimum 4 caractères")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Le nombre de convives(place disponible) est obligatoire")]
        [Range(minimum:2,maximum:500,ErrorMessage = "Le nombre doit etre compris entre 2 et 500")]
        public int NbConvives { get; set; }
    }
}
