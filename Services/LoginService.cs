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
    public class LoginService : ILoginService
    {

        Login _oLogin = new Login();

        public Login Get(string Login, string Password, int Idioma)
        {
            _oLogin = new Login();

            try
            {

                
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) { con.Open(); }

                    var oLogin = con.Query<Login>("CFASch.CfaAppLogin",
                        this.SetParameters(Login, Password, Idioma),
                        commandType: CommandType.StoredProcedure);

                    if (oLogin != null && oLogin.Count() > 0)
                    {
                        _oLogin = oLogin.SingleOrDefault();
                    }
                }


            }

            catch (Exception ex)
            {

                ex.Message.ToString();
            }


            return _oLogin;
        }

        private DynamicParameters SetParameters(string Login, string Password, int Idioma)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@psLogin", Login);
            parameters.Add("@psPassword", Password);
            parameters.Add("@pnIdioma", Idioma);

            return parameters;

        }

    }
}
