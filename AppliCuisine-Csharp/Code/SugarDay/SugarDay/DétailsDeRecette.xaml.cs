using CsharpCode;
using SugarDay.UC;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Logique d'interaction pour DétailsDeRecette.xaml
    /// </summary>

    
    public partial class DétailsDeRecette : Window
    {
        //Variables temporaires qui serve à stocker des variables et à les utilisers dans les autres méthodes
        public Personne pTemp { get; private set; }
        public Recette rTemp { get; private set; }



        /// <summary>
        /// Constructeur de la page appelé
        /// si l'utilisateur est connecté
        /// </summary>
        public DétailsDeRecette(Recette temp,Personne p)
        {
            InitializeComponent();
            pTemp = p;
            rTemp = temp;
            SetChampsPage();
            DarkMode();

            if (temp.Note_final==0)
            {
                TextNote.Text = "AUCUNE";
            }
            else
            {
                TextNote.DataContext = temp;
            }
                      
        }



        /// <summary>
        /// Constructeur de la page appelé
        /// si l'utilisateur n'est pas connecté
        /// </summary>
        public DétailsDeRecette(Recette temp)
        {
            InitializeComponent();
            pTemp = null;
            rTemp = temp;
            SetChampsPage();
            DarkMode();

            if (temp.Note_final == 0)
            {
                TextNote.Text = "AUCUNE";
            }
            else
            {
                TextNote.DataContext = temp;
            }
        }



        /// <summary>
        /// Fonction qui set chaque binding des éléments de la vue
        /// sur la propriété correspondante
        /// </summary>
        private void SetChampsPage ()
        {
            ListeIngredientRecette.ItemsSource = rTemp.Aliments;
            ListeUstensileRecette.ItemsSource = rTemp.Outils;
            NomRecette.DataContext = rTemp;
            TextTpsPrepa.DataContext = rTemp;
            TextDifc.DataContext = rTemp;
            TextNote.DataContext = rTemp;
            PrapaText.DataContext = rTemp;
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
                Titre1.Foreground = brush2;
                Titre2.Foreground = brush2;
                Titre3.Foreground = brush2;
                Titre4.Foreground = brush2;
                Titre5.Foreground = brush2;
                Titre6.Foreground = brush2;
                Titre7.Foreground = brush2;
                TextTpsPrepa.Foreground = brush2;
                TextDifc.Foreground = brush2;
                TextNote.Foreground = brush2;
                NomRecette.Foreground = brush2;
            }
            else //En mode normal
            {
                TitrePage.Background = brush3;
                GridTotal.Background = brush3;
                Titre1.Foreground = brush;
                Titre2.Foreground = brush;
                Titre3.Foreground = brush;
                Titre4.Foreground = brush;
                Titre5.Foreground = brush;
                Titre6.Foreground = brush;
                Titre7.Foreground = brush;
                TextTpsPrepa.Foreground = brush;
                TextDifc.Foreground = brush;
                TextNote.Foreground = brush;
                NomRecette.Foreground = brush;
            }
        }
        


        /// <summary>
        /// Fonction appelé afin de savoir si
        /// l'utilsiateur veut consulter les commentaires
        /// ou commenter ou noter la recette
        /// </summary>
        private void Bouton_AvisRec (object sender, RoutedEventArgs e)
        {
            Recette temp2 = (Application.Current as App).RecetteApp.RechercherRecette(NomRecette.Text); //On récupère la recette stocké dans la liste selon cette tempoaire qu'on possède
            if (pTemp == null) // Si l'utilisateur n'est pas connecté
            {
                AvisRecette win2 = new AvisRecette(temp2); //On créé une page "AvisRecette" du type utilisateur pas connecté
                win2.Show();
            }
            else
            {
                AvisRecette win2 = new AvisRecette(temp2,pTemp); //On créé une page "AvisRecette" du type utilisateur connecté
                win2.Show();
            }
            
        }



        /// <summary>
        /// Fonction appelé lorsque l'utilisateur
        /// veut revenir sur la page d'accueil
        /// ou en arrière.
        /// </summary>
        private void Click_Back_Home(object sender, RoutedEventArgs e)
        {

            if (pTemp == null) //Si l'utilisateur n'est pas connecté
            {
                Accueil win2 = new Accueil();
                this.Hide();
                win2.Show();
                return;
            }

            //Si l'utilisateur est connecté, on le renvoie sur l'accueil tout étant encore connecté
            foreach (Personne p in (Application.Current as App).LesUsers.AllUsers)
            {
                    
                if (p.Pseudo == pTemp.Pseudo) //Si on a bien trouvé l'utilisateur dans la liste totale
                {
                    Accueil win2 = new Accueil(p);
                    win2.Show();
                    this.Close();
                }
            }                
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            (Application.Current as App).RecetteApp.sauvegarde();
            (Application.Current as App).TousLesComms.sauvegarde();
            (Application.Current as App).LesUsers.sauvegarde();
        }
    }
}
