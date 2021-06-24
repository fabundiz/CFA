using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CfaAPI.Models
{
    public class Login
    {

        public int IdUsuario { get; set; }
        public string Mensaje { get; set; }
        public int ClaUbicacionDefault { get; set; }
        public int ClaEmpresa { get; set; }
        public int IntentosFallidos { get; set; }
        public int ReintentosMaximos { get; set; }
     }
}
