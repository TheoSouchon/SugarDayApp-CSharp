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
using System.Windows.Shapes;

namespace SugarDay
{
    /// <summary>
    /// Logique d'interaction pour ListeIngredientActuel.xaml
    /// </summary>
    public partial class FenetreIngredientActuel : Window
    {
        //Variable temporaire qui serve à stocker des variables et à les utilisers dans les autres méthodes
        public Personne pTemp { get; private set; }

        public FenetreIngredientActuel(Personne p) //Seul un utilisateur connecté peut ajouer un ingrédient à sa recette
        {
            InitializeComponent();
            pTemp = p;
            ListeIngredientActuel.DataContext = (Application.Current as App).ListeIngrédientRecetteActuel;
            ListeIngredientXaml.ItemsSource = (Application.Current as App).ListeIngrédientTotal.Aliments;
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
        /// Edition de l'event "Click" du
        /// bouton Sauvegarder. Renvoie l'utilisateur
        /// sur la page précédente encore ouverte en 
        /// fermant celle-là. Le mot Sauvegarder n'est qu'une illusion.
        /// La sauvegarde s'est fait en amont dans une autre page.
        /// </summary>
        private void Sauvegarder_Ing(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



        /// <summary>
        /// Edition de l'event "SelectionChanged" de la
        /// liste total des ingrédients. Envoie sur l'ajout 
        /// de l'ingrédient en cliquant dessus
        /// </summary>
        private void ListBoxIng_ElementChangé(object sender, SelectionChangedEventArgs e)
        {
            Ingredient temp = ListeIngredientXaml.SelectedItem as Ingredient;
            AjouterIngredient win2 = new AjouterIngredient(temp.Aliment, this); //On envoie l'ingrédient sur lequel on a cliqué et la fenêtre actuelle pour l'acutaliser plus tard en paramètres
            win2.Show();

        }



        /// <summary>
        /// Fonction qui permet d'ajouter l'ingrédient dans la liste 
        /// d'ingrérdients actuel de cette fenêtre depuis une autre fenêtre
        /// </summary>
        public void SetIngredientActuel(Ingredient ing)
        {
            (Application.Current as App).ListeIngrédientRecetteActuel.Aliments.Add(ing); //On envoie l'ingredient dans une ObservableCollection pour que l'utilisateur sache ce qu'il rajoute au fur et à mesure
            (Application.Current as App).ListeIngrédientRecetteActuel2.Add(ing);  //On envoie l'ingredient dans une liste<Ustensile> pour pouvoir la copié dans la liste d'ingredient de la recette futur qui sera crée
            //Car on ne peut pas convertir une observableCollection en List
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            (Application.Current as App).RecetteApp.sauvegarde();
            (Application.Current as App).TousLesComms.sauvegarde();
            (Application.Current as App).LesUsers.sauvegarde();
        }
    }
}
