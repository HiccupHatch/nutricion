using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ServicioRest5.Areas.Api.Models
{
    public class UsuarioManager
    {
        private static string cadenaConexion =
            @"Server=LAPTOP-V8VFEUF2;Initial Catalog=BDNutricion;Integrated Security=True";

        //public bool InsertarCliente(Cliente cli)
        //{
        //    SqlConnection con = new SqlConnection(cadenaConexion);

        //    con.Open();

        //    string sql = "INSERT INTO Clientes (Nombre, Telefono) VALUES (@nombre, @telefono)";

        //    SqlCommand cmd = new SqlCommand(sql, con);

        //    cmd.Parameters.Add("@nombre", System.Data.SqlDbType.NVarChar).Value = cli.Nombre;
        //    cmd.Parameters.Add("@telefono", System.Data.SqlDbType.Int).Value = cli.Telefono;

        //    int res = cmd.ExecuteNonQuery();

        //    con.Close();

        //    return (res == 1);
        //}

        //public bool ActualizarCliente(Cliente cli)
        //{
        //    SqlConnection con = new SqlConnection(cadenaConexion);

        //    con.Open();

        //    string sql = "UPDATE Clientes SET Nombre = @nombre, Telefono = @telefono WHERE IdCliente = @idcliente";

        //    SqlCommand cmd = new SqlCommand(sql, con);

        //    cmd.Parameters.Add("@nombre", System.Data.SqlDbType.NVarChar).Value = cli.Nombre;
        //    cmd.Parameters.Add("@telefono", System.Data.SqlDbType.Int).Value = cli.Telefono;
        //    cmd.Parameters.Add("@idcliente", System.Data.SqlDbType.Int).Value = cli.Id;

        //    int res = cmd.ExecuteNonQuery();

        //    con.Close();

        //    return (res == 1);
        //}

        public Usuario ObtenerUsuario(string email){
            Usuario usu = null;

            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();

            string sql = "SELECT * FROM Usuarios WHERE email = @email";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@email", System.Data.SqlDbType.VarChar).Value = email;
            SqlDataReader reader =
                 cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);


            if (reader.Read())
            {
                usu = new Usuario();
                usu.email = email;
                usu.password = reader.GetString(1);
                //usu.foto = reader.GetString(2);
            }

            reader.Close();

            return usu;
        }

        public Usuario Login(string email, string password)
        {
            Usuario usu = ObtenerUsuario(email);
            System.Diagnostics.Debug.WriteLine(email + password);
            if (usu.password == password)
            {
                usu.password = null;
                return usu;
            }
            else
            {
                return null;
            }
        }

        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();

            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();

            string sql = "SELECT email, password, foto FROM Usuarios";

            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader reader =
                cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                Usuario usu = new Usuario();

                usu = new Usuario();
                usu.email = reader.GetString(0);
                usu.password = reader.GetString(1);
                //usu.foto = reader.GetString(2);

                lista.Add(usu);
            }

            reader.Close();

            return lista;
        }

        public bool EliminarCliente(int id)
        {
            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();

            string sql = "DELETE FROM Clientes WHERE IdCliente = @idcliente";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@idcliente", System.Data.SqlDbType.Int).Value = id;

            int res = cmd.ExecuteNonQuery();

            con.Close();

            return (res == 1);
        }
    }
}