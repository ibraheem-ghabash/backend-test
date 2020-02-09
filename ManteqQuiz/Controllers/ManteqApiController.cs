using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using ManteqQuiz.Models;

namespace ManteqQuiz.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ManteqApiController : ApiController
    {
        private ManteqEntities db = new ManteqEntities();

        // GET: api/ManteqApi
        public IQueryable<Patient> GetPatients()
        {
            return db.Patients;
        }

        // GET: api/ManteqApi/5
        [ResponseType(typeof(Patient))]
        [HttpGet]
        public IHttpActionResult PatientGet(Guid id)
        {
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        // PUT: api/ManteqApi/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult PutPatient(Guid id, Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patient.Id)
            {
                return BadRequest();
            }

            db.Entry(patient).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ManteqApi
        [ResponseType(typeof(Patient))]
        [HttpPost]
        public IHttpActionResult PatientAdd(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            patient.Id = Guid.NewGuid();
            patient.RecordCreationDate = System.DateTime.Now;
            db.Patients.Add(patient);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PatientExists(patient.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(new Uri(Request.RequestUri +"/" + patient.Id), patient);
        }

        // DELETE: api/ManteqApi/5
        [ResponseType(typeof(Patient))]
        [HttpDelete]
        public IHttpActionResult PatientDelete(Guid id)
        {
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return NotFound();
            }

            db.Patients.Remove(patient);
            db.SaveChanges();

            return Ok(patient);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PatientExists(Guid id)
        {
            return db.Patients.Count(e => e.Id == id) > 0;
        }
    }
}