using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Medit1.Validation;

namespace Medit1.Models
{
    public class Cruise
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CruiseId { get; set; }
        //----------------------------------------------------------------------------
        [Required(ErrorMessage = "Le nom de la croissière est recquis")]
        [DisplayName("Nom")]
        [MinLength(5,ErrorMessage = "La longeur du nom ne peut pas être inférieur à 5")]
        public string Name { get; set; }
        //-----------------------------------------------------------------------------
        [MinLength(25,ErrorMessage = "La description doit contenir 25 caractères minimum")]
        [Required(ErrorMessage = "La description est obligatoire")]
        public string Description { get; set; }
        //-----------------------------------------------------------------------------

        [DisplayName("Départ")]
        [Required(ErrorMessage = "La date de départ est obligatoire")]
        [CruiseDateVerification("CreationDate",ErrorMessage = "La date de depart ne peut pas etre avant aujourd'hui")]
        [DataType(DataType.Date)]
        public DateTime DateDepart { get; set; }
        //-----------------------------------------------------------------------------
        [DisplayName("Arrivé")]
        [Required(ErrorMessage = "La date d'arrivée est obligatoire")]
        [CruiseDateVerification("DateDepart", ErrorMessage = "La date d'arrivé ne peut etre avant celle de départ")]
        [DataType(DataType.Date)]
        public DateTime DateArrivee { get; set; }
        //-----------------------------------------------------------------------------

        [DisplayName("Distance total")]
        public float DistanceTotal { get; set; }
        
        public bool AdultOnly { get; set; }

        //------------------------------
        [DisplayName("Bateau")]
        public Boat Boat { get; set; }
        //------------------------------
        [DisplayName("Type Croissière")]
        public TypeCruise TypeCruise { get; set; }
        //------------------------------
        public  Port PortDepart { get; set; }
        //------------------------------
        public  Port ArrivalPort { get; set; }
        //------------------------------
        public ICollection<Image>Images { get; set; }
        //------------------------------
        [DisplayName("Ports de transits")]
        public ICollection<CruisePort> TransitPorts { get; set; }
        //------------------------------
        public ICollection<CruiseCommodite> Commodites { get; set; }
        //------------------------------
        public DateTime CreationDate=> DateTime.Now;
    }
}
