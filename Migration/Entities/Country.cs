using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationComp.Entities
{
    public class Country
    {
        public Country()
        {
            Workers = new List<Worker>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        // navigation prop
        public ICollection<Worker> Workers { get; set; }
    }
}
