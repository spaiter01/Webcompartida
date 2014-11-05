using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CAPANEGOCIO;
using DEMO.Models;
using System.Data;

namespace DEMO.Controllers
{
    public class PersonaController : Controller
    {
        //
        // GET: /Persona/
        /// <summary>
        /// fgfgfgfg
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            List<PERSONA> personas = new List<PERSONA>(); 
           
            PERSONANEGOCIO neg = new PERSONANEGOCIO();

            DataTable dtPersonas =  neg.Listar();

            
            for (int i = 0; i <= dtPersonas.Rows.Count-1; i++)
            {
                PERSONA p = new PERSONA();
                p.ID = Convert.ToInt32(dtPersonas.Rows[i]["Id"]);
                p.NOMBRES = dtPersonas.Rows[i]["Nombres"].ToString();
                p.APELLIDOS = dtPersonas.Rows[i]["Apellidos"].ToString();
                p.FECHA = Convert.ToDateTime(dtPersonas.Rows[i]["Fecha"]);
                p.Departamento = dtPersonas.Rows[i]["Departamento"].ToString();
                p.Provincia = dtPersonas.Rows[i]["Provincia"].ToString();
                p.Distrito = dtPersonas.Rows[i]["Distrito"].ToString();
                personas.Add(p);
            }
     
            return View (personas); 
        }
        
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "Nombres,Apellidos,Fecha,CodigoDepartamento,CodigoProvincia,CodigoDistrito")] PERSONA persona)

        {
            //if (ModelState.IsValid)
            //{
            PERSONANEGOCIO negocio = new PERSONANEGOCIO();
            
            if(negocio.insertar(persona.NOMBRES,persona.APELLIDOS,persona.FECHA,persona.CodDep,persona.CodProv,persona.CodDist)==true)
            {
                ViewBag.Message = "Registro Insertado Correctamente";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Error al Guardar la informacion";
                return View (persona);
            }
             
            //}

         
        }

        public ActionResult BuscarPersona(int? Id)
        {
            PERSONA persona = new PERSONA();  

            PERSONANEGOCIO neg = new PERSONANEGOCIO();
            DataTable dtPersonas = neg.Buscar(Convert.ToInt32(Id));
                      
            if (dtPersonas.Rows.Count > 0)
            {

                persona.ID = Convert.ToInt32(dtPersonas.Rows[0]["Id"].ToString());
                persona.NOMBRES = dtPersonas.Rows[0]["Nombres"].ToString();
                persona.APELLIDOS = dtPersonas.Rows[0]["Apellidos"].ToString();
                persona.FECHA = Convert.ToDateTime(dtPersonas.Rows[0]["Fecha"].ToString());
            }
            return View(persona); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuscarPersona([Bind(Include = "Id,Nombres,Apellidos,Fecha")] PERSONA persona)
        {
            //if (ModelState.IsValid)
            //{
            PERSONANEGOCIO negocio = new PERSONANEGOCIO();

            if (negocio.Actualizar(persona.ID,persona.NOMBRES,persona.APELLIDOS,persona.FECHA ) == true)
            {
                ViewBag.Message = "Datos Actualizado";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Error al Actualizar";
                return View(persona);
            }

            //}


        }

        public ActionResult Eliminar(int? id)
        {
            PERSONA persona = new PERSONA();

            PERSONANEGOCIO negocio = new PERSONANEGOCIO();

            if (negocio.Eliminar(Convert.ToInt32(id)) == true)
            {
              
                ViewBag.Message = "Datos Eliminados";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Error al Eliminar";
                return View(persona);
            }
            
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
         
           PERSONANEGOCIO negocio = new PERSONANEGOCIO();

           negocio.Eliminar(Convert.ToInt32(id));
                        
           return RedirectToAction("Index");
 

        }
        public ActionResult Detalle(int? id)
        {
            PERSONA persona = new PERSONA();

            PERSONANEGOCIO neg = new PERSONANEGOCIO();
            DataTable dtPersonas = neg.Detalle(Convert.ToInt32(id));

            if (dtPersonas.Rows.Count > 0)
            {

                persona.ID = Convert.ToInt32(dtPersonas.Rows[0]["Id"].ToString());
                persona.NOMBRES = dtPersonas.Rows[0]["Nombres"].ToString();
                persona.APELLIDOS = dtPersonas.Rows[0]["Apellidos"].ToString();
                persona.FECHA = Convert.ToDateTime(dtPersonas.Rows[0]["Fecha"].ToString());

                persona.Departamento = dtPersonas.Rows[0]["Departamento"].ToString();
                persona.Provincia = dtPersonas.Rows[0]["Provincia"].ToString();
                persona.Distrito = dtPersonas.Rows[0]["Distrito"].ToString();


            }
            return View(persona); 
        }
          
        
        public ActionResult Creando()
        {
            UbigeoNegocio neg = new UbigeoNegocio();

            DataTable dtDepartamento = neg.Listar();

            List<SelectListItem> li = new List<SelectListItem>();

            for (int i = 0; i <= dtDepartamento.Rows.Count - 1; i++)
            {
                string nombre = dtDepartamento.Rows[i]["Departamento"].ToString();
                string valor = dtDepartamento.Rows[i]["CodigoDepartamento"].ToString();

                SelectListItem item = new SelectListItem() { Text = nombre, Value = valor };

                li.Add(item);

            }
            ViewData["Ubigeo"] = li;
            return View();
       
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Creando([Bind(Include = "Nombres,Apellidos,Fecha,Departamento,Provincia,Distrito")] PERSONA persona)
        {
            //if (ModelState.IsValid)
            //{
            PERSONANEGOCIO negocio = new PERSONANEGOCIO();

            if (negocio.insertar(persona.NOMBRES,persona.APELLIDOS,persona.FECHA,persona.Departamento,persona.Provincia,persona.Distrito)==true)
            {
                ViewBag.Message = "Registro Insertado Correctamente";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Error al Guardar la informacion";
                return View(persona);
            }

           

        }
        



        public JsonResult GetStates(string idDepartamento)
        {
            UbigeoNegocio neg = new UbigeoNegocio();

            DataTable dtProvincia = neg.BuscarProvincias(idDepartamento);   

            List<SelectListItem> li = new List<SelectListItem>();

            for (int i = 0; i <= dtProvincia.Rows.Count - 1; i++)
            {
                string nombre = dtProvincia.Rows[i]["Provincia"].ToString();
                string valor = dtProvincia.Rows[i]["CodigoProvincia"].ToString();

                SelectListItem item = new SelectListItem() { Text = nombre, Value = valor };

                li.Add(item);

            }                               

            return Json(new SelectList(li, "Value", "Text"));
        }

        public JsonResult GetCity(string idDepartamento, string idProvincia)
        {
            UbigeoNegocio neg = new UbigeoNegocio();

            DataTable dtDistritos = neg.BuscarDistritos(idDepartamento, idProvincia);

            List<SelectListItem> li = new List<SelectListItem>();

            for (int i = 0; i <= dtDistritos.Rows.Count - 1; i++)
            {
                string nombre = dtDistritos.Rows[i]["Distrito"].ToString();
                string valor = dtDistritos.Rows[i]["CodigoDistrito"].ToString();

                SelectListItem item = new SelectListItem() { Text = nombre, Value = valor };

                li.Add(item);

            }

            return Json(new SelectList(li, "Value", "Text"));
        }


      


           
        }        

        }

       

