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
    public class QuizQuestionController : ApiController
    {
        private AssignmentsContext db = new AssignmentsContext();

        // GET api/QuizQuestion
        public IEnumerable<QuizQuestion> GetQuizQuestions()
        {
            var quizquestions = db.QuizQuestions.Include(q => q.Quiz);
            return quizquestions.AsEnumerable();
        }

        // GET api/QuizQuestion/5
        public QuizQuestion GetQuizQuestion(int id)
        {
            QuizQuestion quizquestion = db.QuizQuestions.Find(id);
            if (quizquestion == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return quizquestion;
        }

        // PUT api/QuizQuestion/5
        public HttpResponseMessage PutQuizQuestion(int id, QuizQuestion quizquestion)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != quizquestion.QuizQuestionId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(quizquestion).State = EntityState.Modified;

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

        // POST api/QuizQuestion
        public HttpResponseMessage PostQuizQuestion(QuizQuestion quizquestion)
        {
            if (ModelState.IsValid)
            {
                db.QuizQuestions.Add(quizquestion);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, quizquestion);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = quizquestion.QuizQuestionId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/QuizQuestion/5
        public HttpResponseMessage DeleteQuizQuestion(int id)
        {
            QuizQuestion quizquestion = db.QuizQuestions.Find(id);
            if (quizquestion == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.QuizQuestions.Remove(quizquestion);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, quizquestion);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}