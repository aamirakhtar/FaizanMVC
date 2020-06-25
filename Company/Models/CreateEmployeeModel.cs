using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Company.Models
{
    public class EmployeeModel
    {
        public Employee employee { get; set; }
        public List<Department> departments { get; set; }
    }
}