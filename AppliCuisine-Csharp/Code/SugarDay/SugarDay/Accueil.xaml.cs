using CsharpCode;
using SugarDay.UC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Logique d'interaction pour Accueil.xaml
    /// </summary>
    public partial class Accueil : Window
    {

        public Personne pTemp{ get; private set; } //pTemp : Profil de l'utilisateur (Type Personne) stocké afin de l'utiliser dans les autres méthodes de la fenêtre



        /// <summary>
        /// Constructeur de la fenêtre de la page d'accueil
        /// lorsqu'un utilisateur n'est pas connecté
        /// </summary>
        public Accueil()
        {
            
            InitializeComponent(); //charge la page

            pTemp = null; //Aucun utilisateur connecté

            List<Commentaire> DernierComm=DernierComFct(); //Gère affiche le dernier commentaire parmi toutes les recettes
            
            //Donne le chemin de chaque binding pour toutes les listes         
            recetteListBox.ItemsSource = (Application.Current as App).RecetteApp.livreRecette; 
            tendanceListbox.ItemsSource = (Application.Current as App).RecetteApp.Top3RecetteNote();
            lesAvisListBox.ItemsSource = DernierComm;  

            Dark_Mode(); //Appelle le DarkMode si il était déjà activé
        }



        /// <summary>
        /// Constructeur de la fenêtre de la page d'accueil
        /// lorsqu'un utilisateur est déjà connecté
        /// </summary>
        public Accueil(Personne p)
        {
            InitializeComponent();

            pTemp = p; //On recupère l'utilisateur

            List<Commentaire> DernierComm = DernierComFct(); //Gère affiche le dernier commentaire parmi toutes les recettes

            //Donne le chemin de chaque binding pour toutes les listes 
            recetteListBox.ItemsSource = (Application.Current as App).RecetteApp.livreRecette;
            tendanceListbox.ItemsSource = (Application.Current as App).RecetteApp.Top3RecetteNote();
            lesAvisListBox.ItemsSource = DernierComm;

            Dark_Mode();//Appelle le DarkMode si il était déjà activé
            SetUserControl(); //Appelle les usercontrols afin de changer les boutons "Connexion" et "S'inscrire" par "NomDuProfil" et "Se déconnecter"
            
        }



        /// <summary>
        /// Fonction qui cherche quel est le dernier commentaire 
        /// sur toute l'application (c-a-d parmi toutes recettes confondues)
        /// et retourne ce dernier commentaire dans le constructeur
        /// </summary>
        private List<Commentaire> DernierComFct()
        {
            List<Commentaire> DernierComm = new List<Commentaire>();

            //Ajoute à la liste "DernierComm" le dernier commentaire en prenant le dernier élément la liste où tous les commentaires sont stockés
            DernierComm.Add((Application.Current as App).TousLesComms.TousLesComms[(Application.Current as App).TousLesComms.TousLesComms.Count - 1]);

            return DernierComm;
        }



        /// <summary>
        /// Actualise tous les user-controls de la page
        /// selon si l'utilisateur est connecté ou non
        /// </summary>
        private void SetUserControl()
        {
            ProfilButton win3 = new ProfilButton();
            win3.SetButtonContent(pTemp.Pseudo);
            this.contentControl1.Content = win3; //On remplace le bouton "Connexion" par le User-control "ProfilButton" qui est aussi un bouton en lui même
            this.contentControl2.Content = new Deconnexion_button(); //On remplace le bouton "S'inscrire" par le User-control "Deconnexion_button" qui est aussi un bouton en lui même
        }



        /// <summary>
        /// Edition de l'event "TextChanged" de 
        /// 'seachBar' afin d'actualiser la liste "recetteListBox" selon les
        /// caractères tapés par l'utilisateur afin de les faire correspondre
        /// </summary>
        private void Barre_de_recherche(object sender, TextChangedEventArgs e)
        {
            List<Recette> toutesLesRecettesActualisé = new List<Recette>(); //Liste qui est actualisé à chaque entrée sur le clavier dans la barre de recherche

            if (string.IsNullOrEmpty(searchBar.Text) == false)  //Si la 'searchBar' contient du text faire :
            {
                foreach (Recette item in (Application.Current as App).RecetteApp.livreRecette) //Pour toutes les recettes dans la liste livreRecette de RecetteApp dans App
                {
                    string titrelower = item.Nom.ToLower();  //On converti le titre des recettes en minuscule afin de faire correspondre même si le text tapé est en majuscule

                    if (titrelower.StartsWith(searchBar.Text.ToLower())) //Si le titre de la recette commence avec les mêmes caractères que tapés dans la searchbox (converti en minuscule)
                    {
                        toutesLesRecettesActualisé.Add(item); //On ajoute cette recette dans la liste actualisé "toutesLesRecettesActualisé"
                    }
                }
            }
            else if (searchBar.Text == "") //Si la searchbar est vide (si l'utilisateur a supprimé son texte par exemple)
            {
                foreach (Recette item in (Application.Current as App).RecetteApp.livreRecette) //Pour toutes les recettes dans la liste livreRecette de RecetteApp dans App
                {
                    toutesLesRecettesActualisé.Add(item); //On prend toutes les recettes et on les ajoutes à "toutesLesRecettesActualisé"
                }
            }
            recetteListBox.ItemsSource = toutesLesRecettesActualisé; //On affiche à la liste "recetteListBox" les recettes correspondantes dans "toutesLesRecettesActualisé"

        }



        /// <summary>
        /// Edition de l'event "SelectionChanged" de 
        /// 'recetteListBox' afin de conduire l'utilisateur
        /// sur le détail de la recette cliqué (détails)
        /// </summary>
        private void ListBox_ElementChangé(object sender, SelectionChangedEventArgs e)
        {

            if (recetteListBox.SelectedItem != null)
            {

                if (pTemp != null)
                {
                    DétailsDeRecette win3 = new DétailsDeRecette(recetteListBox.SelectedItem as Recette, pTemp); //On créé une fenêtre "DétailsDeRecette" du type si l'utilisateur est connecté
                    win3.Show(); //Ouvre la fenêtre "win2"
                    this.Close(); //Ferme la fenêtre actuelle
                    return; //Peut être remplacé par un else mais fonctionne aussi
                }
                DétailsDeRecette win2 = new DétailsDeRecette(recetteListBox.SelectedItem as Recette); //On créé une fenêtre "DétailsDeRecette" du type si l'utilisateur n'est connecté
                win2.Show();
                this.Close();
            }
            
        }



        /// <summary>
        /// Edition de l'event "SelectionChanged" de 
        /// 'tendanceListbox' afin de conduire l'utilisateur
        /// sur le détail de la recette cliqué (détails)
        /// (Les commentaires sont les mêmes que plus haut,
        /// seul la source de l'event change: ici 'tendanceListbox')
        /// </summary>
        private void ListBoxTendance_ElementChangé(object sender, SelectionChangedEventArgs e)
        {
            if (tendanceListbox.SelectedItem != null)
            {
                if (pTemp != null)
                {
                    
                    DétailsDeRecette win3 = new DétailsDeRecette(tendanceListbox.SelectedItem as Recette, pTemp);
                    win3.Show();
                    this.Close();
                    return;
                }
                DétailsDeRecette win2 = new DétailsDeRecette(tendanceListbox.SelectedItem as Recette);
                win2.Show();
                this.Close();
            }
        }



        /// <summary>
        /// Fonction appelé afin de savoir si
        /// le Mode nuit a déjà été appelé par l'utilisateur depuis
        /// "DM_Btn" et changer les couleurs de certains éléments de la
        /// vue selon l'appel Dark Mode
        /// </summary>
        private void Dark_Mode()
        {

            var converter = new System.Windows.Media.BrushConverter(); //On créé une variable permettant de convertir un code couleur en teinte de couleur
            var brush = (Brush)converter.ConvertFromString("#121211"); // On créé une teinte de coueleur avec les paramêtres hexa de la couleur
            var brush2 = (Brush)converter.ConvertFromString("white"); // On créé une teinte de coueleur avec le nom système de la couleur
            var brush3 = (Brush)converter.ConvertFromString("#ECE1DE");

            if ((Application.Current as App).ColorTestGlobal % 2 == 0) //Si le DarkMode est enclenché (car "ColorTestGlobal" dans App est pair lorsque le DarkMode est activé)
            {
                //Fixe chaque teinte de ces éléments de la vue sur le code couleur représentant
                GridTotal.Background = brush;
                Textpage.Foreground = brush2;
                TirePage2.Foreground = brush2;
                TirePage3.Foreground = brush2;
                TirePage4.Foreground = brush2;
                DM_Btn.Background = brush;
                DM_Btn.Foreground = brush2;
                DM_Btn.BorderBrush = brush2;
            }
            else //Si le DarkMode n'est pas enclenché (car "ColorTestGlobal" dans App est impair lorsque le DarkMode est désactivé)
            {
                GridTotal.Background = brush3;
                Textpage.Foreground = brush;
                TirePage2.Foreground = brush;
                TirePage3.Foreground = brush;
                TirePage4.Foreground = brush;
                DM_Btn.Background = brush2;
                DM_Btn.Foreground = brush;
                DM_Btn.BorderBrush = brush;
            }

        }



        /// <summary>
        /// Edition de l'event "Click" du 
        /// bouton "DM_Btn". Il met à jour la 
        /// variable permettant de reconnaître l'activation
        /// du DarkMode et actualise en même les couleurs au même
        /// titre que la fonction DarkMode() plus haut
        /// </summary>
        private void Dark_ModeBtn(object sender, RoutedEventArgs e)
        {
            
            var converter = new System.Windows.Media.BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#121211");
            var brush2 = (Brush)converter.ConvertFromString("white");
            var brush3 = (Brush)converter.ConvertFromString("#ECE1DE");
            if ((Application.Current as App).ColorTestGlobal % 2 == 1)  //Si le DarkMode n'est pas enclenché (car "ColorTestGlobal" dans App est impair lorsque le DarkMode est désactivé) alors on l'enclenche
                //c'est l'inverse des opérations de la "fonction Dark_Mode()"
            {
                Fenetre.Background = brush;
                GridTotal.Background = brush;
                Textpage.Foreground = brush2;
                TirePage2.Foreground = brush2;
                TirePage3.Foreground = brush2;
                TirePage4.Foreground = brush2;
                DM_Btn.Background = brush;
                DM_Btn.Foreground = brush2;
                DM_Btn.BorderBrush = brush2;
                (Application.Current as App).ColorTestGlobal++; //Incrémente de 1 la valeur de 'ColorTestGlobal' dans App afin de donner l'information aux autres fenêtres de l'activation
            }
            else
            {
                Fenetre.Background = brush3;
                GridTotal.Background = brush3;
                Textpage.Foreground = brush;
                TirePage2.Foreground = brush;
                TirePage3.Foreground = brush;
                TirePage4.Foreground = brush;
                DM_Btn.Background = brush3;
                DM_Btn.Foreground = brush;
                DM_Btn.BorderBrush = brush;
                (Application.Current as App).ColorTestGlobal++; //On incrémente de 1 aussi
            }
            
        }

        private void Fenetre_Closing(object sender, CancelEventArgs e)
        {
            (Application.Current as App).RecetteApp.sauvegarde();
            (Application.Current as App).TousLesComms.sauvegarde();
            (Application.Current as App).LesUsers.sauvegarde();
        }
    }
}
