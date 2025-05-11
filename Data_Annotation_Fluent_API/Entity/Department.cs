using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Annotation_Fluent_API.Entities
{
    public class Department
    {
        public Department()
        {
            Workers = new List<Worker>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        //
        public ICollection<Worker> Workers { get; set; }
    }
}
