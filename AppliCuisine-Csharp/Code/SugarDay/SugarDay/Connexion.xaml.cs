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
using System.Windows.Shapes;
using CsharpCode;
using SugarDay.UC;

namespace SugarDay
{
    /// <summary>
    /// Logique d'interaction pour Connexionn.xaml
    /// </summary>
    public partial class Connexion : Window
    {
        public Connexion()
        {
            InitializeComponent();
            DarkMode();
        }



        /// <summary>
        /// Fonction appelé afin de savoir si
        /// le Mode nuit a déjà été appelé par l'utilisateur depuis
        /// "DM_Btn" et changer les couleurs de certains éléments de la
        /// vue selon l'appel Dark Mode (voir DarkMode() -> Accueil.xaml pour plus)
        /// </summary>
        private void DarkMode()
        {
            var converter = new System.Windows.Media.BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#121211");
            var brush2 = (Brush)converter.ConvertFromString("white");
            var brush3 = (Brush)converter.ConvertFromString("#ECE1DE");
            if ((Application.Current as App).ColorTestGlobal % 2 == 0) //En Darkmode
            {
                TitrePage.Foreground = brush2;
                GridTotal.Background = brush;
                Titre2.Foreground = brush2;
                Titre3.Foreground = brush2;
            }
            else //En mode normal
            {
                TitrePage.Background = brush3;
                GridTotal.Background = brush3;
                Titre2.Foreground = brush;
                Titre3.Foreground = brush;
            }
        }



        /// <summary>
        /// Fonction appelé lorsque l'utilisateur
        /// veut revenir sur la page d'accueil
        /// ou en arrière.
        /// </summary>
        private void Click_Back_Home(object sender, RoutedEventArgs e)
        {
            Accueil win2 = new Accueil();
            this.Close();
            win2.Show();
        }



        // <summary>
        /// Fonction appelé lorsque l'utilisateur
        /// veut se connecter à son compte
        /// </summary>
        private void Click_Connexion(object sender, RoutedEventArgs e)
        {
            bool trouve=false;  //Variable boolean autorisant la connexion | true = autorisé          

            foreach (Personne p in (Application.Current as App).LesUsers.AllUsers) //Pour tous les utilsiateurs dans l'application
            {

                if (textbox_connexion.Text == p.Pseudo) //Si le login rentré correspond à un pseudo d'un utilsiateur
                {
                    if (passbox_connexion.Password == p.Mot_De_Passe) //Si le mot de passe rentré correspond au même utilsiateur
                    {
                        trouve = true; //On signale qu'on autorise la connexion
                        Accueil win2 = new Accueil(p); //On renvoie l'utilisateur sur la page d'accueil avec son profil en paramètre
                        win2.Show();
                        this.Close();
                        
                    }
                }
            }

            //Si la tentative de connexion échoue, on le signale à l'utilisateur
            if(!trouve)
            {
                ErrorConnexion.Text = "le login et/ou le mot de passe ne correspondent pas";
            }
            
        }
    }
}
