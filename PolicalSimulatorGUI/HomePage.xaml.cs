using PoliticalSimulatorCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        public void SetActiveProfile(UserProfile activeProfile)
        {

        }

        private void SingleplayerButton_Click(object sender, RoutedEventArgs e)
        {
            //This will need to do a lot more eventually.
            MainWindow.GetInstance().SwapPage(MainWindow.MainDisplay.Game);
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
