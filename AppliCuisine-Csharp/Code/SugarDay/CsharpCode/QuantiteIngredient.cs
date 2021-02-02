using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpCode
{
    [Serializable()]
    public class QuantiteIngredient
    {
        public string Nombre { get; private set; }
        public Unite Unité { get; private set; }

        public QuantiteIngredient(string nombre, Unite unite)
        {
            Nombre = nombre;
            Unité = unite;
        }

        public override string ToString()
        {
            return Nombre + " " + Unité.ToString();
        }
    }
}