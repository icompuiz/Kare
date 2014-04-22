using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE343.Kare.WebService.Models
{
    public class AssignmentExercise
    {
        private Exercise _exercise;
        public Exercise Exercise
        {
            get { return _exercise; }
            set { _exercise = value; }
        }

        private int _repetitions;
        public int Repetitions
        {
            get { return _repetitions; }
            set { _repetitions = value; }
        }

        private String _notes;
        public String Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }

        private List<Response> _responses;
        public List<Response> Responses
        {
            get { return _responses; }
            set { _responses = value; }
        }
    }
}