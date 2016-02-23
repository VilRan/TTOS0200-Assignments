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

namespace GUIControlsAssignment3
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

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void drawButton_Click(object sender, RoutedEventArgs e)
        {
            int numRows;
            if ( ! int.TryParse(textBox.Text, out numRows))
                return;

            numbersTextBlock.Text = "";
            string type = ((ComboBoxItem)comboBox.SelectedValue).Content.ToString();
            int numbersPerRow = 0;
            int maxValue = 0;
            switch (type)
            {
                case "Lotto":
                    maxValue = 39;
                    numbersPerRow = 7;
                    break;
                case "Viking Lotto":
                    maxValue = 48;
                    numbersPerRow = 6;
                    break;
                case "Eurojackpot":
                    maxValue = 50;
                    numbersPerRow = 7;
                    break;
            }

            Random rand = new Random();
            for (int i = 0; i < numRows; i++)
            {
                numbersTextBlock.Text += "Row " + (i + 1) + ": ";
                for (int j = 0; j < numbersPerRow; j++)
                {
                    int number = rand.Next(maxValue + 1);
                    numbersTextBlock.Text += number + " ";
                }
                numbersTextBlock.Text += "\n";
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            numbersTextBlock.Text = "";
        }
    }
}
