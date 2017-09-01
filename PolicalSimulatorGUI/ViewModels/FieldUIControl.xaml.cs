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

namespace PoliticalSimulatorGUI.ViewModels
{
    /// <summary>
    /// Interaction logic for FieldUIControl.xaml
    /// MouseDown="Image_MouseDown" MouseEnter="Imageimage_MouseEnter" MouseLeave="Imageimage_MouseLeave
    /// </summary>
    public partial class FieldUIControl : UserControl
    {
        public Card Card { get; set; }

        public FieldUIControl()
        {
            InitializeComponent();
        }

        public FieldUIControl(Card card)
        {
            InitializeComponent();
            this.Card = card;
            DataContext = card;
        }
    }
}
