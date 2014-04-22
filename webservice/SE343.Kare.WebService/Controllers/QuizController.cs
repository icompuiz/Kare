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
    public class QuizController : ApiController
    {
        private AssignmentsContext db = new AssignmentsContext();

        // GET api/Quiz
        public IEnumerable<Quiz> GetQuizs()
        {
            return db.Quizes.AsEnumerable();
        }

        // GET api/Quiz/5
        public Quiz GetQuiz(int id)
        {
            Quiz quiz = db.Quizes.Find(id);
            if (quiz == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return quiz;
        }

        // PUT api/Quiz/5
        public HttpResponseMessage PutQuiz(int id, Quiz quiz)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != quiz.QuizId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(quiz).State = EntityState.Modified;

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

        // POST api/Quiz
        public HttpResponseMessage PostQuiz(Quiz quiz)
        {
            if (ModelState.IsValid)
            {
                db.Quizes.Add(quiz);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, quiz);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = quiz.QuizId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Quiz/5
        public HttpResponseMessage DeleteQuiz(int id)
        {
            Quiz quiz = db.Quizes.Find(id);
            if (quiz == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Quizes.Remove(quiz);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, quiz);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}