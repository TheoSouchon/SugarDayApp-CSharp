using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpCode
{
    [Serializable()]
    public class Ustensile
    {
        public string Nom { get; private set; }
        public QuantiteUstensile Quantite { get; private set; }

        public Ustensile(string nom)
        {
            Nom = nom;
            Quantite = null;
        }

        public Ustensile(string nom,QuantiteUstensile qté)
        {
            Nom = nom;
            Quantite = qté;
        }

        public override string ToString()
        {
            return Nom.ToString();
        }
    }
}
