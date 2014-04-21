using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SE343.Kare.WebService.Models
{
    public class Quiz
    {
        private List<Question> _questions;
        public List<Question> Questions
        {
            get { return _questions; }
            set { _questions = value; }
        }
    }
}
