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
using GruposEtareos.BI;
using System.Web.Http.Cors;

namespace GrupoEtareos.App.Areas.GruposEtareos.Controllers.API
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-Custom-Header")]
    public class Ps_Grupos_EtareosController : ApiController
    {
        private GruposEtareosEntities db = new GruposEtareosEntities();

        // GET: api/Ps_Grupos_Etareos
        public IQueryable<PS_GRUPOS_ETAREOS> GetPS_GRUPOS_ETAREOS()
        {
            var items = from ge in db.PS_GRUPOS_ETAREOS.ToList()
                        select new PS_GRUPOS_ETAREOS
                        {
                            ID = ge.ID,
                            COD_SEXO = ge.COD_SEXO,
                            //DESC_SEXO = ge.SEXO.DESC_SEXO,
                            COD_USUARIO = ge.COD_USUARIO,
                            ID_UNIDADMEDIDA = ge.ID_UNIDADMEDIDA,
                            //DESC_UNIDADMEDIDA = ge.GN_UNIDAD_MEDIDA.DESC_UNIDADMEDIDA,
                            DESC_GRUPOETAREO = ge.DESC_GRUPOETAREO,
                            EDAD_MINIMA = ge.EDAD_MAXIMA,
                            EDAD_MAXIMA = ge.ID,
                            ESTADO_GRUPOETAREO = ge.ESTADO_GRUPOETAREO,
                        };

            return items.AsQueryable();
        }

        // GET: api/Ps_Grupos_Etareos/5
        [ResponseType(typeof(PS_GRUPOS_ETAREOS))]
        public IHttpActionResult GetPS_GRUPOS_ETAREOS(long id)
        {
            PS_GRUPOS_ETAREOS pS_GRUPOS_ETAREOS = db.PS_GRUPOS_ETAREOS.Find(id);
            if (pS_GRUPOS_ETAREOS == null)
            {
                return NotFound();
            }

            return Ok(pS_GRUPOS_ETAREOS);
        }

        // PUT: api/Ps_Grupos_Etareos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPS_GRUPOS_ETAREOS(long id, PS_GRUPOS_ETAREOS pS_GRUPOS_ETAREOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pS_GRUPOS_ETAREOS.ID)
            {
                return BadRequest();
            }

            db.Entry(pS_GRUPOS_ETAREOS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PS_GRUPOS_ETAREOSExists(id))
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

        // POST: api/Ps_Grupos_Etareos
        [ResponseType(typeof(PS_GRUPOS_ETAREOS))]
        public IHttpActionResult PostPS_GRUPOS_ETAREOS(PS_GRUPOS_ETAREOS pS_GRUPOS_ETAREOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PS_GRUPOS_ETAREOS.Add(pS_GRUPOS_ETAREOS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PS_GRUPOS_ETAREOSExists(pS_GRUPOS_ETAREOS.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pS_GRUPOS_ETAREOS.ID }, pS_GRUPOS_ETAREOS);
        }

        // DELETE: api/Ps_Grupos_Etareos/5
        [ResponseType(typeof(PS_GRUPOS_ETAREOS))]
        public IHttpActionResult DeletePS_GRUPOS_ETAREOS(long id)
        {
            PS_GRUPOS_ETAREOS pS_GRUPOS_ETAREOS = db.PS_GRUPOS_ETAREOS.Find(id);
            if (pS_GRUPOS_ETAREOS == null)
            {
                return NotFound();
            }

            db.PS_GRUPOS_ETAREOS.Remove(pS_GRUPOS_ETAREOS);
            db.SaveChanges();

            return Ok(pS_GRUPOS_ETAREOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PS_GRUPOS_ETAREOSExists(long id)
        {
            return db.PS_GRUPOS_ETAREOS.Count(e => e.ID == id) > 0;
        }
    }
}