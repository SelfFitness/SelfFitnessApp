using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp.Models
{
    public class Plan
    {
        public int? Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Difficulty { get; set; }

        public int MaxDifficulty { get; set; } 

        public IList<ExercisePart> ExerciseParts { get; set; }
    }
}
