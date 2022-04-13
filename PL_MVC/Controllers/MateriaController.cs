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
        public ActionResult Form(int? IdMateria)
        {
            ML.Materia materia = new ML.Materia();
            materia.Semestre = new ML.Semestre();

            if(IdMateria == null)
            {
                return View(materia);
            }
            else
            {
                ML.Result result = new ML.Result();
                result = BL.Materia.GetByIdEF(IdMateria.Value);

                if(result.Correct)
                {
                    materia = ((ML.Materia)result.Object);
                    return View(materia);
                }
            }
            return View();
            
        }

        [HttpPost]
        public ActionResult Form(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            if(materia.IdMateria == 0 )
            {
                result = BL.Materia.AddEF(materia);

                if (result.Correct)
                {
                    ViewBag.Mensaje = "Se ha agregado la materia en la BD";
                }
                else
                {
                    ViewBag.Mensaje = "No se ha agregado la materia en la BD" + result.ErrorMessage;
                }
            }
            else
            {
                result = BL.Materia.UpdateEF(materia);

                if(result.Correct)
                {
                    ViewBag.Mensaje = "La materia se actualizo correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "Ocurrio un error al realizar la actualizacion" + result.ErrorMessage;
                }
            }

            

            return PartialView("Modal");
        }


    }
}