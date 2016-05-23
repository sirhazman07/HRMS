using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Employee : Person
    {
        public Employee()
        {
            this.EmployeeInPostions = new List<EmployeeInPosition>();
        }


        public virtual ICollection<EmployeeInPosition> EmployeeInPostions { get; set; }
    }
}
