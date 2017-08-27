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

        private Card card;

        public Card Card
        {
            get { return card; }
            set { card = value; }
        }


        private string source;

        public string Source
        {
            get { return source; }
            set { source = value; }
        }

        public CardUIControl(string ImageSource)
        {
            this.Source = ImageSource;
            InitializeComponent();
            DataContext = this;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataObject data = new DataObject();
            data.SetData("object", this);
            data.SetData("ParentElement", this.Parent);
            DragDropEffects effects = DragDrop.DoDragDrop(this, data, DragDropEffects.Move);
            if(effects == DragDropEffects.Move)
            {
                //There has to be a better way to do this
                //GamePage.bottomStack.Remove(this);
            }
        }
    }
}
