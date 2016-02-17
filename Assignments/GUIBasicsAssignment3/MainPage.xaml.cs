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

namespace GUIBasicsAssignment3
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

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            double windowWidth, windowHeight, frameWidth;
            if (double.TryParse(widthTextBox.Text, out windowWidth)
                && double.TryParse(heightTextBox.Text, out windowHeight)
                && double.TryParse(frameTextBox.Text, out frameWidth))
            {
                windowAreaTextBox.Text = (windowWidth * windowHeight).ToString() + " cm^2";
                glassAreaTextBox.Text = ((windowWidth - frameWidth) * (windowHeight - frameWidth)).ToString() + " cm^2";
                frameCircumferenceTextBox.Text = (windowWidth * 2 + windowHeight * 2).ToString() + " cm^2";
            }
        }
    }
}
