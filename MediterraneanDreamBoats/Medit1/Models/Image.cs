using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medit1.Models
{
    public class Image
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ImageId { get; set; }
        [Required]
        public String Path { get; set; }

        public Cruise Cruise { get; set; }
    }
}
