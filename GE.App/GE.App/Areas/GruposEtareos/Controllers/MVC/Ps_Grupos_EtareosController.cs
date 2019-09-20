using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GruposEtareos.BI;
//using GrupoEtareos.App.Filter;
//using Microsoft.Owin.Security;
//using System.Web.Http.Cors;

namespace GrupoEtareos.App.Areas.GruposEtareos.Controllers.MVC
{
    /// <summary>
    /// AuthorizeUser es parametrizado para evitar que se haga uso del controlador sin haberse logueado con las credenciades de INTEGRA
    /// </summary>
    //[AuthorizeUser]
    //[EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-Custom-Header")]
    public class Ps_Grupos_EtareosController : Controller
    {
        /// <summary>
        /// Variable para hacer uso de las entidades del modelo de datos
        /// </summary>
        private GruposEtareosEntities db = new GruposEtareosEntities();

        #region Constante de campos para la entidad PS_GRUPOS_ETAREOS
        private const string FieldEntitie = @"ID,COD_SEXO,EDAD_MINIMA,EDAD_MAXIMA,ID_UNIDADMEDIDA,DESC_GRUPOETAREO,ESTADO_GRUPOETAREO,COD_USUARIO";
        #endregion

        ///// <summary>
        ///// 
        ///// </summary>
        //private IAuthenticationManager AuthenticationManager
        //{
        //    get
        //    {
        //        return HttpContext.GetOwinContext().Authentication;
        //    }
        //}

        /// <summary>
        /// Se ejecuta al iniciar la opción de creación del grupo etareo, es la primera funcion ejecutada al inciar el llamado al controlador
        /// </summary>
        /// <returns></returns>
        // GET: GruposEtareos/Ps_Grupos_Etareos
        public ActionResult Index()
        {
            ViewBag.UnidadMedida = new SelectList(db.GN_UNIDAD_MEDIDA, "ID_UNIDADMEDIDA", "DESC_UNIDADMEDIDA");
            ViewBag.Sexo = new SelectList((from sx in db.SEXOes where sx.DESC_SEXO != "NO REPORTADO" select sx), "COD_SEXO", "DESC_SEXO");

            var ps_GruposEtareos = new PS_GRUPOS_ETAREOS()
            {
                ID = (!db.PS_GRUPOS_ETAREOS.ToList().Any() ? 0 : db.PS_GRUPOS_ETAREOS.Max(d => d.ID)) + 1,
                ESTADO_GRUPOETAREO = true,
                //COD_USUARIO = AuthenticationManager.User.Identity.Name
            };

            var items = from ge in db.PS_GRUPOS_ETAREOS.ToList()
                        select new PS_GRUPOS_ETAREOS
                        {
                            ID = ge.ID,
                            COD_SEXO = ge.COD_SEXO,
                            COD_USUARIO = ge.COD_USUARIO,
                            ID_UNIDADMEDIDA = ge.ID_UNIDADMEDIDA,
                            DESC_GRUPOETAREO = ge.DESC_GRUPOETAREO,
                            EDAD_MINIMA = ge.EDAD_MINIMA,
                            EDAD_MAXIMA = ge.EDAD_MAXIMA,
                            ESTADO_GRUPOETAREO = ge.ESTADO_GRUPOETAREO,
                            SEXO = ge.SEXO,
                            GN_UNIDAD_MEDIDA = ge.GN_UNIDAD_MEDIDA
                        };
            ViewBag.Ps_Grupos_Etareos = items.ToList();

            ViewBag.Edit = false;

            return View("Create", ps_GruposEtareos);
        }

        /// <summary>
        /// Se ejecuta cuando se envia el formulario con la opción de create, por la opción GET.
        /// </summary>
        /// <returns>Retorna la vista a ejecutar al momento de realizar la creación del grupo etareo</returns>
        // GET: GruposEtareos/Ps_Grupos_Etareos/Create
        public ActionResult Create()
        {
            var ps_GruposEtareos = new PS_GRUPOS_ETAREOS()
            {
                ID = (!db.PS_GRUPOS_ETAREOS.ToList().Any() ? 0 : db.PS_GRUPOS_ETAREOS.Max(d => d.ID)) + 1,
                ESTADO_GRUPOETAREO = true,
                //COD_USUARIO = AuthenticationManager.User.Identity.Name
            };

            ViewBag.UnidadMedida = new SelectList(db.GN_UNIDAD_MEDIDA, "ID_UNIDADMEDIDA", "DESC_UNIDADMEDIDA");
            ViewBag.Sexo = new SelectList((from sx in db.SEXOes where sx.DESC_SEXO != "NO REPORTADO" select sx), "COD_SEXO", "DESC_SEXO");
            var items = from ge in db.PS_GRUPOS_ETAREOS.ToList()
                        select new PS_GRUPOS_ETAREOS
                        {
                            ID = ge.ID,
                            COD_SEXO = ge.COD_SEXO,
                            COD_USUARIO = ge.COD_USUARIO,
                            ID_UNIDADMEDIDA = ge.ID_UNIDADMEDIDA,
                            DESC_GRUPOETAREO = ge.DESC_GRUPOETAREO,
                            EDAD_MINIMA = ge.EDAD_MINIMA,
                            EDAD_MAXIMA = ge.EDAD_MAXIMA,
                            ESTADO_GRUPOETAREO = ge.ESTADO_GRUPOETAREO,
                            SEXO = ge.SEXO,
                            GN_UNIDAD_MEDIDA = ge.GN_UNIDAD_MEDIDA
                        };
            ViewBag.Ps_Grupos_Etareos = items.ToList();
            ViewBag.Edit = false;

            return View(ps_GruposEtareos);
        }

        /// <summary>
        /// Se ejecuta cuando se envia el formulario con la opción de create, por la opción POST.
        /// </summary>
        /// <param name="pS_GRUPOS_ETAREOS">Indica la entidad a crear con los parametros para la creación del grupo etareo.</param>
        /// <returns>Retorna la vista a ejecutar al momento de realizar la creación del grupo etareo</returns>
        // POST: GruposEtareos/Ps_Grupos_Etareos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = FieldEntitie)] PS_GRUPOS_ETAREOS pS_GRUPOS_ETAREOS)
        {
            if (ModelState.IsValid)
            {
                db.PS_GRUPOS_ETAREOS.Add(pS_GRUPOS_ETAREOS);
                db.SaveChanges();
                return RedirectToAction("Create");
            }


            ViewBag.UnidadMedida = new SelectList(db.GN_UNIDAD_MEDIDA, "ID_UNIDADMEDIDA", "DESC_UNIDADMEDIDA");
            ViewBag.Sexo = new SelectList((from sx in db.SEXOes where sx.DESC_SEXO != "NO REPORTADO" select sx), "COD_SEXO", "DESC_SEXO");
            var items = from ge in db.PS_GRUPOS_ETAREOS.ToList()
                        select new PS_GRUPOS_ETAREOS
                        {
                            ID = ge.ID,
                            COD_SEXO = ge.COD_SEXO,
                            COD_USUARIO = ge.COD_USUARIO,
                            ID_UNIDADMEDIDA = ge.ID_UNIDADMEDIDA,
                            DESC_GRUPOETAREO = ge.DESC_GRUPOETAREO,
                            EDAD_MINIMA = ge.EDAD_MINIMA,
                            EDAD_MAXIMA = ge.EDAD_MAXIMA,
                            ESTADO_GRUPOETAREO = ge.ESTADO_GRUPOETAREO,
                            SEXO = ge.SEXO,
                            GN_UNIDAD_MEDIDA = ge.GN_UNIDAD_MEDIDA
                        };
            ViewBag.Ps_Grupos_Etareos = items.ToList();

            ViewBag.Edit = false;

            return View(pS_GRUPOS_ETAREOS);
        }

        /// <summary>
        /// Se ejecuta cuando se envia el formulario con la opción de create, por la opción POST.
        /// </summary>
        /// <returns>Retorna la vista a ejecutar al momento de realizar la creación del grupo etareo</returns>
        [HttpPost]
        public ActionResult getPsGruposEtareos(string strDescGrupoEtareo, int? strCodGrupoEtareo = null, bool? blEstado = null)
        {
            var items = from ge in db.PS_GRUPOS_ETAREOS.ToList()
                        where (!string.IsNullOrEmpty(strDescGrupoEtareo) ? ge.DESC_GRUPOETAREO.Contains(strDescGrupoEtareo) : (strCodGrupoEtareo != null ? ge.ID == strCodGrupoEtareo : true))
                            && (blEstado == null ? true : ge.ESTADO_GRUPOETAREO == blEstado)
                        select new
                        {
                            ID = ge.ID,
                            COD_SEXO = ge.COD_SEXO,
                            DESC_SEXO = ge.SEXO.DESC_SEXO,
                            COD_USUARIO = ge.COD_USUARIO,
                            ID_UNIDADMEDIDA = ge.ID_UNIDADMEDIDA,
                            DESC_UNIDADMEDIDA = ge.GN_UNIDAD_MEDIDA.DESC_UNIDADMEDIDA,
                            DESC_GRUPOETAREO = ge.DESC_GRUPOETAREO,
                            EDAD_MINIMA = ge.EDAD_MINIMA,
                            EDAD_MAXIMA = ge.EDAD_MAXIMA,
                            ESTADO_GRUPOETAREO = ge.ESTADO_GRUPOETAREO
                        };

            return Json(items, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Se ejecuta cuando se envia el formulario con la opción de create, por la opción GET.
        /// </summary>
        /// <param name="id">Indica identificador de la entidad para el registro a editar.</param>
        /// <returns>Retorna la vista a ejecutar al momento de realizar la edición del grupo etareo</returns>
        // GET: GruposEtareos/Ps_Grupos_Etareos/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.UnidadMedida = new SelectList(db.GN_UNIDAD_MEDIDA, "ID_UNIDADMEDIDA", "DESC_UNIDADMEDIDA");
            ViewBag.Sexo = new SelectList((from sx in db.SEXOes where sx.DESC_SEXO != "NO REPORTADO" select sx), "COD_SEXO", "DESC_SEXO");
            var items = from ge in db.PS_GRUPOS_ETAREOS.ToList()
                        select new PS_GRUPOS_ETAREOS
                        {
                            ID = ge.ID,
                            COD_SEXO = ge.COD_SEXO,
                            COD_USUARIO = ge.COD_USUARIO,
                            ID_UNIDADMEDIDA = ge.ID_UNIDADMEDIDA,
                            DESC_GRUPOETAREO = ge.DESC_GRUPOETAREO,
                            EDAD_MINIMA = ge.EDAD_MINIMA,
                            EDAD_MAXIMA = ge.EDAD_MAXIMA,
                            ESTADO_GRUPOETAREO = ge.ESTADO_GRUPOETAREO,
                            SEXO = ge.SEXO,
                            GN_UNIDAD_MEDIDA = ge.GN_UNIDAD_MEDIDA
                        };
            ViewBag.Ps_Grupos_Etareos = items.ToList();
            PS_GRUPOS_ETAREOS pS_GRUPOS_ETAREOS = items.FirstOrDefault(d => d.ID == id);
            
            ViewBag.Edit = true;

            if (pS_GRUPOS_ETAREOS == null)
            {
                return HttpNotFound();
            } else
            {
                //pS_GRUPOS_ETAREOS.COD_USUARIO = string.IsNullOrEmpty(pS_GRUPOS_ETAREOS.COD_USUARIO) ? AuthenticationManager.User.Identity.Name : pS_GRUPOS_ETAREOS.COD_USUARIO;
            }

            return View("Create", pS_GRUPOS_ETAREOS);
        }

        /// <summary>
        /// Se ejecuta cuando se envia el formulario con la opción de create, por la opción POST.
        /// </summary>
        /// <param name="pS_GRUPOS_ETAREOS">Indica la entidad a crear con los parametros para la creación del grupo etareo.</param>
        /// <returns>Retorna la vista a ejecutar al momento de realizar la edición del grupo etareo</returns>
        // POST: GruposEtareos/Ps_Grupos_Etareos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = FieldEntitie)] PS_GRUPOS_ETAREOS pS_GRUPOS_ETAREOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pS_GRUPOS_ETAREOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            ViewBag.UnidadMedida = new SelectList(db.GN_UNIDAD_MEDIDA, "ID_UNIDADMEDIDA", "DESC_UNIDADMEDIDA");
            ViewBag.Sexo = new SelectList((from sx in db.SEXOes where sx.DESC_SEXO != "NO REPORTADO" select sx), "COD_SEXO", "DESC_SEXO");
            var items = from ge in db.PS_GRUPOS_ETAREOS.ToList()
                        select new PS_GRUPOS_ETAREOS
                        {
                            ID = ge.ID,
                            COD_SEXO = ge.COD_SEXO,
                            COD_USUARIO = ge.COD_USUARIO,
                            ID_UNIDADMEDIDA = ge.ID_UNIDADMEDIDA,
                            DESC_GRUPOETAREO = ge.DESC_GRUPOETAREO,
                            EDAD_MINIMA = ge.EDAD_MINIMA,
                            EDAD_MAXIMA = ge.EDAD_MAXIMA,
                            ESTADO_GRUPOETAREO = ge.ESTADO_GRUPOETAREO,
                            SEXO = ge.SEXO,
                            GN_UNIDAD_MEDIDA = ge.GN_UNIDAD_MEDIDA
                        };
            ViewBag.Ps_Grupos_Etareos = items.ToList();

            ViewBag.Edit = true;

            return View("Create", pS_GRUPOS_ETAREOS);
        }

    }
}
