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
using ElectronicStore.Models;

namespace ElectronicStore.Controllers
{
    public class Staff_TableController : ApiController
    {
        private ElectronicStoreEntities db = new ElectronicStoreEntities();

        // GET: api/Staff_Table
        public IQueryable<Staff_Table> GetStaff_Table()
        {
            return db.Staff_Table;
        }

        // GET: api/Staff_Table/5
        [ResponseType(typeof(Staff_Table))]
        public IHttpActionResult GetStaff_Table(int id)
        {
            Staff_Table staff_Table = db.Staff_Table.Find(id);
            if (staff_Table == null)
            {
                return NotFound();
            }

            return Ok(staff_Table);
        }

        // PUT: api/Staff_Table/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStaff_Table(int id, Staff_Table staff_Table)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != staff_Table.id)
            {
                return BadRequest();
            }

            db.Entry(staff_Table).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Staff_TableExists(id))
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

        // POST: api/Staff_Table
        [ResponseType(typeof(Staff_Table))]
        public IHttpActionResult PostStaff_Table(Staff_Table staff_Table)
        
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Staff_Table.Add(staff_Table);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = staff_Table.id }, staff_Table);
        }

        // DELETE: api/Staff_Table/5
        [ResponseType(typeof(Staff_Table))]
        public IHttpActionResult DeleteStaff_Table(int id)
        {
            Staff_Table staff_Table = db.Staff_Table.Find(id);
            if (staff_Table == null)
            {
                return NotFound();
            }

            db.Staff_Table.Remove(staff_Table);
            db.SaveChanges();

            return Ok(staff_Table);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Staff_TableExists(int id)
        {
            return db.Staff_Table.Count(e => e.id == id) > 0;
        }
    }
}