using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp.Models
{
    public class ExercisePart
    {
        public int Id { get; set; }

        public Exercise Exercise { get; set; }

        public TimeSpan? Duration { get; set; }

        public int? Count { get; set; }
    }
}
