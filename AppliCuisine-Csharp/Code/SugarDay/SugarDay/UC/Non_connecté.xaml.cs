using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SugarDay.UC
{
    /// <summary>
    /// Logique d'interaction pour Non_connecté.xaml
    /// </summary>
    public partial class Non_connecté : UserControl
    {
        public Non_connecté()
        {
            InitializeComponent();
        }

        private void Click_Inscription(object sender, RoutedEventArgs e)
        {
            Inscription win2 = new Inscription();
            win2.Show();
            var myWindow = Window.GetWindow(this);
            myWindow.Close();
        }

    }
}
