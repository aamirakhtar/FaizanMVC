using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Company.ValidationMetaData
{
    public class UniqueCheckValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            CompanyEntities ce = new CompanyEntities();

            if (value != null && ce.Departments.ToList().Exists(d => d.Name == value.ToString()))
                return false;
            else
                return true;
        }
    }
}