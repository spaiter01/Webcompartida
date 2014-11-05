using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCESODATOS
{
   public  class UbigeoDato
    {
       CONEXION cnn = new CONEXION();
        SqlCommand cmd = new SqlCommand();
        public DataTable Listar()
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ListarDepartamentos";
            cmd.Connection = cnn.cn;
            cnn.Conectar();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cnn.Desconectar();
            return dt;
        }
        public DataTable BuscarProvincias(string idDepartamento)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "BuscarProvincias";
            cmd.Connection = cnn.cn;
            cnn.Conectar();
            cmd.Parameters.Add(new SqlParameter("@Cod", SqlDbType.NVarChar, 50)).Value = idDepartamento;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);

            cnn.Desconectar();
            return dt;
        }
        public DataTable BuscarDistritos(string idDepartamento, string idProvincia)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "BuscarDistrito";
            cmd.Connection = cnn.cn;
            cnn.Conectar();
            cmd.Parameters.Add(new SqlParameter("@CodDep", SqlDbType.NVarChar, 50)).Value = idDepartamento;
            cmd.Parameters.Add(new SqlParameter("@CodDist", SqlDbType.NVarChar, 50)).Value = idProvincia;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);

            cnn.Desconectar();
            return dt;
        }



    }
}

