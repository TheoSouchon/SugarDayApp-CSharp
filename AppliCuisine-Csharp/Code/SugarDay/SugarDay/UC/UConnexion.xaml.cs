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
    /// Logique d'interaction pour UConnexion.xaml
    /// </summary>
    public partial class UConnexion : UserControl
    {
        
        public UConnexion()
        {
            InitializeComponent();
        }

        private void Click_Connexion(object sender, RoutedEventArgs e)
        {
            
            Connexion win2 = new Connexion();   
            win2.Show();
            var myWindow = Window.GetWindow(this);
            myWindow.Close();
        }
        
    }
}
