using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class MateriaController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = BL.Materia.GetAllEF();
            ML.Materia materia = new ML.Materia();

            if(result.Correct)
            {
                materia.Materias = result.Objects;
            }


            return View(materia);
        }

        //presentar la vista
        [HttpGet]
        public ActionResult Form()
        {
            ML.Materia materia = new ML.Materia();
            materia.Semestre = new ML.Semestre();
            return View(materia);
        }

        [HttpPost]
        public ActionResult Form(ML.Materia materia)
        {
            ML.Result result = BL.Materia.AddEF(materia);

            if (result.Correct)
            {
                ViewBag.Mensaje = "Se ha agregado la materia en la BD";
            }
            else
            {
                ViewBag.Mensaje = "No se ha agregado la materia en la BD" + result.ErrorMessage;
            }

            return PartialView("Modal");
        }
    }
}