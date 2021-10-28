using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Medit1.Models
{
    public class Participant
    {
        public int ParticipantId { get; set; }
        [DisplayName("Nom")]
        [Required(ErrorMessage = "Le nom est obligatoire")]
        public String Name { get; set; }
        //-----------------------------------------------------------------------------
        [DisplayName("Prénom")]
        [Required(ErrorMessage = "Le prenom est obligatoire")]
        public String FirstName { get; set; }
        //-----------------------------------------------------------------------------
        [DisplayName("Date de naissance")]
        [Required(ErrorMessage = "La date de naissance est obligatoire")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        //-----------------------------------------------------------------------------
        public List<ParticipantReservation> Reservations { get; set; }
    }
}
