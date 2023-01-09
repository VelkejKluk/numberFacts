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
using RestSharp;
using RestSharp.Authenticators;

namespace numberFacts
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            int cislo = Convert.ToInt32(input.Text);
            
            var stisknutyRaioButton = sender as RadioButton;
            string tagZvoleneho = stisknutyRaioButton.Tag.ToString();
            string urlApi = $"http://numbersapi.com/{cislo}/{tagZvoleneho}";

            RestClient client = new RestClient(urlApi);
            RestRequest apiRequest = new RestRequest();
            var apiResponse = client.Get(apiRequest);
            string responseText = apiResponse.Content.ToString();
            MessageBox.Show(responseText);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
