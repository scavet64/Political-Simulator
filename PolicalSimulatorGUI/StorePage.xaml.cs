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

        private string numberOfPacksLabel;

        public string NumberOfPacksLabel
        {
            get { return numberOfPacksLabel; }
            set { numberOfPacksLabel = value; }
        }


        public StorePage()
        {
            InitializeComponent();
            DataContext = this;
            WrapPanel.Children.Add(new CardUIControl(AllCards.getInstance().GetAllCards()[0]));
            WrapPanel.Children.Add(new CardUIControl(AllCards.getInstance().GetAllCards()[0]));
            WrapPanel.Children.Add(new CardUIControl(AllCards.getInstance().GetAllCards()[0]));
            WrapPanel.Children.Add(new CardUIControl(AllCards.getInstance().GetAllCards()[0]));
            WrapPanel.Children.Add(new CardUIControl(AllCards.getInstance().GetAllCards()[0]));
        }

        public void UpdateGUI()
        {
            CreditsLabelValue = string.Format("You have {0} credits!", MainController.CurrentUserProfile.Credits);
            NumberOfPacksLabel = string.Format("You have {0} packs!", MainController.CurrentUserProfile.Packs.Count);
        }

        private void BuyPackButton_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Button)
            {
                Button senderButton = (Button)sender;
                ButtonTagObject extract = new ButtonTagObject((string)senderButton.Tag);

                if(MainController.CurrentUserProfile.Credits < extract.TotalCost)
                {
                    MainController.CurrentUserProfile.purchasePacks(extract.NumberOfPacks, extract.TotalCost);
                }
                else
                {
                    //cannot buy, show an error
                }
            }
        }

        private void OpenPackButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LeaveStoreButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.GetInstance().SwapPage(MainWindow.MainDisplay.HomePage);
        }

        private class ButtonTagObject
        {
            public int NumberOfPacks { get; set; }
            public int TotalCost { get; set; }

            public ButtonTagObject(string tagString)
            {
                string[] elements = tagString.Split('|');

                this.NumberOfPacks = int.Parse(elements[0]);
                this.TotalCost = int.Parse(elements[1]);
            }
        }
    }
}
