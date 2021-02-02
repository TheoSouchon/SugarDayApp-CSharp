using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpCode
{
    [Serializable()]
    public class Ingredient
    {
        public string Aliment { get; private set; }
        public QuantiteIngredient Quantite { get; private set; }

        public Ingredient(string aliment, QuantiteIngredient quantite)
        {
            Aliment = aliment;
            Quantite = quantite;
        }

        public Ingredient(string aliment)
        {
            Aliment = aliment;
            Quantite = null;
        }

        public override string ToString()
        {
            if (Quantite != null)
            {
                return Quantite + " " + Aliment;
            }
            else
            {
                return Aliment;
            }
        }


    }
}
