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

namespace GUIControlsAssignment4
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

        private void numberButton_Click(object sender, RoutedEventArgs e)
        {
            if (valueTextBox.Text == "0")
                valueTextBox.Text = "";
            valueTextBox.Text += ((Button)sender).Content;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            if (valueTextBox.Text.Length > 0)
                valueTextBox.Text = valueTextBox.Text.Substring(0, valueTextBox.Text.Length - 1);
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            double value;
            if (!double.TryParse(valueTextBox.Text, out value))
                infoTextBlock.Text = "Info: Value is not a number!";
            else if (temperatureRadio.IsChecked.Value)
            {
                if (value > 120)
                    infoTextBlock.Text = "Info: Temperature is too high!";
                else if (value < 20)
                    infoTextBlock.Text = "Info: Temperature is too low!";
                else
                    temperatureTextBlock.Text = valueTextBox.Text;
            }
            else
            {
                if (value > 100)
                    infoTextBlock.Text = "Info: Humidity is too high!";
                else if (value < 0)
                    infoTextBlock.Text = "Info: Humidity is too low!";
                else
                    humidityTextBlock.Text = valueTextBox.Text;
            }
        }
    }
}
