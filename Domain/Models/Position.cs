using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Position
    {
        public Position()
        {
            this.EmployeeInPostions = new List<EmployeeInPosition>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<EmployeeInPosition> EmployeeInPostions { get; set; }

        public virtual EmployeeInPosition RegisterEmployee(Employee e, bool active)
        {
            return null;
        }
     
    }
}