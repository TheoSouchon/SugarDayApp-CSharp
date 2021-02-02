using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CsharpCode
{
    [Serializable()]
    public class Personne
    {
        public string Pseudo { get; private set; }
        public string CheminImage { get; private set; }
        public string Description { get; private set; }
        public string Mot_De_Passe { get; private set; }
        public LivreRecette MesRecettes { get; private set; }


        public Personne(string pseudo,string mdp, string cheminImage)
        {
            Pseudo = pseudo;
            CheminImage = cheminImage;
            Mot_De_Passe = mdp;
            MesRecettes = new LivreRecette();
        }

        public Personne(string pseudo, string mdp)
        {
            Pseudo = pseudo;
            Mot_De_Passe = mdp;
            CheminImage = "img/Utilisateur.jpg";
            MesRecettes = new LivreRecette();

        }

        public void noter(int note, Recette recette)
        {
            recette.AjouterCommentaire(note);
        }

        public void ModifierDescription(string nvdescription)
        {
            Description = nvdescription;
        }

        public void ModifierCheminImage(string nvCheminImg)
        {
            CheminImage = nvCheminImg;
        }

        public override string ToString()
        {
            return Pseudo.ToString();
        }

    }
}