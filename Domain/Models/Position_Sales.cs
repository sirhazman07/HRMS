using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Position_Sales : Position
    {

        public override EmployeeInPosition RegisterEmployee(Employee e, bool active)
        {
            var eip = new EmployeeInSalePosition { Employee = e, Position = this, Active = active };
            this.EmployeeInPostions.Add(eip);
            return eip;
        }
    }
}
