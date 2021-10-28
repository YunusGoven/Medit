using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Medit1.Models
{
    public class User:IdentityUser
    {
        public int UserId { get; set; }
        [DisplayName("Nom")]
        [Required(ErrorMessage = "Le nom de l'utilisateur est requis")]
        [MinLength(2)]
        public string Name { get; set; }
        //-----------------------------------------------------------------------------
        [DisplayName("Prénom")]
        [Required(ErrorMessage = "Le prénom est requis")]
        [MinLength(2)]
        public string FirstName { get; set; }
        //-----------------------------------------------------------------------------
        [DisplayName("Date de naissance")]
        [Required(ErrorMessage = "La date de naissance est requise")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

    }
}
