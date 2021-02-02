using System;
using System.Collections.Generic;
using System.IO;
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
using SugarDay;
using SugarDay.UC;

namespace SugarDay
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Profil : Window
    {
        public Personne pTemp { get; private set; }
        public string cheminImageMis { get; private set; }

        public Profil(Personne p)
        {
            InitializeComponent();
            DarkMode();
            pTemp = p;
            DescProfil1.Text = pTemp.Description; //On peut pas faire de bind car Description est en private set donc on copie le text dans la textbox
            Pseudo_Login.Text = pTemp.Pseudo; //On doit aussi copier coller le text et pas binder car au niveau de la sauvegarde on perd la personne et donc devient null
            //Data.Stub.ListeUtilisateur.IndexOf("Finasty2");
            //Personne Pactuelle = Data.Stub.ListeUtilisateur.Find(Personne => Personne.Pseudo.Contains(Pseudo_Login.Text));
            //Data.Stub.ListeUtilisateur.Find(Personne => Personne.Pseudo.Contains(Pseudo_Login.Text)).ModifierDescription("Test");

            //cheminImageMis = "C:/Users/Theo/Pictures/space-marines-720x340.jpg";
            //p.ModifierCheminImage("C:/Users/Theo/Pictures/space-marines-720x340.jpg");
            //ImageProfil.ImageSource = new BitmapImage(new Uri(@pTemp.CheminImage));
            try { ImageProfil.ImageSource = new BitmapImage(new Uri(@pTemp.CheminImage)); }
            catch (UriFormatException)
            {
                pTemp.ModifierCheminImage("img/Utilisateur.jpg");
            }


            MesRecettes.ItemsSource = p.MesRecettes.livreRecette;
            if (MesRecettes.Items.Count==0)
            {
                AcuneRecetteTxt.Text = "Vous n'avez aucune recette pour l'instant";
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
                Pseudo_Login.Foreground = brush2;
                GridTotal.Background = brush;
                Titre2.Foreground = brush2;
                Titre3.Foreground = brush2;
            }
            else //En mode normal
            {
                Pseudo_Login.Background = brush3;
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
            Accueil win2 = new Accueil(pTemp);
            win2.Show();
            this.Close();
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
                string filename = dialog.FileName;  //On stocke le chemin de l'image dans variable filename
                ImageProfil.ImageSource = new BitmapImage(new Uri(filename, UriKind.Absolute));  //On converti l'image au bout du chemin d'accès (filename) en BitmapImage appliquable aux éléments de notre vue
                cheminImageMis = filename;  //On rend le chemin de l'image utilisable dans toutes les méthodes de la fenêtres
            }
        }



        /// <summary>
        /// Fonction appelé lorsque l'utilisateur
        /// veut sauvegarder son image de profil 
        /// ou sa nouvelle description de profil
        /// </summary>
        private void Btn_Sauvegarde(object sender, RoutedEventArgs e)
        {
            //On supprime l'utilisateur actuel de la liste
            Personne Pactuelle=(Application.Current as App).LesUsers.RechercherPersonne(Pseudo_Login.Text);
            (Application.Current as App).LesUsers.AllUsers.Remove(Pactuelle);

           
            pTemp.ModifierDescription(DescProfil1.Text); // On actualise la nouvel description dans l'attribut de la personne
            if(cheminImageMis!=null) //Si le chemin image est différent
            {
                pTemp.ModifierCheminImage(cheminImageMis); //On actualise le chemin de l'image dans l'attribut de la personne
            }           

            //On rajoute le nouvel utilisateur dans la liste
            (Application.Current as App).LesUsers.AllUsers.Add(pTemp);
            ConfirmationSauvegarde.Text = "Sauvegarde réussie";
            
        }



        /// <summary>
        /// Fonction appelé lorsque l'utilisateur
        /// veut ajouter une recette personnelle
        /// </summary>
        private void Btn_AjoutRecette(object sender, RoutedEventArgs e)
        {
            ModifierCréerRecette win2 = new ModifierCréerRecette(pTemp);
            win2.Show();
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            (Application.Current as App).RecetteApp.sauvegarde();
            (Application.Current as App).TousLesComms.sauvegarde();
            (Application.Current as App).LesUsers.sauvegarde();
        }
    }
}
