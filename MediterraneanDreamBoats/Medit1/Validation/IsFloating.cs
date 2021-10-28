using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Medit1.Validation
{
    public class IsFloating : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            try
            {
                var val = float.Parse((string)value);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
