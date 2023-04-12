using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lab2
{
    public class IndexValidationAttribute:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value is int ii)
            {
                if (ii < 5)
                    return true;
                else
                    ErrorMessage = "#IndexValidationAttribute: Не может быть больше 5 объектов";
            }
            return false;
        }

    }
}
