using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Medit1.Models;

namespace Medit1.Validation
{
    public class ParticipationValidationAttribute : ValidationAttribute
    {
        private readonly string _cruiseId;

        public ParticipationValidationAttribute(string cruiseId)
        {
            _cruiseId = cruiseId;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var participants = (List<Participant>)value;
            if(participants.Count<1)return new ValidationResult("Le nombre de participant doit etre supérieur ou égal à 1");
            var propertyInfo = validationContext.ObjectType.GetProperty(_cruiseId);
            var cruiseId = (int?)propertyInfo?.GetValue(validationContext.ObjectInstance, null);
            var context = (Medit1DbContext)validationContext.GetService(typeof(Medit1DbContext));
            var cruise = context?.Cruises.First(c => c.CruiseId == cruiseId);
            if (cruise == null) return new ValidationResult("La croissiere n'existe pas");
            if (cruise.AdultOnly)
            {
                var today = DateTime.Today;
                foreach (var participant in participants)
                {
                    TimeSpan ts = today - participant.BirthDate;
                    if (ts.Days < 18*365)
                    {
                        return new ValidationResult("Croissiere reservé aux adultes");
                    }
                }
            }
            return ValidationResult.Success;

        }
    }
}
