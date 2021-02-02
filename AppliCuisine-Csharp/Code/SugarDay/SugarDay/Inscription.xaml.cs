using CsharpCode;
using SugarDay.UC;
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

namespace SugarDay
{
    /// <summary>
    /// Logique d'interaction pour Inscriptionn.xaml
    /// </summary>
    public partial class Inscription : Window
    {

        
        public Inscription() //Seul un utilisateur non connecté peut accéder à le fenêtre inscription
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
                Titre4.Foreground = brush2;
                PhraseContrat.Foreground = brush2;
                UserContract.Foreground = brush2;
            }
            else //En mode normal
            {
                TitrePage.Background = brush3;
                GridTotal.Background = brush3;
                Titre2.Foreground = brush;
                Titre3.Foreground = brush;
                Titre4.Foreground = brush;
                PhraseContrat.Foreground = brush;
                UserContract.Foreground = brush;
            }
        }



        /// <summary>
        /// Fonction appelé lorsque l'utilisateur
        /// veut revenir sur la page d'accueil
        /// ou en arrière
        private void Click_Back_Home(object sender, RoutedEventArgs e)
        {
            Accueil win2 = new Accueil();
            this.Hide();
            win2.Show();
        }



        /// <summary>
        /// Fonction appelé lorsque l'utilisateur
        /// veut confirmer son inscription
        /// </summary>
        private void Button_Inscription(object sender, RoutedEventArgs e)
        {
            

            if (textbox_inscription.Text.Length < 5 || mdpbox1.Password.Length < 5) //Si le mot de passe ou le le pseudo rentré est inférieur a 5 caractères
            {
                ErrorInscriptionButton.Text = "Le login et les mots de passes doivent avoir une longueur minimum de 5 caractères";
                return;
            }

            if (mdpbox1.Password=="" || mdpbox2.Password=="" || textbox_inscription.Text=="") //Si l'un des champs est vide
            {
                ErrorInscriptionButton.Text = "Veuillez remplir tous les champs";
                return;
            }

            if(UserContract.IsChecked is false || UserContract==null) //Si la checkBox du contrat d'utilisation est null ou non-checké (car c'est un bool? et qu'il est null à sa création et sans interaction)
            {
                
                ErrorInscriptionButton.Text = "Vous n'avez pas accepter les conditions d'utilisations";
                return;
                
            }

            if (mdpbox1.Password != mdpbox2.Password) //Si les 2 champs de mot de passes ne correspondent pas
            {
                ErrorInscriptionButton.Text = "Les mots de passes ne correspondent pas";
                return;
            }

            foreach (Personne p in (Application.Current as App).LesUsers.AllUsers) //Pour tous les comptes utilsiateurs déjà existants
            {
                if(p.Pseudo== textbox_inscription.Text) //Si le pseudo rentré est égale au pseudo d'un compte déjà existant
                {
                    ErrorInscriptionButton.Text = "Login déjà utilisé par un autre compte";
                    return;
                }
            }

            //Créé et ajoute le nouvel utilisateur à la liste de tous les utilisateurs
            Personne NvUtils = new Personne(textbox_inscription.Text, mdpbox1.Password);
            (Application.Current as App).LesUsers.AllUsers.Add(NvUtils);


            Accueil win2 = new Accueil(NvUtils); //On renvoie l'utilisateur sur la page d'accueil avec son profil en paramètre
            win2.Show();
            this.Close();
        }
        
    }
}
