using PoliticalSimulatorCore.AI;
using PoliticalSimulatorCore.Controller;
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
            Player user = new Player(MainController.CurrentUserProfile, GameController.MAX_FIELD_SIZE, GameController.MAX_HAND_SIZE, GameController.START_HEALTH);
            Player ai = new AIPlayer(GameController.MAX_FIELD_SIZE, GameController.MAX_HAND_SIZE, GameController.START_HEALTH);

            MainWindow.GetInstance().SwapPage(MainWindow.MainDisplay.Game, user, ai);
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            LoginController.saveActiveProfile();
            Environment.Exit(0);
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginController.saveActiveProfile();
            MainWindow.GetInstance().SwapPage(MainWindow.MainDisplay.LoginPage);
        }

        private void StoreButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.GetInstance().SwapPage(MainWindow.MainDisplay.Store);
        }

        private void EditDeckButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.GetInstance().SwapPage(MainWindow.MainDisplay.EditDeck);
        }
    }
}
