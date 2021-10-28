using System.ComponentModel.DataAnnotations;
using System.Linq;
using Medit1.Models;
using Microsoft.EntityFrameworkCore;

namespace Medit1.Validation
{
    public class BoatVerifactionAttribute : ValidationAttribute
    {
        private readonly string _cruise;
        public BoatVerifactionAttribute(string cruise)
        {
            _cruise = cruise;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propertyInfo = validationContext.ObjectType.GetProperty(_cruise);
            var cruise = (Cruise)propertyInfo?.GetValue(validationContext.ObjectInstance, null);

            var boatId = (int) value;
            var context =(Medit1DbContext) validationContext.GetService(typeof(Medit1DbContext));

            var cruises = context?.Cruises
                .Include(c=>c.Boat)
                .Where(c=>c.Boat.BoatId == boatId).ToList();
            var crDateDepart = cruise?.DateDepart;
            var crDateArrive = cruise?.DateArrivee;
            if (cruises == null) return ValidationResult.Success;
            foreach (var cruisefor in cruises)
            {
                var cDateDepart = cruisefor.DateDepart;
                var cDateArrive = cruisefor.DateArrivee;
                if ((crDateDepart >= cDateDepart && crDateDepart <= cDateArrive) ||
                    (crDateDepart <= cDateDepart && crDateArrive >= cDateArrive))
                {
                    return new ValidationResult("Le bateau selectionné est déjà pris pour les dates choisis");
                }
            }

            return ValidationResult.Success;


        }
    }
}
