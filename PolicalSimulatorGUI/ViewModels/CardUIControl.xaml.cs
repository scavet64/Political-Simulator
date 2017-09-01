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

        private bool hasBeenPlayed = false;

        private Card card;

        public Card Card
        {
            get { return card; }
            set { card = value; }
        }

        public CardUIControl(Card card)
        {
            InitializeComponent();
            this.BorderThickness = new Thickness(1);
            Card = card;
            DataContext = card;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataObject data = new DataObject();
            data.SetData("object", this);
            data.SetData("ParentElement", this.Parent);
            DragDropEffects effects = DragDrop.DoDragDrop(this, data, DragDropEffects.Move);
            if(effects == DragDropEffects.Move)
            {
                hasBeenPlayed = true;
            }
        }

        private void Imageimage_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!hasBeenPlayed)
            {
                this.BorderBrush = Brushes.Aqua;
            }
            
        }

        private void Imageimage_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!hasBeenPlayed)
            {
                this.BorderBrush = Brushes.Transparent;
            }
        }
    }
}
