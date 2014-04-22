using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SE343.Kare.WebService.Models
{
    public class Instruction
    {
        public int InstructionId { get; set; }

        public String Text { get; set; }

        public int ExerciseId { get; set; }

        public virtual Exercise Exercise {get; set;}

        
    }
}
