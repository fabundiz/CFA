using CfaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CfaAPI.IServices
{
    public interface IAutorizacionesService
    {

        List<Autorizaciones> Gets( int ClaTrabajadorSesion, int ClaUsuarioMod, string IdToken, string txtBuscar, string NombrePcMod, string Idioma );

    }
}
