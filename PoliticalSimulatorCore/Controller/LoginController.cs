using PoliticalSimulatorCore.CustomExceptions;
using PoliticalSimulatorCore.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace PoliticalSimulatorCore.Controller
{
    public static class LoginController
    {

        public static UserProfile ActiveProfile { get; set; }

        /**
	     * Load the profile with the given string. Throw a ProfileNotFoundException 
	     * if the profile file could not be found.
	     * @param profileToLoad The profile to load
	     * @return The loaded UserProfile
	     * @throws ProfileNotFoundException
	     * @throws ClassNotFoundException
	     */
        public static UserProfile loadProfile(String profileToLoad)
        {
            UserProfile profile;
            //load profile.dat
            try
            {
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream("Profiles\\" + profileToLoad + ".dat", FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    profile = (UserProfile)formatter.Deserialize(stream);
                }

                return profile;

            }
            catch (IOException e)
            {
                throw new ProfileNotFoundException(profileToLoad, DateTime.Now);
            }
        }

        /**
         * Save the given profile.
         * @param profileToSave The UserProfile to save to a file
         * @return true if save was succesful, false if not
         */
        public static bool saveProfile(UserProfile profileToSave)
        {
            //create the folder if it does not exist already
            if (!Directory.Exists("Profiles"))
            {
                Directory.CreateDirectory("Profiles");
            }

            try
            {
                using (Stream stream = new FileStream("Profiles\\" + profileToSave.getName() + ".dat", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, profileToSave);
                }
            }
            catch (IOException ex)
            {
                //Logit
                return false;
            }

            return true;
        }

        /**
         * Create a UserProfile with the given String
         * @param name Name of UserProfile to create
         */
        public static void createProfile(String name)
        {
            UserProfile newUser = new UserProfile(name);
            ActiveProfile = newUser;
            saveProfile(newUser);
        }

        /**
         * Delete a UserProfile with the given String
         * @param profileToDelete Name of UserProfile to delete
         */
        public static void DeleteProfile(String profileToDelete)
        {
            if (File.Exists("Profiles\\" + profileToDelete + ".dat"))
            {
                File.Delete("Profiles\\" + profileToDelete + ".dat");
            }
        }

        /**
         * Save the active profile.
         */
        public static void saveActiveProfile()
        {
            saveProfile(ActiveProfile);
        }
    }
}
