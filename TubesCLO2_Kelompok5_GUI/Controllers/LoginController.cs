using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TubesCLO2_Kelompok5_GUI.Models;

namespace TubesCLO2_Kelompok5_GUI.Controllers
{
    public class LoginController
    {
        private readonly User _staticUser = new User { Username = "admin", Password = "password" };

        public bool ValidateLogin(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }
            return username == _staticUser.Username && password == _staticUser.Password;
        }
    }
}
