using CfaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CfaAPI.IServices
{
    public interface ILoginService
    {
        Login Get(string Login, string Password, int Idioma);

    }
}
