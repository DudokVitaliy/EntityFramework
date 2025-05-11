using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Annotation_Fluent_API.Entities
{
    //[Table ("Workers Table")]
    public class Worker
    {
        public Worker()
        {
            Projects = new List<Project>();
        }
        //[Key] // - primary key
        //[Column ("ID")]
        public int Number { get; set; }
        //[MaxLength (100)]
        //[Required] // - not null
        //[Column ("First Name")]
        public string Name { get; set; }
        [Column ("Last Name"), MaxLength(50), Required]
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public int Salary { get; set; }
        public string FullName { get => Name + " " + Surname; }
        //[NotMapped] // - not visibly 
        //public string Email { get; set; }

        //
        public int DepartmentID { get; set; }
        public int CountryId { get; set; }

        public Department Department { get; set; }
        public Country Country { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}
