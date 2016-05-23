using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class State
    {
        public State()
        {
            this.Suburbs = new List<Suburb>();
            this.EmployeeInPostions = new List<EmployeeInPosition>();
        }

        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Suburb> Suburbs { get; set; }
        public virtual ICollection<EmployeeInPosition> EmployeeInPostions { get; set; }
    }
}
