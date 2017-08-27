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
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {

        public static UIElementCollection bottomStack;

        public GamePage()
        {
            InitializeComponent();
            bottomStack = BottomStack.Children;
            BottomStack.Children.Add(new CardUIControl(AllCards.getInstance().GetCardFromName("Thonking")));
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
                CardUIControl dataString = (CardUIControl)e.Data.GetData("object");

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
                    ((StackPanel)e.Data.GetData("ParentElement")).Children.Remove(dataString);
                    Player1Field.Children.Add(dataString);
                }
            }
            e.Handled = true;
        }

        private void FieldGrid_Drop(object sender, DragEventArgs e)
        {

        }
    }
}
