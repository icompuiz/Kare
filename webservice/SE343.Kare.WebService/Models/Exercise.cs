using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE343.Kare.WebService.Models
{
    public class Exercise
    {
        
        public int ExerciseId { get; set; }

        public int QuizId { get; set; }

        public String Name { get; set; }

        public virtual Quiz Quiz { get; set; }

        public virtual List<Instruction> Instructions { get; set; }

        
    }
}