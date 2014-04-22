using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE343.Kare.WebService.Models
{
    public class Assignment
    {
        private List<AssignmentExercise> _assignmentExercises;

        public List<AssignmentExercise> AssignmentExercises
        {
            get { return _assignmentExercises; }
            set { _assignmentExercises = value; }
        }
    }
}