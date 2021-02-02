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
    /// Logique d'interaction pour Deconnexion_button.xaml
    /// </summary>
    public partial class Deconnexion_button : UserControl
    {
        public Deconnexion_button()
        {
            InitializeComponent();
        }

        private void Deco_button(object sender, RoutedEventArgs e)
        {            
            Accueil win2 = new Accueil();
            var myWindow = Window.GetWindow(this);
            win2.Show();
            win2.contentControl1.Content = new UConnexion();
            win2.contentControl2.Content = new Non_connecté();      
            myWindow.Close();
        }
    }
}
