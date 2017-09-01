using PoliticalSimulatorCore.Controller;
using PoliticalSimulatorCore.CustomExceptions;
using PoliticalSimulatorCore.Model;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PoliticalSimulatorGUI.Pages
{
    /// <summary>
    /// Interaction logic for EditDeckPage.xaml
    /// </summary>
    public partial class EditDeckPage : Page
    {

        public EditDeckPage()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            CardsCollectedDataGrid.ItemsSource = MainController.CurrentUserProfile.CollectedCards;
            CardsInDeckDataGrid.ItemsSource = MainController.CurrentUserProfile.CurrentDeck.cardList;
            var firstCol = CardsCollectedDataGrid.Columns.First();
            firstCol.SortDirection = ListSortDirection.Ascending;
            CardsCollectedDataGrid.Items.SortDescriptions.Add(new SortDescription(firstCol.SortMemberPath, ListSortDirection.Ascending));
        }

        private void CardsCollectedDataGrid_Selected(object sender, RoutedEventArgs e)
        {

            if(sender is DataGrid)
            {
                DataGrid dg = (DataGrid)sender;
                Card card = (Card)dg.SelectedCells;
                CardUIBorder.Child = new CardUIControl(card);
            }
        }

        private void CardsCollectedDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender is DataGrid)
                {
                    DataGrid dg = (DataGrid)sender;
                    Card card = (Card)dg.SelectedItem;
                    CardUIBorder.Child = new CardUIControl(card);
                }
            }
            catch(Exception ex)
            {
                //TODO:
                //log
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Card card = (Card)CardsCollectedDataGrid.SelectedItem;
                MainController.CurrentUserProfile.CurrentDeck.addCard(card);
                CardsInDeckDataGrid.Items.Refresh();
            }
            catch(DeckFullException dfe)
            {
                //TODO:
                //log this
            }
        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.GetInstance().SwapPage(MainWindow.MainDisplay.HomePage);
        }
    }
}
