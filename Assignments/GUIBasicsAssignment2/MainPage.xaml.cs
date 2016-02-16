using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GUIBasicsAssignment2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }


        private void eurTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (eurTextBox.FocusState == FocusState.Unfocused)
                return;

            double euros;
            if (double.TryParse(eurTextBox.Text, out euros))
            {
                double fim = 5.7349081364829 * euros;
                fimTextBox.Text = fim.ToString("0.00");
            }
            else
            {
                fimTextBox.Text = (0.00).ToString("0.00");
            }
        }

        private void fimTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (fimTextBox.FocusState == FocusState.Unfocused)
                return;

            double fim;
            if (double.TryParse(fimTextBox.Text, out fim))
            {
                double euros = fim / 5.7349081364829;
                eurTextBox.Text = euros.ToString("0.00");
            }
            else
            {
                eurTextBox.Text = (0.00).ToString("0.00");
            }
        }
    }
}
