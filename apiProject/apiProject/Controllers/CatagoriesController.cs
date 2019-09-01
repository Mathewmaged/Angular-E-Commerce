using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using apiProject.Models;

namespace apiProject.Controllers
{
    public class CatagoriesController : ApiController
    {
        private ApplicationDbcontext db = new ApplicationDbcontext();

        // GET: api/Catagories
        public IHttpActionResult GetCatagories()
        {
            return Json(db.Catagories.ToList());
        }

        // GET: api/Catagories/5
        
        public IHttpActionResult GetCatagory(int id)
        {
            Catagory catagory = db.Catagories.Find(id);

            return Json(catagory);
        }

        // PUT: api/Catagories/5
        
        public IHttpActionResult PutCatagory(int id, Catagory catagory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != catagory.ID)
            {
                return BadRequest();
            }

            var c = (from i in db.Catagories
                     where i.ID == id
                     select i).FirstOrDefault();
            c.Name = catagory.Name;
            db.SaveChanges();
            try
            {
                //db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatagoryExists(id))
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

        // POST: api/Catagories
        
        public IHttpActionResult PostCatagory([FromBody]Catagory catagory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Catagories.Add(catagory);
            db.SaveChanges();

            return Ok();
        }

        // DELETE: api/Catagories/5
       
        public IHttpActionResult DeleteCatagory(int id)
        {
            Catagory catagory = db.Catagories.Find(id);
            if (catagory == null)
            {
                return NotFound();
            }

            db.Catagories.Remove(catagory);
            db.SaveChanges();

            return Ok(catagory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CatagoryExists(int id)
        {
            return db.Catagories.Count(e => e.ID == id) > 0;
        }
    }
}