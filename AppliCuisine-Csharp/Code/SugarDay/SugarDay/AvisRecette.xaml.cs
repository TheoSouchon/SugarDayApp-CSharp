using CsharpCode;
using SugarDay.UC;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logique d'interaction pour AvisRecette.xaml
    /// </summary>
    public partial class AvisRecette : Window
    {

        //Variable temporaire qui serve à stocker des variables et à les utilisers dans les autres méthodes
        public Personne pTemp { get; private set; }
        public Recette RecTemp { get; private set; }



        /// <summary>
        /// Constructeur de la page appelé
        /// si l'utilisateur n'est pas connecté
        /// </summary>
        public AvisRecette(Recette R)
        {
            InitializeComponent();
            pTemp = null;
            RecTemp = R;
            lesAvisListBox.ItemsSource = R.Messages.TousLesComms;
            DarkMode();
            OptionCommNote();

        }



        // <summary>
        /// Constructeur de la page appelé
        /// si l'utilisateur est déjà connecté
        /// </summary>
        public AvisRecette(Recette R,Personne p)
        {
            InitializeComponent();
            RecTemp = R;
            pTemp = p;
            lesAvisListBox.ItemsSource = R.Messages.TousLesComms;
            DarkMode();


        }



        // <summary>
        /// Fonction qui donne l'accès aux outils 
        /// pour commenter et noter une recette si 
        /// l'utilisateur est connecté. Par déafaut
        /// l'accès est donné.
        /// </summary>
        public void OptionCommNote()
        {
            if (pTemp == null) //si l'utilisateur n'est pas connecté
            {
                Commenter_Btn.IsEnabled = false; //Rend le bouton incliquable, inutilisable
                CommentText.IsReadOnly = true; //Rend le champs de commentaire incliquable, inutilisable
                CommentText.Text = "Vous devez créer un compte pour commenter et noter";
                Noter_Btn.IsEnabled = false;
                NoterText.IsEnabled = false;
            }
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
                Titre6.Foreground = brush2;
            }
            else //En mode normal
            {
                TitrePage.Background = brush3;
                GridTotal.Background = brush3;
                Titre6.Foreground = brush;
            }
        }



        /// <summary>
        /// Fonction qui commente la recette
        /// lorsque l'utilisateur appuye
        /// sur le bouton correspondant
        /// </summary>
        private void Commenter(object sender, RoutedEventArgs e)
        {

            if (CommentText.Text!="") //Si le champ de commentaire n'est pas vide
            {

                //On cherche la recette actuelle dans la liste de toutes les recettes pour la supprimer
                Recette Ractuelle = (Application.Current as App).RecetteApp.RechercherRecette(RecTemp.Nom);
                (Application.Current as App).RecetteApp.livreRecette.Remove(Ractuelle);

                //On recréé la recette avec le commentaire qu'on ajoute et on l'ajoute à la place de celle qu'on a supprimé dans la liste
                Ractuelle.Messages.TousLesComms.Add(new Commentaire(CommentText.Text, pTemp));
                (Application.Current as App).RecetteApp.livreRecette.Add(Ractuelle);
                //Sans oublier d'ajouter le nouveau commentaire dans la liste contenant tous les commentaires
                (Application.Current as App).TousLesComms.TousLesComms.Add(new Commentaire(CommentText.Text,pTemp));
                this.Close();
            }
            
        }



        /// <summary>
        /// Edition de l'event "PreviewTextInput" du
        /// champ de notation de la recette. Permet 
        /// le contrôle de la saisie avec des 
        /// expressions régulières 
        /// (voir les "PreviewTextInput" -> AjouterUstensile.xaml pour plus)
        /// </summary>
        private void Champ_Noté_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex Caract = new Regex("[^0-5]");
            e.Handled = Caract.IsMatch(e.Text);
        }




        /// <summary>
        /// Fonction qui note la recette
        /// lorsque l'utilisateur appuye
        /// sur le bouton correspondant
        /// </summary>
        private void Noter(object sender, RoutedEventArgs e)
        {
            if (NoterText.Text != "") //Si le champ de notation n'est pas vide
            {
                //On cherche la recette actuelle dans la liste de toutes les recettes pour la supprimer
                Recette Ractuelle = (Application.Current as App).RecetteApp.RechercherRecette(RecTemp.Nom);
                (Application.Current as App).RecetteApp.livreRecette.Remove(Ractuelle);

                //On recréé la recette avec la note qu'on ajoute et on l'ajoute à la place de celle qu'on a supprimé dans la liste
                int note = Int32.Parse(NoterText.Text); //Créer une variable permettant de casté le type string en int
                Ractuelle.Notes.Add(note); //On ajoute la note à la recette
                Ractuelle.MoyenneNote(); //La véritable note correpond à la moyenne de toutes
                (Application.Current as App).RecetteApp.livreRecette.Add(Ractuelle);

                this.Close();
            }
        }

        private void Fenetre_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            (Application.Current as App).RecetteApp.sauvegarde();
            (Application.Current as App).TousLesComms.sauvegarde();
            (Application.Current as App).LesUsers.sauvegarde();
        }
    }
}
