using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.Entities
{
    public class CompanyEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Salary { get; set; }

        public IEnumerable<EmployeeEntity> Employees { get; set; }
    }
}
