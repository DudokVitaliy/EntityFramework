using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Entities
{
    public class Worker
    {
        public Worker()
        {
            Projects = new List<Project>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public int Salary { get; set; }

        //
        public int DepartmentID { get; set; }
        public int CountryId { get; set; }

        public Department Department { get; set; }
        public Country Country { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}
