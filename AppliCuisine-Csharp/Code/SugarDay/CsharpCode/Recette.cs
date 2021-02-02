using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace CsharpCode
{
    /// <summary>
    /// Représente une recette
    /// </summary>

    [Serializable()]
    public class Recette
    {
        public int NbPers {get; private set;}
        public int TpsCuisson { get; private set;}
        public List<int> Notes { get; private set;}
        public List<Ingredient> Aliments { get; private set;}
        public List<Ustensile> Outils { get; private set;}

        public ListeCommentaire Messages { get; private set;}

        public string Nom { get; private set; } ///sert de déclaration, de getteur, de setteur (tout à la fois)
        public string Description { get; private set; }
        public double Note_final { get; private set; }
        public string Image { get; private set; }
        public string TpsPrepa { get; private set; }
        public int Difficulté { get; private set; }
        public string Préparation { get; private set; }



        public Recette(string nom, string tpsPrepa, string cheminImg, string description,string préparation)
        {
            Nom = nom;
            TpsPrepa = tpsPrepa;
            Image = cheminImg;
            Description = description;
            Aliments = new List<Ingredient>();
            Outils = new List<Ustensile>();
            Notes = new List<int>();
            Messages = new ListeCommentaire();
            Préparation = préparation;
        }

        public Recette(string nom, string tpsPrepa, string cheminImg, string description, string préparation, int nbPers, int tpsCuisson, int difc)
        {
            Nom = nom;
            TpsPrepa = tpsPrepa;
            Image = cheminImg;
            Description = description;
            Aliments = new List<Ingredient>();
            Outils = new List<Ustensile>();
            Notes = new List<int>();
            Messages = new ListeCommentaire();
            Préparation = préparation;
            NbPers = nbPers;
            TpsCuisson = tpsCuisson;
            Difficulté = difc;
        }

        public void MoyenneNote()
        {
            if (Notes.Count!=0)
            {
                Note_final = Notes.Average();
            }
            
        }

        public void MettreDifc(int dfc)
        {
            Difficulté = dfc;
        }

        public void AjouterCommentaire(int note)
        {
            Notes.Add(note);
        }

        public void SetNbPersonne(int nombrePersonne)
        {
            NbPers = nombrePersonne;
        }

        public void SetTpsCuisson(int tpsDeCuisson)
        {
            TpsCuisson = tpsDeCuisson;
        }

        public void SetTpsPrepa(string tpsDeCuisson)
        {
            TpsPrepa = tpsDeCuisson;
        }

        public void SetListeUstentile(List<Ustensile> ListeUstRec)
        {
            this.Outils = ListeUstRec;
        }

        public void SetListeIngredient(List<Ingredient> ListeIngRec)
        {
            this.Aliments = ListeIngRec;
        }

        public void ModifierImage(string nvImage)
        {
            Image = nvImage;
        }
        override public string ToString()
        {
            return $"{Nom} : {Description}";
        }
    }
}
