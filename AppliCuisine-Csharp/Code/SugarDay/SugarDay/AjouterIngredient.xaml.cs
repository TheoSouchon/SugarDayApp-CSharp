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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SugarDay
{
    /// <summary>
    /// Logique d'interaction pour Ajouter_Ingredient.xaml
    /// </summary>
    public partial class AjouterIngredient : Window
    {

        public FenetreIngredientActuel FenetreTemp { get; set; } //Variable permettant de stocker la fenêtre précédante pour AjouterIngredient.xaml.cs
        public string Unité { get; private set; }


        /// <summary>
        /// Recupère le nom de l'ingrédient à ajouter
        /// et garde en mémoire la page précédente afin de l'actualisé
        /// </summary>
        public AjouterIngredient(string nom, FenetreIngredientActuel FenetrePrec)
        {            
            InitializeComponent();
            Aliment_nom.Text = nom;
            FenetreTemp = FenetrePrec;
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
                Aliment_nom.Foreground = brush2;
                GridTotal.Background = brush;
                Titre2.Foreground = brush2;
                Titre3.Foreground = brush2;
            }
            else //En mode normal
            {
                Aliment_nom.Background = brush3;
                GridTotal.Background = brush3;
                Titre2.Foreground = brush;
                Titre3.Foreground = brush;
            }
        }



        /// <summary>
        /// Edition de l'event "Click" du
        /// bouton ajouter. Ajoute l'ingrédient à la liste d'ingredient
        /// de la fenêtre précédente.
        /// </summary>
        private void Ajout_confirmation(object sender, RoutedEventArgs e)
        {            
            Ingredient ingActuel = new Ingredient(Aliment_nom.Text, new QuantiteIngredient(Quantité_Ing.Text, (Unite)Unité_select.SelectedItem));  //Créé un nouvel ingrédient avec comme attributs les différents champs de la vue       
            if (FenetreTemp.IsLoaded) //si la fenêtre précédente (stocké dans FenetreTemp) est toujours ouverte
            {
                FenetreTemp.SetIngredientActuel(ingActuel); //On appel une méthode pour ajouter l'ingrédient à la liste de la fenêtre précédente
                this.Close();
            }
            
        }



        /// <summary>
        /// Edition de l'event "PreviewTextInput" du
        /// champ de quantité. Permet le contrôle de la saisie
        /// avec des expressions régulières
        /// </summary>
        private void QuantiteIng_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex Caract = new Regex("[^0-9]+"); //Créé une nouvelle regex qui possède plusieurs caractère compris enre 0 et 9
            e.Handled = Caract.IsMatch(e.Text); //Vérifie que le texte qui a été tenté correspond bien à la regex instancié
        }

    }
    
}
