using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Medit1.Models
{
    public class Commodite
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CommoditeId { get; set; }
        [Required(ErrorMessage = "Le libellé est requis")]
        [MinLength(5,ErrorMessage = "Libellé ne peut etre vide et doit contenir min. 5 caractères")]
        [DisplayName("Libellé")]
        public string Name { get; set; }
    }
}
