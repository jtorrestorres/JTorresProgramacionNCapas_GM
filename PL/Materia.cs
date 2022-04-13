using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Materia
    {
        public static void Add()
        {
            //mensaje prueba
            ML.Materia materia = new ML.Materia();

            Console.WriteLine("Ingrese el nombre de la materia que desee ingresar");
            materia.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese los creditos para la materia");
            materia.Creditos = byte.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el costo de la materia");
            materia.Costo = decimal.Parse(Console.ReadLine());

            materia.Semestre = new ML.Semestre();
            Console.WriteLine("Ingrese el semestre: ");
            materia.Semestre.IdSemestre = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Materia.Add(materia);
            //ML.Result result = BL.Materia.AddSP(materia);
            //ML.Result result = BL.Materia.AddEF(materia);
            ML.Result result = BL.Materia.AddLINQ(materia);


            if (result.Correct)
            {
                Console.WriteLine("Se ha registrado la materia");
            }
            else
            {
                Console.WriteLine("No se ha podido registrar la materia" + result.ErrorMessage);
            }

        }

        public static void Update()
        {
            ML.Materia materia = new ML.Materia();

            Console.WriteLine("Ingrese el id de la materia");
            materia.IdMateria = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el nombre");
            materia.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese los creditos");
            materia.Creditos = Byte.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el costo");
            materia.Costo = Decimal.Parse(Console.ReadLine());

            ML.Result result = BL.Materia.Update(materia);
            //ML.Result result = BL.Materia.UpdateLINQ(materia);

            if (result.Correct)
            {
                Console.WriteLine("El registro se actulizo correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrio un error al actulizar la informacion " + result.ErrorMessage);
            }
        }

        public static void GetAll()
        {
            //ML.Result result = BL.Materia.GetAllEF();
            ML.Result result = BL.Materia.GetAllLINQ();
            if (result.Correct)
            {
                foreach(ML.Materia materia in result.Objects)
                {
                    Console.WriteLine("IdMateria" + materia.IdMateria);
                    Console.WriteLine("Nombre" + materia.Nombre);
                    Console.WriteLine("Creditos" + materia.Creditos);
                    Console.WriteLine("Costo" + materia.Costo);
                    Console.WriteLine("IdSemestre" + materia.Semestre.IdSemestre);
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Ocurrio un error al realizar la consulta " + result.ErrorMessage);
            }
        }

        public static void GetById()
        {
            Console.WriteLine("Ingrese el Id de la Materia");
            ML.Result result = BL.Materia.GetByIdSP(int.Parse(Console.ReadLine()));

            ML.Materia materia = ((ML.Materia)result.Object);

            Console.WriteLine("Nombre: " + materia.Nombre);
            Console.WriteLine("Creditos: " + materia.Creditos);
            Console.WriteLine("Costo: " + materia.Costo);
            Console.WriteLine("IdSemestre" + materia.Semestre.IdSemestre);
        }
    }
}
