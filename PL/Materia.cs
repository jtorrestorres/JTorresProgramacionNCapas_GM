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
            ML.Materia materia = new ML.Materia();

            Console.WriteLine("Ingrese el nombre de la materia");
            materia.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese los creditos para la materia");
            materia.Creditos = byte.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el costo de la materia");
            materia.Costo = decimal.Parse(Console.ReadLine());


            //ML.Result result = BL.Materia.Add(materia);
            ML.Result result = BL.Materia.AddSP(materia);

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

            if (result.Correct)
            {
                Console.WriteLine("El registro se actulizo correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrio un error al actulizar la informacion " + result.ErrorMessage);
            }
        }



    }
}
