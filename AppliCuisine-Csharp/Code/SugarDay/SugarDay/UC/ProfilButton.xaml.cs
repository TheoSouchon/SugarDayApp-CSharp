using CsharpCode;
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
    /// Logique d'interaction pour ProfilButton.xaml
    /// </summary>
    public partial class ProfilButton : UserControl
    {
        public ProfilButton()
        {
            InitializeComponent();
        }

        private void Profil_button(object sender, RoutedEventArgs e)
        {
            Personne Pactuelle = (Application.Current as App).LesUsers.RechercherPersonne((string)LoginButton.Content);
            if(Pactuelle != null)
            {
                Profil win2 = new Profil(Pactuelle);


                win2.Show();
                var myWindow = Window.GetWindow(this);
                myWindow.Close();
            }
            
        }

        public void SetButtonContent(string profil_name)
        {
            LoginButton.Content = profil_name;
        }

    }
}
