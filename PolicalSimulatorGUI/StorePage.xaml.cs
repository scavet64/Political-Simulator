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
    /// Interaction logic for StorePage.xaml
    /// </summary>
    public partial class StorePage : Page
    {

        private string creditsLabelValue;

        public string CreditsLabelValue
        {
            get { return creditsLabelValue; }
            set { creditsLabelValue = value; }
        }

        public StorePage()
        {
            InitializeComponent();
        }

        private void BuyPackButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OpenPackButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LeaveStoreButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.GetInstance().SwapPage(MainWindow.MainDisplay.HomePage);
        }
    }
}
