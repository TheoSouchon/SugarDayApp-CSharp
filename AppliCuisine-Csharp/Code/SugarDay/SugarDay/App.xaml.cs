using CsharpCode;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;


namespace SugarDay
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 
     
    public partial class App : Application

    {
        public ListeUtilisateur LesUsers = Data.Stub.TousLesUtilisateurs(); //Liste de tous les utilisateurs
        public LivreRecette RecetteApp = Data.Stub.RecetteUtilisateur(); //Liste de toutes les recettes de l'application
        public ListeIngredient ListeIngrédientRecetteActuel = Data.Stub.IngredientRecetteActuel(); //Liste des ingrédients de la recette actuel
        public List<Ingredient> ListeIngrédientRecetteActuel2 = Data.Stub.IngredientRecetteActuel2(); //Liste des ingrédients de la recette actuel
        public ListeUstensile ListeUstensileRecetteActuel = Data.Stub.UstensileRecetteActuel(); // Liste des ustensiles de la recette actuel
        public List<Ustensile> ListeUstensileRecetteActuel2 = Data.Stub.UstensileRecetteActuel2(); // Liste des ustensiles de la recette actuel
        public ListeUstensile ListeUstensileTotal = Data.Stub.TousLesUstensiles(); //Liste de tous les ustensiles de l'application
        public ListeIngredient ListeIngrédientTotal = Data.Stub.TousLesIngrédients(); //Liste de tous les ustensiles de l'application
        public ListeCommentaire TousLesComms = Data.Stub.TousLesComms(); //Liste de tous les commentaires
        public int ColorTestGlobal=1; //Indication du DarkMode = off sur ColorTestGlobal impair

    }
}
