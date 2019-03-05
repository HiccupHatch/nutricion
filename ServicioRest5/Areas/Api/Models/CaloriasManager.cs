using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ServicioRest5.Areas.Api.Models
{
    public class CaloriasManager
    {
        private static string cadenaConexion =
             @"Server=LAPTOP-V8VFEUF2;Initial Catalog=BDNutricion;Integrated Security=True";
        private static string tabla = "Calorias";

        public bool InsertarCalorias(Calorias cal)
        {
            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();

            string sql = "INSERT INTO " + tabla + " (email, fecha, tipoComida, codigoAlimento, cantidad) VALUES (@email, @telfechaefono, @tipoComida, @codigoAlimento, @cantidad)";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = cal.email;
            cmd.Parameters.Add("@fecha", System.Data.SqlDbType.NVarChar).Value = cal.fecha;
            cmd.Parameters.Add("@tipoComida", System.Data.SqlDbType.Char).Value = cal.tipoComida;
            cmd.Parameters.Add("@codigoAlimento", System.Data.SqlDbType.Int).Value = cal.codigoAlimento;
            cmd.Parameters.Add("@cantidad", System.Data.SqlDbType.Int).Value = cal.cantidad;

            int res = cmd.ExecuteNonQuery();

            con.Close();

            return (res == 1);
        }

        public bool ActualizarCalorias(Calorias calAnt, Calorias calNuev)
        {
            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();

            string sql = "UPDATE " + tabla + " SET fecha = @fechaNuev, tipoComida = @tipoComidaNuev, codigoAlimento = @codigoAlimentoNuev, cantidad = @cantidadNuev";
            string where = "WHERE email = @email and fecha = @fechaAnt and tipoComida = @tipoComidaAnt and codigoAlimento = @codigoAlimentoAnt and cantidadAnt = @cantidadAnt";
            sql = sql +" "+ where;
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@fechaNuev", System.Data.SqlDbType.NVarChar).Value = calNuev.fecha;
            cmd.Parameters.Add("@tipoComidaNuev", System.Data.SqlDbType.Char).Value = calNuev.tipoComida;
            cmd.Parameters.Add("@codigoAlimentoNuev", System.Data.SqlDbType.Int).Value = calNuev.codigoAlimento;
            cmd.Parameters.Add("@cantidadNuev", System.Data.SqlDbType.Int).Value = calNuev.cantidad;

            //
            cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = calAnt.email;
            cmd.Parameters.Add("@fechaAnt", System.Data.SqlDbType.NVarChar).Value = calAnt.fecha;
            cmd.Parameters.Add("@tipoComidaAnt", System.Data.SqlDbType.Char).Value = calAnt.tipoComida;
            cmd.Parameters.Add("@codigoAlimentoAnt", System.Data.SqlDbType.Int).Value = calAnt.codigoAlimento;
            cmd.Parameters.Add("@cantidadAnt", System.Data.SqlDbType.Int).Value = calAnt.cantidad;

            int res = cmd.ExecuteNonQuery();

            con.Close();

            return (res == 1);
        }

        public Calorias ObtenerCaloriasUno(string email, string fecha, char tipoComida, int codigoAlimento)
        {
            Calorias cal = null;

            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();

            string sql = "SELECT cantidad FROM"+ tabla + "WHERE email = @email and fecha = @fecha and tipoComida = @tipoComida and codigoAlimento = @codigoAlimento";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = email;
            cmd.Parameters.Add("@fecha", System.Data.SqlDbType.NVarChar).Value = fecha;
            cmd.Parameters.Add("@tipoComida", System.Data.SqlDbType.Char).Value = tipoComida;
            cmd.Parameters.Add("@codigoAlimento", System.Data.SqlDbType.Int).Value = codigoAlimento;
            
            SqlDataReader reader =
                 cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);


            if (reader.Read())
            {
                cal = new Calorias();
                cal.email = email;
                cal.fecha = fecha;
                cal.tipoComida = tipoComida;
                cal.codigoAlimento = codigoAlimento;
                cal.cantidad = reader.GetInt32(0);
            }

            reader.Close();

            return cal;
        }

        public List<Calorias> ObtenerCaloriases()
        {
            List<Calorias> lista = new List<Calorias>();

            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();

            string sql = "SELECT * FROM " + tabla + "";

            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader reader =
                cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                Calorias cal = new Calorias();

                cal = new Calorias();
                cal.email = reader.GetString(0);
                cal.fecha = reader.GetString(1);
                cal.tipoComida = reader.GetChar(2);
                cal.codigoAlimento = reader.GetInt32(3);
                cal.cantidad = reader.GetInt32(4);

                lista.Add(cal);
            }

            reader.Close();

            return lista;
        }

        public bool EliminarCalorias(string email, string fecha, char tipoComida, int codigoAlimento)
        {
            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();

            string sql = "DELETE FROM " + tabla + " WHERE email = @email and fecha = @fecha and tipoComida = @tipoComida and codigoAlimento = @codigoAlimento";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = email;
            cmd.Parameters.Add("@fecha", System.Data.SqlDbType.NVarChar).Value = fecha;
            cmd.Parameters.Add("@tipoComida", System.Data.SqlDbType.Char).Value = tipoComida;
            cmd.Parameters.Add("@codigoAlimento", System.Data.SqlDbType.Int).Value = codigoAlimento;

            int res = cmd.ExecuteNonQuery();

            con.Close();

            return (res == 1);
        }
    }
}