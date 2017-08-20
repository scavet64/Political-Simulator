using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticalSimulatorCore.CustomExceptions
{
    class ImageNotFoundException
    {
        private const long serialVersionUID = 1L;
        private String fileName;
        private DateTime currentTime;

        /**
         * default constructor for the imageNotFoundException
         * @param fileName the filename that could not be loaded
         * @param currentTime the current date and time the file couldnt be loaded
         */
        public ImageNotFoundException(String fileName, DateTime currentTime)
        {
            this.fileName = fileName;
            this.currentTime = currentTime;
        }

        public override string ToString()
        {
            return "The image '" + fileName + "' was not found at " + currentTime;
        }
    }
}
