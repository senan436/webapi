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
using webapi.Models;

namespace webapi.Controllers
{
    public class ProductController : ApiController
    {
        private DBGR82Entities db = new DBGR82Entities();

        // GET: api/Product
        public IQueryable<PRODUCT> GetPRODUCTs()
        {
            return db.PRODUCTs;
        }

        // GET: api/Product/5
        [ResponseType(typeof(PRODUCT))]
        public IHttpActionResult GetPRODUCT(int id)
        {
            PRODUCT pRODUCT = db.PRODUCTs.Find(id);
            if (pRODUCT == null)
            {
                return NotFound();
            }

            return Ok(pRODUCT);
        }

        // PUT: api/Product/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPRODUCT(int id, PRODUCT pRODUCT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pRODUCT.ID)
            {
                return BadRequest();
            }

            db.Entry(pRODUCT).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PRODUCTExists(id))
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

        // POST: api/Product
        [ResponseType(typeof(PRODUCT))]
        public IHttpActionResult PostPRODUCT(PRODUCT pRODUCT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PRODUCTs.Add(pRODUCT);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pRODUCT.ID }, pRODUCT);
        }

        // DELETE: api/Product/5
        [ResponseType(typeof(PRODUCT))]
        public IHttpActionResult DeletePRODUCT(int id)
        {
            PRODUCT pRODUCT = db.PRODUCTs.Find(id);
            if (pRODUCT == null)
            {
                return NotFound();
            }

            db.PRODUCTs.Remove(pRODUCT);
            db.SaveChanges();

            return Ok(pRODUCT);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PRODUCTExists(int id)
        {
            return db.PRODUCTs.Count(e => e.ID == id) > 0;
        }
    }
}