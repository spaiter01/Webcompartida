using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
namespace ACCESODATOS
{
    public class PERSONADATO
    {
        CONEXION cnn = new CONEXION();
        SqlCommand cmd = new SqlCommand();
        public bool insertar(string nom, string ape, DateTime fecha, string CodigoDepartamento, string CodigoProvincia, string CodigoDistrito)
        {
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertarPersona";
                cmd.Connection = cnn.cn;
                cmd.Parameters.Add(new SqlParameter("@Nombres", SqlDbType.VarChar, 50)).Value = nom;
                cmd.Parameters.Add(new SqlParameter("@Apellidos", SqlDbType.VarChar, 50)).Value = ape;
                cmd.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime)).Value = fecha;
                cmd.Parameters.Add(new SqlParameter("@CodigoDepartamento", SqlDbType.VarChar, 50)).Value = CodigoDepartamento;
                cmd.Parameters.Add(new SqlParameter("@CodigoProvincia", SqlDbType.VarChar, 50)).Value = CodigoProvincia;
                cmd.Parameters.Add(new SqlParameter("@CodigoDistrito", SqlDbType.VarChar, 50)).Value = CodigoDistrito;
                cnn.Conectar();
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                cnn.Desconectar();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }


        }
        public DataTable Listar()
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ListarPersona";
            cmd.Connection = cnn.cn;
            cnn.Conectar();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cnn.Desconectar();
            return dt;
        }

        public DataTable Buscar(int Cod)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "BuscarPersona";
            cmd.Connection = cnn.cn;
            cnn.Conectar();
            cmd.Parameters.Add(new SqlParameter("@cod", SqlDbType.Int)).Value = Cod;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);

            cnn.Desconectar();
            return dt;
        }
        public bool Actualizar(int Cod, string nom, string ape,DateTime fecha)
        {
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ActualizarPersona";
                cmd.Connection = cnn.cn;

                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar, 50)).Value = Cod;
                cmd.Parameters.Add(new SqlParameter("@Nombres", SqlDbType.VarChar, 50)).Value = nom;
                cmd.Parameters.Add(new SqlParameter("@Apellidos", SqlDbType.VarChar, 50)).Value = ape;
                cmd.Parameters.Add(new SqlParameter("@Fecha", SqlDbType.DateTime)).Value = fecha;
                cnn.Conectar();
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                cnn.Desconectar();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }

        }

        public bool Eliminar(int Cod)
        {
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Eliminar";
                cmd.Connection = cnn.cn;
                cmd.Parameters.Add(new SqlParameter("@Cod", SqlDbType.VarChar, 50)).Value = Cod;
                cnn.Conectar();
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                cnn.Desconectar();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }


        }

        public DataTable Detalle(int Cod)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "BuscarPersona";
            cmd.Connection = cnn.cn;
            cnn.Conectar();
            cmd.Parameters.Add(new SqlParameter("@cod", SqlDbType.Int)).Value = Cod;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);

            cnn.Desconectar();
            return dt;
        }
    }
}
