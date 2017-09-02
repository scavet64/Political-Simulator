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
    /// Interaction logic for Card.xaml
    /// </summary>
    public partial class CardUIControl : UserControl
    {

        public const string DRAG_NAME = "CardUIControl";

        private Card card;
        public Card Card
        {
            get { return card; }
            set { card = value; }
        }

        public CardUIControl(Card card)
        {
            InitializeComponent();
            BorderThickness = new Thickness(1);
            Card = card;
            DataContext = card;
        }

        private void Cardback_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataObject data = new DataObject();
            data.SetData(DRAG_NAME, this);
            DragDropEffects effects = DragDrop.DoDragDrop(this, data, DragDropEffects.Move);
        }

        private void Cardback_MouseEnter(object sender, MouseEventArgs e)
        {
            BorderBrush = Brushes.Aqua;        
        }

        private void Cardback_MouseLeave(object sender, MouseEventArgs e)
        {
            BorderBrush = Brushes.Transparent;
        }
    }
}
