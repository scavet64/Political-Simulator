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
using PoliticalSimulatorCore.Model;
using PoliticalSimulatorCore.Controller;

namespace PoliticalSimulatorGUI.ViewModels
{
    /// <summary>
    /// Interaction logic for FieldUIControl.xaml
    /// MouseDown="Image_MouseDown" MouseEnter="Imageimage_MouseEnter" MouseLeave="Imageimage_MouseLeave
    /// </summary>
    public partial class FieldUIControl : UserControl
    {

        public const string DRAG_NAME = "FieldUIControl";

        public Card Card { get; set; }

        private Action<FieldUIControl, FieldUIControl> dropCallback;

        [Obsolete]
        public FieldUIControl()
        {
            InitializeComponent();
        }

        [Obsolete]
        public FieldUIControl(Card card)
        {
            InitializeComponent();
            this.Card = card;
            DataContext = card;
        }

        public FieldUIControl(Card card, Action<FieldUIControl, FieldUIControl> dropCallback) {
            InitializeComponent();
            this.Card = card;
            BorderThickness = new Thickness(1);
            DataContext = card;
            this.dropCallback = dropCallback;
        }

        #region Drag Drop Events

        /// <summary>
        /// Handles the DragEnter event of the Cardback control.
        /// Associated with Cardback_Drop.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DragEventArgs"/> instance containing the event data.</param>
        private void Cardback_DragEnter(object sender, DragEventArgs e) {
            e.Effects = e.AllowedEffects;
        }

        /// <summary>
        /// Handles the Drop event of the Cardback control.
        /// Passes this <see cref="FieldUIControl"/> and the dropped <see cref="FieldUIControl"/> to the callback <see cref="Action"/> .
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DragEventArgs"/> instance containing the event data.</param>
        private void Cardback_Drop(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(FieldUIControl.DRAG_NAME)) {
                FieldUIControl fieldUiControl = (FieldUIControl)e.Data.GetData(FieldUIControl.DRAG_NAME);
                dropCallback(this, fieldUiControl);
            }
            e.Handled = true;
        }

        private void Cardback_MouseDown(object sender, MouseButtonEventArgs e) {
            DataObject data = new DataObject();
            data.SetData(DRAG_NAME, this);
            DragDropEffects effects = DragDrop.DoDragDrop(this, data, DragDropEffects.Move);
        }

        #endregion

        private void Cardback_MouseEnter(object sender, MouseEventArgs e) {
            BorderBrush = Brushes.Aqua;
        }

        private void Cardback_MouseLeave(object sender, MouseEventArgs e) {
            BorderBrush = Brushes.Transparent;
        }
    }
}
