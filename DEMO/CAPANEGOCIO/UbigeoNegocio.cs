using ACCESODATOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPANEGOCIO
{
   public  class UbigeoNegocio
    {
        UbigeoDato Dat = new UbigeoDato();
        public DataTable Listar()
        {
            return Dat.Listar();
        }
        public DataTable BuscarProvincias(string idDepartamento)
        {
            return Dat.BuscarProvincias(idDepartamento);
        }

        public DataTable BuscarDistritos(string idDepartamento, string idProvincia)
        {
            return Dat.BuscarDistritos(idDepartamento, idProvincia);
        }

    }
}
