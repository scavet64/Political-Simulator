using PoliticalSimulatorCore.Model;
using PoliticalSimulatorGUI.ViewModels;
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
using PoliticalSimulatorCore.Controller;

namespace PoliticalSimulatorGUI
{
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        private GameController controller;

        public GamePage(params Player[] players)
        {
            InitializeComponent();

            controller = new GameController(players);

            // Currently only supports 2 players.
            // Setup fields.
            // Create Columns and add to grid based on max field size.
            for (int i = 0; i < GameController.MAX_FIELD_SIZE; i++) {
                playerOneField.ColumnDefinitions.Add(new ColumnDefinition());
                playerTwoField.ColumnDefinitions.Add(new ColumnDefinition());
            }
            // Setup hands.
            // Create Columns and add to grid based on max hand size.
            for (int i = 0; i < GameController.MAX_HAND_SIZE; i++) {
                playerOneHand.ColumnDefinitions.Add(new ColumnDefinition());
                playerTwoField.ColumnDefinitions.Add(new ColumnDefinition());
            }
            // Set player images.
            BitmapImage image = new BitmapImage(new Uri(players[0].Profile.PlayerImagePath, UriKind.Relative));
            PlayerOneIcon.Source = image;
            image = new BitmapImage(new Uri(players[1].Profile.PlayerImagePath, UriKind.Relative));
            PlayerTwoIcon.Source = image;

            // For testing... Add field cards
            playerOneField.Children.Add(new FieldUIControl(AllCards.getInstance().GetAllCards()[0]));

            StartTurn();
        }

        private void StartTurn() {
            if(controller.CurrentPlayerTurn == 0) {
                UpdateHand(controller.CurrentPlayer, playerOneHand);
            } else {
                UpdateHand(controller.CurrentPlayer, playerTwoHand);
            }
        }

        private void UpdateHand(Player player, Grid hand) {
            hand.Children.Clear();
            CardUIControl cardUI;
            for (int i = 0; i < player.Hand.Count; i++) {
                cardUI = new CardUIControl(player.Hand[i]);
                Grid.SetColumn(cardUI, i);
                hand.Children.Add(cardUI);
            }
        }

        private void FieldGrid_DragEnter(object sender, DragEventArgs e)
        {
            //e.Effects = DragDropEffects.All;
        }

        protected override void OnDrop(DragEventArgs e)
        {
            base.OnDrop(e);

            // If the DataObject contains string data, extract it.
            if (e.Data.GetDataPresent("object"))
            {
                CardUIControl cardUiControl = (CardUIControl)e.Data.GetData("object");

                // Set Effects to notify the drag source what effect
                // the drag-and-drop operation had.
                // (Copy if CTRL is pressed; otherwise, move.)
                if (e.KeyStates.HasFlag(DragDropKeyStates.ControlKey))
                {
                    e.Effects = DragDropEffects.Copy;
                }
                else
                {
                    e.Effects = DragDropEffects.Move;
                    ((StackPanel)e.Data.GetData("ParentElement")).Children.Remove(cardUiControl);
                    //Player1Field.Children.Add(new FieldUIControl(cardUiControl.Card));
                }
            }
            e.Handled = true;
        }

        private void FieldGrid_Drop(object sender, DragEventArgs e)
        {

        }
    }
}
