using PoliticalSimulatorCore.Model;
using PoliticalSimulatorGUI.Pages;
using System.Linq;
using System.Windows;

namespace PoliticalSimulatorGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public enum MainDisplay{
            LoginPage, HomePage, Game, EditDeck, Store, CreateProfile
        }

        private static MainWindow instance;

        private LoginPage loginPage = new LoginPage();
        private HomePage homePage = new HomePage();
        private StorePage store = new StorePage();
        private EditDeckPage editDeckPage = new EditDeckPage();

        public MainWindow()
        {
            instance = this;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            FrameworkElement.StyleProperty.OverrideMetadata(typeof(Window), new FrameworkPropertyMetadata
            {
                DefaultValue = FindResource(typeof(Window))
            });
            MainFrame.Content = loginPage;
        }

        public static MainWindow GetInstance()
        {
            if(instance == null)
            {
                //This should never happen.
                instance = new MainWindow();
            }
            return instance;
        }

        public void SwapPage(MainDisplay pageToDisplay, params object[] additionalParams)
        {
            switch (pageToDisplay)
            {
                case MainDisplay.CreateProfile:
                    break;

                case MainDisplay.EditDeck:
                    MainFrame.Content = editDeckPage;
                    break;

                case MainDisplay.Game:

                    Player[] players = new Player[additionalParams.Length];
                    for (int i = 0; i < additionalParams.Length; i++) {
                        players[i] = additionalParams[i] as Player;
                    }
                    
                    MainFrame.Content = new GamePage(players);
                    this.WindowState = System.Windows.WindowState.Maximized;
                    break;

                case MainDisplay.LoginPage:
                    MainFrame.Content = loginPage;
                    break;

                case MainDisplay.HomePage:
                    MainFrame.Content = homePage;
                    break;

                case MainDisplay.Store:
                    store.UpdateGUI();
                    MainFrame.Content = store;
                    break;

                default:
                    break;
            }
        }

    }
}
