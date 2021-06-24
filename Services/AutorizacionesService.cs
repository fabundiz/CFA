using CfaAPI.Common;
using CfaAPI.IServices;
using CfaAPI.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CfaAPI.Services
{
    public class AutorizacionesService : IAutorizacionesService
    {
        Autorizaciones _oAutorizacion = new Autorizaciones();
        List<Autorizaciones> _oAutorizaciones = new List<Autorizaciones>();


        public List<Autorizaciones> Gets(int ClaTrabajadorSesion, int ClaUsuarioMod, string IdToken, string txtBuscar, string NombrePcMod, string Idioma)
        {

            _oAutorizaciones = new List<Autorizaciones>();


            try {

                int operationType = Convert.ToInt32(OperationType.None);

                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) { con.Open(); }

                    var oAutorizaciones = con.Query<Autorizaciones>("CFASch.CFA_CU400_Pag20_Grid_Tramites_Sel",
                        this.SetParameters(ClaTrabajadorSesion, ClaUsuarioMod, IdToken, txtBuscar, NombrePcMod, Idioma, operationType),
                        commandType: CommandType.StoredProcedure);

                    if (oAutorizaciones != null && oAutorizaciones.Count() > 0) {
                        _oAutorizaciones = oAutorizaciones.ToList();                    
                    }
                }
                

            }

            catch (Exception ex){

                ex.Message.ToString();
            }


            return _oAutorizaciones;

        }


        private DynamicParameters SetParameters(int ClaTrabajadorSesion, int ClaUsuarioMod, string IdToken, string txtBuscar, string NombrePcMod, string Idioma, int operationType)
        { 
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@pnClaTrabajadorSesion", ClaTrabajadorSesion);
            parameters.Add("@pnClaUsuarioMod", ClaUsuarioMod);
            parameters.Add("@psIdToken", IdToken);
            parameters.Add("@pstxtBuscar", txtBuscar);
            parameters.Add("@psNombrePcMod", NombrePcMod);
            parameters.Add("@psIdioma", Idioma);

            return parameters;

        }

    }
}
