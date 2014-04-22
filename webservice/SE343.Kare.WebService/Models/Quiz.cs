using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SE343.Kare.WebService.Models
{
    public class Quiz
    {
        
        public virtual List<QuizQuestion> Questions { get; set; }

        public int QuizId { get; set; }

        public String Name { get; set; }
    }
}
