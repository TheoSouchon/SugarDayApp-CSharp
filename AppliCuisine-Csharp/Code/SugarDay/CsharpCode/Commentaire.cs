using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Text;

namespace CsharpCode
{
    [Serializable()]
    public class Commentaire
    {     
        public string Message { get; private set; }
        public Personne Personne { get; private set; }

        public Commentaire(string message, Personne pers)
        {
            Message = message;
            Personne = pers;           
        }

    }
}
