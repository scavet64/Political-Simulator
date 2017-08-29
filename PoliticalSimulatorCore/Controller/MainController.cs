using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoliticalSimulatorCore.Model;

namespace PoliticalSimulatorCore.Controller
{
    public static class MainController
    {

        private static UserProfile currentUserProfile;

        public static UserProfile CurrentUserProfile
        {
            get { return currentUserProfile; }
            set { currentUserProfile = value; }
        }



    }
}
