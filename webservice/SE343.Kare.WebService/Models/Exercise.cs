using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE343.Kare.WebService.Models
{
    public class Exercise
    {
        private List<Instruction> _instructions
        public List<Instruction> Instructions
        {
            get { return _instructions; }
            set { _instructions = value; }
        }

        private Quiz _quiz;
        public Quiz Quiz
        {
            get { return _quiz; }
            set { _quiz = value; }
        }

        private String _name;
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}