using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp.Models
{
    public class PlanGroup
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<Plan> Plans { get; set; }
    }
}
