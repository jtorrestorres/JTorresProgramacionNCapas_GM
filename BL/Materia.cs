using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BL
{
    public class Materia
    {
       //int 
       //byte 0-255
        public static void Add(ML.Materia materia) //Database
        {//SQL Client

            using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=JTorresProgramacionNCapas08122021;Persist Security Info=True;User ID=sa;Password=pass@word1"))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [Materia]([Nombre],[Creditos],[Costo])VALUES (@Nombre,@Creditos, @Costo)", conn);
                cmd.Parameters.AddWithValue("@Nombre", materia.Nombre);
                cmd.Parameters.AddWithValue("@Creditos", materia.Creditos);
                cmd.Parameters.AddWithValue("@Costo", materia.Costo);


                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
