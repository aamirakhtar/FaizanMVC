using Company.ValidationMetaData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Company
{
    public class DepartmentMetaData
    {
        //[Display(Name = "Email")]
        [MaxLength(20, ErrorMessage = "Name can be maximum of 10 characters.")]
        [MinLength(2, ErrorMessage = "Name can be maximum of 10 characters.")]
        [Required(ErrorMessage = "Please Enter Name.")]
        [UniqueCheckValidation(ErrorMessage = "Department Alredy Exists.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Location.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Please Enter Department Head.")]
        public string DepartmentHead { get; set; }
    }

    [MetadataType(typeof(DepartmentMetaData))]
    public partial class Department
    {

    }
}