using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticalSimulatorCore.CustomExceptions
{
    class ProfileNotFoundException: Exception
    {
        private const long serialVersionUID = 1L;
        private String profileNotFound;
        private DateTime dateNotFound;

        /**
         * default constructor for the exception
         * @param profileNotFound profile name that could not be found
         * @param dateNotFound date and time the profile could not be loaded
         */
        public ProfileNotFoundException(String profileNotFound, DateTime dateNotFound)
        {
            this.profileNotFound = profileNotFound;
            this.dateNotFound = dateNotFound;
        }

        public override string ToString()
        {
            return profileNotFound + " could not be located.\nError Time: " + dateNotFound;
        }
    }
}
