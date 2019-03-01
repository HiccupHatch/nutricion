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

        public bool ActualizarCalorias(Calorias cal)
        {
            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();

            string sql = "UPDATE " + tabla + " SET email = @email, fecha = @fecha, tipoComida = @tipoComida, codigoAlimento = @codigoAlimento WHERE IdCliente = @idcliente";

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

        public Cliente ObtenerCliente(int id)
        {
            Cliente cli = null;

            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();

            string sql = "SELECT Nombre, Telefono FROM"+ tabla +"WHERE IdCliente = @idcliente";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@idcliente", System.Data.SqlDbType.Int).Value = id;
            SqlDataReader reader =
                 cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);


            if (reader.Read())
            {
                cli = new Cliente();
                cli.Id = id;
                cli.Nombre = reader.GetString(0);
                cli.Telefono = reader.GetInt32(1);
            }

            reader.Close();

            return cli;
        }

        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> lista = new List<Cliente>();

            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();

            string sql = "SELECT IdCliente, Nombre, Telefono FROM " + tabla + "";

            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader reader =
                cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                Cliente cli = new Cliente();

                cli = new Cliente();
                cli.Id = reader.GetInt32(0);
                cli.Nombre = reader.GetString(1);
                cli.Telefono = reader.GetInt32(2);

                lista.Add(cli);
            }

            reader.Close();

            return lista;
        }

        public bool EliminarCliente(int id)
        {
            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();

            string sql = "DELETE FROM " + tabla + " WHERE IdCliente = @idcliente";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@idcliente", System.Data.SqlDbType.Int).Value = id;

            int res = cmd.ExecuteNonQuery();

            con.Close();

            return (res == 1);
        }
    }
}