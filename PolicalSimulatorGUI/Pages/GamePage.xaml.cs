using PoliticalSimulatorCore.Model;
using PoliticalSimulatorGUI.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using PoliticalSimulatorCore.Controller;

namespace PoliticalSimulatorGUI {
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

            // Set player images.
            BitmapImage image = new BitmapImage(new Uri(players[0].Profile.PlayerImagePath, UriKind.Relative));
            PlayerOneIcon.Source = image;
            image = new BitmapImage(new Uri(players[1].Profile.PlayerImagePath, UriKind.Relative));
            PlayerTwoIcon.Source = image;

            // For testing
            players[0].Hand.Add(AllCards.getInstance().GetAllCards()[0]);
            playerTwoField.Children.Add(new FieldUIControl(AllCards.getInstance().GetAllCards()[0], FieldUIDropCallback));

            StartGame();
        }

        #region Private Methods

        private void StartGame() {
            if (controller.CurrentPlayerTurn == 0) {
                UpdateHand(controller.CurrentPlayer, playerOneHand);
            } else {
                UpdateHand(controller.CurrentPlayer, playerTwoHand);
            }
        }

        private void UpdateHand(Player player, StackPanel hand) {
            hand.Children.Clear();
            foreach (Card card in player.Hand) {
                hand.Children.Add(new CardUIControl(card));
            }
        }

        #endregion

        #region Drag Drop Events

        /// <summary>
        /// Handles the DragEnter event of the Field control.
        /// Associated with Field_Drop.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DragEventArgs"/> instance containing the event data.</param>
        private void Field_DragEnter(object sender, DragEventArgs e) {
            e.Effects = e.AllowedEffects;
        }

        /// <summary>
        /// Handles the Drop event of the Field control.
        /// Plays a card onto the <see cref="Player"/> <see cref="Field"/> from the <see cref="Hand"/>
        /// utilizing the <see cref="GameController"/> PlayCard method. If successful, the <see cref="Card"/>
        /// is removed from the hand <see cref="StackPanel"/> and is added to the field <see cref="StackPanel"/>.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DragEventArgs"/> instance containing the event data.</param>
        private void Field_Drop(object sender, DragEventArgs e) {

            if (e.Data.GetDataPresent(CardUIControl.DRAG_NAME)) {

                CardUIControl cardUiControl = (CardUIControl)e.Data.GetData(CardUIControl.DRAG_NAME);

                if(GameController.PlayCard(controller.CurrentPlayer, cardUiControl.Card)) {
                    ((StackPanel)cardUiControl.Parent).Children.Remove(cardUiControl);
                    ((StackPanel)sender).Children.Add(new FieldUIControl(cardUiControl.Card, FieldUIDropCallback));
                }
            }
            e.Handled = true;
        }

        #endregion

        #region Actions

        /// <summary>
        /// Callback method for when a <see cref="FieldUIControl"/> is dropped onto another.
        /// Attacks the calling <see cref="FieldUIControl"/> with the dropped one, utilizing the
        /// Attack method in the <see cref="GameController"/>.
        /// </summary>
        /// <param name="calling">The calling.</param>
        /// <param name="dropped">The dropped.</param>
        private void FieldUIDropCallback(FieldUIControl calling, FieldUIControl dropped) {

            Field attackedField;

            if (controller.CurrentPlayerTurn == 0) {
                attackedField = controller.Players[1].Field;
            } else {
                attackedField = controller.Players[0].Field;
            }

            if (GameController.Attack(controller.CurrentPlayer, dropped.Card as Creature, calling.Card as Creature, attackedField)) {
                ((StackPanel)calling.Parent).Children.Remove(calling);
            }
        }

        #endregion

        #region Obsolete

        [Obsolete]
        private void SetupGrids() {
            // Setup fields.
            // Create Columns and add to grid based on max field size.
            for (int i = 0; i < GameController.MAX_FIELD_SIZE; i++) {
                //playerOneField.ColumnDefinitions.Add(new ColumnDefinition());
                //playerTwoField.ColumnDefinitions.Add(new ColumnDefinition());
            }
            // Setup hands.
            // Create Columns and add to grid based on max hand size.
            for (int i = 0; i < GameController.MAX_HAND_SIZE; i++) {
                //playerOneHand.ColumnDefinitions.Add(new ColumnDefinition());
                //playerTwoField.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        [Obsolete]
        private void UpdateHand(Player player, Grid hand) {
            hand.Children.Clear();
            CardUIControl cardUI;
            for (int i = 0; i < player.Hand.Count; i++) {
                cardUI = new CardUIControl(player.Hand[i]);
                Grid.SetColumn(cardUI, i);
                hand.Children.Add(cardUI);
            }
        }

        #endregion

    }
}
