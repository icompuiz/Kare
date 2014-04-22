using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SE343.Kare.WebService.Models;

namespace SE343.Kare.WebService.DataContexts
{
    public class AssignmentsContext:DbContext
    {
        public DbSet<Exercise> Exercises {get; set;}
        public DbSet<Instruction> Instructions {get; set;}
        public DbSet<Quiz> Quizes { get; set; }

        public DbSet<QuizQuestion> QuizQuestions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            Database.SetInitializer<AssignmentsContext>(null); // <--- This is what i needed


            base.OnModelCreating(modelBuilder);

        }
    }
}