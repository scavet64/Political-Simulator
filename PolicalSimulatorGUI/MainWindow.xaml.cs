﻿using PoliticalSimulatorCore.Model;
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
                    break;
                case MainDisplay.Game:
                    MainFrame.Content = new GamePage();
                    this.WindowState = System.Windows.WindowState.Maximized;
                    break;
                case MainDisplay.LoginPage:
                    MainFrame.Content = loginPage;
                    break;
                case MainDisplay.HomePage:
                    if (additionalParams.Length > 0 && additionalParams[0] is UserProfile)
                    {
                        homePage.SetActiveProfile((UserProfile)additionalParams[0]);
                        MainFrame.Content = homePage;
                    }
                    break;
                case MainDisplay.Store:
                    break;
                default:
                    break;
            }
        }

    }
}
