using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CodeBehindProj
{
    /// <summary>
    /// Représente une recette
    /// </summary>
    public class Recette
    {

        private static List<int> Notes;

        public Recette(string nom, int tpsPrepa, string cheminImg, string description)
        {
            Nom = nom;
            TpsPrepa = tpsPrepa;
            Image = cheminImg;
            Description = description;
            Notes = new List<int>();
        }

        //Constructeur supplémentaire pour les tendances
        public Recette(string nom, string cheminImg)
        {
            Nom = nom;
            Image = cheminImg;
        }

        public string Nom { get; set; } ///sert de déclaration, de getteur, de setteur (tout à la fois)

        public string Description { get; set; }

        public string Image { get; set; }

        public int TpsPrepa { get; set; }

        public int Difficulté { get; private set; }


        public void AfficherNote()
        {
            Console.WriteLine(Notes.Average());
        }
        override public string ToString()
        {
            return $"{Nom} : {Description}";
        }
    }
}
