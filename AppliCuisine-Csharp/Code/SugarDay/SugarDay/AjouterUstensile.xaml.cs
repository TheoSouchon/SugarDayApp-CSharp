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
    /// Logique d'interaction pour AjouterUstensile.xaml
    /// </summary>
    public partial class AjouterUstensile : Window
    {

        public FenetreUstensileActuel FenetreTemp { get; set; }
        public string Unité { get; private set; }


        public AjouterUstensile(string nom, FenetreUstensileActuel FenetrePrec)
        {
            InitializeComponent();
            DarkMode();
            Ustensile_nom.Text = nom;
            FenetreTemp = FenetrePrec;
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
                Ustensile_nom.Foreground = brush2;
                GridTotal.Background = brush;
                Titre2.Foreground = brush2;
                Image.Background = brush2;
            }
            else //En mode normal
            {
                Ustensile_nom.Background = brush3;
                GridTotal.Background = brush3;
                Titre2.Foreground = brush;
                Image.Background = brush2;
            }
        }




        /// <summary>
        /// Edition de l'event "Click" du
        /// bouton ajouter. Ajoute l'ustensile à la liste d'ustensile
        /// de la fenêtre précédente.
        /// </summary>
        private void Ajout_confirmation(object sender, RoutedEventArgs e)
        {
            Ustensile ustActuel = new Ustensile(Ustensile_nom.Text, new QuantiteUstensile(QuantiteUst.Text));   //Créé un nouvel ingrédient avec comme attributs les différents champs de la vue
            if (FenetreTemp.IsLoaded)   //si la fenêtre précédente (stocké dans FenetreTemp) est toujours ouverte
            {
                FenetreTemp.SetUstensileActuel(ustActuel); //On appel une méthode pour ajouter l'ingrédient à la liste de la fenêtre précédente
                this.Close();
            }

        }



        /// <summary>
        /// Edition de l'event "PreviewTextInput" du
        /// champ de quantité. Permet le contrôle de la saisie
        /// avec des expressions régulières
        /// </summary>
        private void QuantiteUst_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex Caract = new Regex("[^0-9]+");//Créé une nouvelle regex qui possède plusieurs caractère compris enre 0 et 9
            e.Handled = Caract.IsMatch(e.Text); //Vérifie que le texte qui a été tenté correspond bien à la regex instancié
        }
    }
}
