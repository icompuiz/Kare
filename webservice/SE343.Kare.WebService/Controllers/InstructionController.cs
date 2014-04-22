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
    public class InstructionController : ApiController
    {
        private AssignmentsContext db = new AssignmentsContext();

        // GET api/Default1
        public IEnumerable<Instruction> GetInstructions()
        {
            var instructions = db.Instructions.Include(i => i.Exercise);
            return instructions.AsEnumerable();
        }

        // GET api/Default1/5
        public Instruction GetInstruction(int id)
        {
            Instruction instruction = db.Instructions.Find(id);
            if (instruction == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return instruction;
        }

        // PUT api/Default1/5
        public HttpResponseMessage PutInstruction(int id, Instruction instruction)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != instruction.InstructionId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(instruction).State = EntityState.Modified;

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
        public HttpResponseMessage PostInstruction(Instruction instruction)
        {
            if (ModelState.IsValid)
            {
                db.Instructions.Add(instruction);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, instruction);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = instruction.InstructionId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Default1/5
        public HttpResponseMessage DeleteInstruction(int id)
        {
            Instruction instruction = db.Instructions.Find(id);
            if (instruction == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Instructions.Remove(instruction);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, instruction);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}