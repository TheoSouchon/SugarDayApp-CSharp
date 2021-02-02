using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CsharpCode
{
    public class ListeIngredient
    {

        //ObservableCollection : permet d'appeler INotifyCollectionChanged à chaque ajout ou suppression dans la liste (Actualise la liste dans la vue)
        public ObservableCollection<Ingredient> Aliments { get; set; } = new ObservableCollection<Ingredient>(); //arraylist meilleur pour consultation


    }
}
