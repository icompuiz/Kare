using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE343.Kare.WebService.Models
{
    public class Exercise
    {
        private List<Instruction> _instructions;
        private Quiz _quiz;

        public List<Instruction> Instructions
        {
            get { return _instructions; }
            set { _instructions = value; }
        }

        public Quiz Quiz
        {
            get { return _quiz; }
            set { _quiz = value; }
        }
    }
}