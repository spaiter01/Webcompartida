using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ACCESODATOS;

using System.Data;
using System.Data.SqlClient;
namespace CAPANEGOCIO
{
   public  class PERSONANEGOCIO
    {
       PERSONADATO Dat = new PERSONADATO();

       public bool insertar(string nom, string ape,DateTime fecha,string CodigoDepartamento, string CodigoProvincia, string CodigoDistrito)

        {
            return Dat.insertar(nom,ape,fecha,CodigoDepartamento,CodigoProvincia,CodigoDistrito);
        }

        public DataTable Listar()
        {
            return Dat.Listar();
        }

         public DataTable Buscar(int Cod)
        {
            return Dat.Buscar(Cod);
        }
         public bool Actualizar(int Cod, string nom, string ape, DateTime fecha)
         {
             return Dat.Actualizar(Cod,nom,ape,fecha);
         }
         public bool Eliminar(int Cod)
         {
             return Dat.Eliminar (Cod);
         }
        public DataTable Detalle(int Cod)
         {
             return Dat.Detalle(Cod);
         }
    }
}
