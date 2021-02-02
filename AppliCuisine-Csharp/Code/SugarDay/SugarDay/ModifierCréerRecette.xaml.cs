using CsharpCode;
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
    /// Logique d'interaction pour Modifier_CréerRecette.xaml
    /// </summary>
    public partial class ModifierCréerRecette : Window
    {
        //Variables temporaires qui serve à stocker des variables et à les utilisers dans les autres méthodes
        public Personne pTemp { get; private set; }
        public string cheminImageMis { get; private set; }

        public ModifierCréerRecette(Personne p)//Seul un utilisateur connecté peut accéder cette fenêtre
        {
            InitializeComponent();
            pTemp = p;
            cheminImageMis = "img/Utilisateur.jpg"; //L'image par défaut de la recette est l'image correspondant à ce chemin
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
                Titre5.Foreground = brush2;
                Titre6.Foreground = brush2;
                Titre7.Foreground = brush2;
                Titre8.Foreground = brush2;
                Titre9.Foreground = brush2;
                Titre10.Foreground = brush2;
                Titre11.Foreground = brush2;
                Barre1.Stroke = brush2;
                Barre1.Fill = brush2;
                Barre2.Stroke = brush2;
                Barre2.Fill = brush2;

            }
            else //En mode normal
            {
                TitrePage.Background = brush3;
                GridTotal.Background = brush3;
                Titre2.Foreground = brush;
                Titre3.Foreground = brush;
                Titre4.Foreground = brush;
                Titre5.Foreground = brush;
                Titre6.Foreground = brush;
                Titre7.Foreground = brush;
                Titre8.Foreground = brush;
                Titre9.Foreground = brush;
                Titre10.Foreground = brush;
                Titre11.Foreground = brush;
                Barre1.Stroke = brush;
                Barre1.Fill = brush;
                Barre2.Stroke = brush;
                Barre2.Fill = brush;
            }
        }



        /// <summary>
        /// Fonction appelé lorsque l'utilisateur
        /// veut revenir sur la page d'accueil
        /// ou en arrière (Profil Utilisateur ici).
        /// </summary>
        private void Click_Back_Home(object sender, RoutedEventArgs e)
        {
            Profil win2 = new Profil(pTemp); //On lui passe son profil afin de le garder connecté
            this.Hide();
            win2.Show();
        }



        /// <summary>
        /// Fonction appelé lorsque l'utilisateur
        /// veut sauvegarder la recette qu'il vient de
        /// créé.
        /// </summary>
        private void Sauvegarder_Recette(object sender, RoutedEventArgs e)
        {
            if (Nom_Recette.Text.Length < 5) //Si le nom de la recette est inférieur a 5 caractères
            {
                ErrorSauv.Text = "Le nom de la recette doit au moins avoir 5 caractères";
                return;
            }

            if (Nom_Recette.Text == "" || Champs_Temps.Text == "" || Champs_Personne.Text == "" || Champ_Difficulté.Text == "" || Champs_Activité.Text == "" || Champs_Cuisson.Text == "" || Text_Prepa.Text == "") //Tous les champs doivent être remplis
            {
                ErrorSauv.Text = "Tous les champs ne sont pas remplis !";
                return;
            }

            //On supprime la recette de la liste
            (Application.Current as App).LesUsers.AllUsers.Remove(pTemp);
            
            //On converti les champs (string de base) en les castant en tant que int utilsiable
            int PersonneRec = Int32.Parse(Champs_Personne.Text);
            int DffcRec = Int32.Parse(Champ_Difficulté.Text);
            int CaseCuisson = Int32.Parse(Champs_Cuisson.Text);
            Recette rTemp = new Recette(Nom_Recette.Text, Champs_Temps.Text, cheminImageMis, Text_Desc.Text, Text_Prepa.Text);

            //On actualise tous les attributs de la recette selon les champs de la fenêtre
            rTemp.SetNbPersonne(PersonneRec);
            rTemp.SetTpsCuisson(CaseCuisson);
            rTemp.MettreDifc(DffcRec);
            rTemp.SetTpsPrepa(Champs_Activité.Text);
            rTemp.SetListeUstentile((Application.Current as App).ListeUstensileRecetteActuel2); //On copoie la ListeUstensileRecetteActuel2 dans la listeUstensile propre à la recette
            rTemp.SetListeIngredient((Application.Current as App).ListeIngrédientRecetteActuel2); //On copoie la ListeIngrédientRecetteActuel2 dans la listeIngredient propre à la recette
            (Application.Current as App).ListeUstensileRecetteActuel.Outils.Clear(); //On vide la ListeUstensileRecetteActuel2 pour pouvoir recommencer si on recréé une nouvelle recette
            (Application.Current as App).ListeIngrédientRecetteActuel.Aliments.Clear(); //On vide la ListeIngrédientRecetteActuel2 pour pouvoir recommencer si on recréé une nouvelle recette

            //On remet la recette dans la liste des recettes totales et dans la liste de recette personnel de l'utilisateur
            pTemp.MesRecettes.livreRecette.Add(rTemp);
            (Application.Current as App).LesUsers.AllUsers.Add(pTemp);
            (Application.Current as App).RecetteApp.livreRecette.Add(rTemp);


            Profil win2 = new Profil(pTemp);
            win2.Show();
            this.Close();
        }       

        
        
        //Ouvre une fenêtre vers l'ajout d'ingrédient avec l'utilisateur en paramètre
        private void GotoIngredient(object sender, RoutedEventArgs e)
        {
            FenetreIngredientActuel win2 = new FenetreIngredientActuel(pTemp);
            win2.Show();
        }



        //Ouvre une fenêtre vers l'ajout d'ustensile avec l'utilisateur en paramètre
        private void GotoUstensile(object sender, RoutedEventArgs e)
        {
            FenetreUstensileActuel win2 = new FenetreUstensileActuel(pTemp);
            win2.Show();
        }



        /// <summary>
        /// Fonction appelé lorsque l'utilisateur
        /// veut mettre une image sur la recette qu'il veut créer
        /// </summary>
        private void Click_Img(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog(); //On créé une variable permettant la consultation des fichiers sur l'ordinateur local
            dialog.InitialDirectory = @"C:\Users\Public\Pictures"; //Chemin par défaut dans lequel ira la variable dialog
            dialog.Filter = "All images files (*.jpg, *.png) | *.jpg; *.png"; //Filtre appliqué sur le type de fichier pour la sélection des images

            bool? result = dialog.ShowDialog(); //Execute la variable et retourne true si elle a réussi sinon false

            if (result == true) //Si l'ouverte du repertoire de l'utilisateur a fonctionne
            {
                string filename = dialog.FileName; //On stocke le chemin de l'image dans variable filename
                ImageRecette.Source = new BitmapImage(new Uri(filename, UriKind.Absolute)); //On converti l'image au bout du chemin d'accès (filename) en BitmapImage appliquable aux éléments de notre vue
                cheminImageMis = filename; //On rend le chemin de l'image utilisable dans toutes les méthodes de la fenêtres
            }

        }



        /// <summary>
        /// Edition de l'event "PreviewTextInput" du
        /// champ de notation de la recette. Permet 
        /// le contrôle de la saisie avec des 
        /// expressions régulières 
        /// (voir les "PreviewTextInput" -> AjouterUstensile.xaml pour plus)
        /// </summary>
        private void Champs_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex Caract = new Regex("[^0-9]+");
            e.Handled = Caract.IsMatch(e.Text);
        }



        /// <summary>
        /// Idem que au-dessus
        /// </summary>
        private void Champ_Difficulté_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex Caract = new Regex("[^0-5]"); //on veut cette fois-ci des caractères compris entre 0 et 5
            e.Handled = Caract.IsMatch(e.Text);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            (Application.Current as App).RecetteApp.sauvegarde();
            (Application.Current as App).TousLesComms.sauvegarde();
            (Application.Current as App).LesUsers.sauvegarde();
        }
    }
}
