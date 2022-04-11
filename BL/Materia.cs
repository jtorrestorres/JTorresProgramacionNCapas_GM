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
        //public static void Add(ML.Materia materia) //Database
        //{//SQL Client

        //    using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=LEscogidoMarzo;User ID=sa;Password=pass@word1"))
        //    {
        //        SqlCommand cmd = new SqlCommand("INSERT INTO [Materia]([Nombre],[Creditos],[Costo])VALUES (@Nombre,@Creditos, @Costo)", conn);
        //        cmd.Parameters.AddWithValue("@Nombre", materia.Nombre);
        //        cmd.Parameters.AddWithValue("@Creditos", materia.Creditos);
        //        cmd.Parameters.AddWithValue("@Costo", materia.Costo);


        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //}
        public static ML.Result Add(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "INSERT INTO Materia (Nombre, Creditos, Costo) VALUES (@Nombre, @Creditos, @Costo)";

                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = query;
                    cmd.Connection = context;

                    SqlParameter[] collection = new SqlParameter[4];

                    collection[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                    collection[0].Value = materia.Nombre;

                    collection[1] = new SqlParameter("@Creditos", SqlDbType.TinyInt);
                    collection[1].Value = materia.Creditos;

                    collection[2] = new SqlParameter("@Costo", SqlDbType.Decimal);
                    collection[2].Value = materia.Costo;

                    collection[3] = new SqlParameter("IdSemestre", SqlDbType.Int);
                    collection[3].Value = materia.Semestre.IdSemestre;

                    cmd.Parameters.AddRange(collection);

                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result Update(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "UPDATE [Materia] SET[Nombre] = @Nombre,[Costo] = @Costo,[Creditos] = @Creditos WHERE IdMateria = @IdMateria";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        SqlParameter[] collection = new SqlParameter[4];

                        collection[0] = new SqlParameter("IdMateria", SqlDbType.Int);
                        collection[0].Value = materia.IdMateria;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = materia.Nombre;

                        collection[2] = new SqlParameter("Creditos", SqlDbType.TinyInt);
                        collection[2].Value = materia.Creditos;

                        collection[3] = new SqlParameter("Costo", SqlDbType.Decimal);
                        collection[3].Value = materia.Costo;

                        collection[3] = new SqlParameter("IdSemestre", SqlDbType.Int);
                        collection[3].Value = materia.Semestre.IdSemestre;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        cmd.Connection.Close();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }


                    }
                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result AddSP(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "MateriaAdd"; //Nombre SP
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[4];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = materia.Nombre;


                        collection[1] = new SqlParameter("Creditos", SqlDbType.TinyInt);
                        collection[1].Value = materia.Creditos;


                        collection[2] = new SqlParameter("Costo", SqlDbType.Decimal);
                        collection[2].Value = materia.Costo;

                        collection[3] = new SqlParameter("IdSemestre", SqlDbType.Int);
                        collection[3].Value = materia.Semestre.IdSemestre;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();
                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }

                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

       public static ML.Result GetAllSP()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "MateriaGetAll";
                    using(SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable tableMateria = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tableMateria);

                        if(tableMateria.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach(DataRow row in tableMateria.Rows)
                            {
                                ML.Materia materia = new ML.Materia();
                                materia.IdMateria = int.Parse(row[0].ToString());
                                materia.Nombre = row[1].ToString();
                                materia.Creditos = Byte.Parse(row[2].ToString());
                                materia.Costo =Decimal.Parse(row[3].ToString());
                                materia.Semestre.IdSemestre = int.Parse(row[4].ToString());

                                result.Objects.Add(materia);

                            }
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }                       
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct=false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result GetByIdSP(int IdMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "MateriaGetById";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdMateria", SqlDbType.Int);
                        collection[0].Value = IdMateria;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        DataTable tablaMateria = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tablaMateria);

                        if (tablaMateria.Rows.Count > 0)
                        {
                            DataRow row = tablaMateria.Rows[0];

                            ML.Materia materia = new ML.Materia();
                            materia.IdMateria = int.Parse(row[0].ToString());
                            materia.Nombre = row[1].ToString();
                            materia.Creditos = Byte.Parse(row[2].ToString());
                            materia.Costo = Decimal.Parse(row[3].ToString());
                            materia.Semestre.IdSemestre = int.Parse(row[4].ToString());


                            result.Object = materia;
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result AddEF(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.AGarciaGMEntities context = new DL_EF.AGarciaGMEntities())
                {
                    var query = context.MateriaAdd(materia.Nombre, materia.Creditos, materia.Costo, materia.Semestre.IdSemestre);
                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct=false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.AGarciaGMEntities context = new DL_EF.AGarciaGMEntities())
                {
                    var query = context.MateriaGetAll().ToList();

                    result.Objects = new List<object>();

                    if(query != null)
                    {
                        foreach(var obj in query)
                        {
                            ML.Materia materia = new ML.Materia();
                            materia.Nombre = obj.Nombre;
                            materia.Creditos = obj.Creditos.Value;
                            materia.Costo = obj.Costo.Value;

                            materia.Semestre = new ML.Semestre();
                            materia.Semestre.IdSemestre = obj.IdSemestre.Value;

                            result.Objects.Add(materia);
                        }
                        result.Correct = true;
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;   
            }
            return result;
        }

    }
}
