using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpCode
{
    [Serializable()]
    public class QuantiteUstensile
    {
        public string Nombre { get; private set; }
        public QuantiteUstensile(string nombre)
        {
            Nombre = nombre;
        }
        public override string ToString()
        {
            return Nombre;
        }
    }
}

