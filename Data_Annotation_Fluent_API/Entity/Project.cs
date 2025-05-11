using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Annotation_Fluent_API.Entities
{
    public class Project
    {
        public Project()
        {
            Workers = new List<Worker>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime LaunchDate { get; set; }

        //
        public ICollection<Worker> Workers { get; set; }
    }
}
