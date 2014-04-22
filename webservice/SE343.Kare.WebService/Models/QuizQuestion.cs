using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SE343.Kare.WebService.Models
{
    public class QuizQuestion
    {
        public int QuizQuestionId { get; set; }
        public int QuizId { get; set; }

        public virtual Quiz Quiz { get; set; }
        public String Text { get; set; }
    }
}
