using PoliticalSimulatorCore.Controller;
using PoliticalSimulatorCore.Model;
using PoliticalSimulatorCore.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PoliticalSimulatorGUI
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {

        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                Login(ProfileNameBox.Text);
            });
        }

        private void CreateProfileClick(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                CreateProfile(ProfileNameBox.Text);
            });

        }

        private void CreateProfile(string ProfileName)
        {
            LoginController.createProfile(ProfileName);
            Login(ProfileName);
        }

        private static void Login(string ProfileToLoad)
        {
            try
            {
                UserProfile profile = LoginController.loadProfile(ProfileToLoad);
                if (profile != null)
                {
                    MainWindow.GetInstance().SwapPage(MainWindow.MainDisplay.HomePage, profile);
                }
            }
            catch (ProfileNotFoundException ex)
            {
                MessageBox.Show("Profile was not found");
            }
        }

        private bool ProfileExists()
        {
            throw new NotImplementedException();
        }
    }
}
