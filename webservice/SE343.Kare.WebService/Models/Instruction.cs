using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SE343.Kare.WebService.Models
{
    public class Instruction
    {
        private String _name;
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private List<ISupplementalMaterial> _steps;
        public List<ISupplementalMaterial> Steps
        {
            get { return _steps; }
            set { _steps = value; }
        }
    }
}
