using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medit1.Models
{
    public class TypeCruise
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int TypeCruiseId { get; set; }
        [Required(ErrorMessage = "Le nom est obligatoire")]
        [DisplayName("Nom")]
        [MinLength(4,ErrorMessage = "Le nom doit comporter 4 caractères ou plus")]
        public string Name { get; set; }
        //-----------------------------------------------------------------------------
        [Required(ErrorMessage = "La description est nécessaire")]
        [MinLength(20)]
        public string Description { get; set; }
        //-----------------------------------------------------------------------------
        public bool AdultOnly { get; set; }
    }
}
