using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ServicioRest5.Areas.Api.Models
{
    public class AlimentoManager
    {
        private static string cadenaConexion =
            @"Server=LAPTOP-V8VFEUF2;Initial Catalog=BDNutricion;Integrated Security=True";

        public Alimento ObtenerAlimento(int codigo)
        {
            Alimento ali = null;

            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();

            string sql = "SELECT * FROM Alimentos WHERE codigo = @codigo";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@codigo", System.Data.SqlDbType.Int).Value = codigo;
            SqlDataReader reader =
                 cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);


            if (reader.Read())
            {
                ali = new Alimento();
                ali.codigo = codigo;
                ali.descripcion = reader.GetString(1);
                ali.calorias = reader.GetInt32(2);
            }

            reader.Close();

            return ali;
        }

        public List<Alimento> ObtenerAlimentos()
        {
            List<Alimento> lista = new List<Alimento>();

            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();

            string sql = "SELECT codigo, descripcion, calorias FROM Alimentos";

            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader reader =
                cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                Alimento ali = new Alimento();

                ali = new Alimento();
                ali.codigo = reader.GetInt32(0);
                ali.descripcion = reader.GetString(1);
                ali.calorias = reader.GetInt32(2);

                lista.Add(ali);
            }

            reader.Close();

            return lista;
        }
    }
}