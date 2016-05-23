using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Position_Development : Position
    {


        public override EmployeeInPosition RegisterEmployee(Employee e, bool active)
        {
            var eip = new EmployeeInDevelopmentPosition { Employee = e, Position = this, Active = active };
            this.EmployeeInPostions.Add(eip);
            return eip; 
        }
    }
}
