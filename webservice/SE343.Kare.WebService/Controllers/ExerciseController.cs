using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using SE343.Kare.WebService.Models;
using SE343.Kare.WebService.DataContexts;

namespace SE343.Kare.WebService.Controllers
{
    public class ExerciseController : ApiController
    {
        private AssignmentsContext db = new AssignmentsContext();

        // GET api/Default1
        public IEnumerable<Exercise> GetExercises()
        {
            var exercises = db.Exercises.Include(e => e.Quiz);
            return exercises.AsEnumerable();
        }

        // GET api/Default1/5
        public Exercise GetExercise(int id)
        {
            Exercise exercise = db.Exercises.Find(id);
            if (exercise == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return exercise;
        }

        // PUT api/Default1/5
        public HttpResponseMessage PutExercise(int id, Exercise exercise)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != exercise.ExerciseId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(exercise).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Default1
        public HttpResponseMessage PostExercise(Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                db.Exercises.Add(exercise);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, exercise);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = exercise.ExerciseId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Default1/5
        public HttpResponseMessage DeleteExercise(int id)
        {
            Exercise exercise = db.Exercises.Find(id);
            if (exercise == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Exercises.Remove(exercise);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, exercise);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}