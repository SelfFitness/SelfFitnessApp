using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp.Models
{
    public class TrainHistory
    {
        public int Id { get; set; }

        public int PlanId { get; set; }

        public DateTime Date { get; set; }
    }
}
