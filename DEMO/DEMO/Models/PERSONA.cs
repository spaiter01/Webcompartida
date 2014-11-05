using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DEMO.Models
{
       //[MetadataType(typeof(PERSONA))]
    public class PERSONA
    {
        public int ID { get; set; }

        //[StringLength(5), Required]
        public string NOMBRES { get; set; }

        //[StringLength(6)]
        public string APELLIDOS { get; set; }

        //[DisplayName("Fecha de Nacimiento"), Required(ErrorMessage = "Debe ingresar su fecha de nacimiento.")]

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Fecha de Nacimiento"), Required(ErrorMessage = "Debe ingresar su fecha de nacimiento.")]
        public DateTime FECHA { get; set; }

        public string CodDep { get; set; }
        public string CodProv { get; set; }
        public string CodDist { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }


    }
}