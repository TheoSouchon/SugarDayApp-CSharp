using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

namespace CsharpCode
{

    [Serializable]
    
    public class LivreRecette : Persistance
    {
        public List<Recette> livreRecette { get; set; } = new List<Recette>();



        /// <summary>
        /// Méthode appelé pour charger des données depuis
        /// un fichier binaire.
        /// </summary>
        public void chargement()
        {
            using (Stream stream = File.Open("Recette.bin", FileMode.Open)) //On utilise le 'flot/flux' stream pour lire les données du fichier
            {
                BinaryFormatter bin = new BinaryFormatter(); //Créer une variable permettant de seriealizer ou déséréaliser un objet
                var ListeChargement = (List<Recette>)bin.Deserialize(stream); // On récupère dans une liste les object de type List<Recette> au travers du flot stream
                foreach (Recette r in ListeChargement) 
                {
                    livreRecette.Add(r); //On ajoute chaque nouvelle recette prise depuis le fichier binaire dans la véritable listRecette 'livreRecette'
                }
            }
        }


        public Recette RechercherRecette(string NomCherché)
        {
            foreach (Recette r in livreRecette) // Pour chaque Recette dans la liste livreRecette
            {
                if (r.Nom == NomCherché) //Si le nom de l'acutel "Recette" et le nom recu en paramètre correspondent
                {
                    return r; //On retourne la recette
                }
            }
            return null; //Sinon on retourne 'null'
        }



        /// <summary>
        /// Méthode appelé pour sauvegarder des objets
        /// dans un fichier binaire.
        /// </summary>
        public void sauvegarde()
        {
            List<Recette> ListeSauvegarde = new List<Recette>();
            foreach (Recette r in livreRecette)
            {
                ListeSauvegarde.Add(r); //On copie la liste livreRecette dans une nouvelle liste
            }
            using (Stream stream = File.Open("Recette.bin", FileMode.Create)) //On utilise le 'flot/flux' stream pour créer les données du fichier
            {
                BinaryFormatter bin = new BinaryFormatter(); //Créer une variable permettant de seriealizer ou déséréaliser un objet
                bin.Serialize(stream, ListeSauvegarde); //On déséréalize tous les objet de la listeSauvegardre au travers stream
            }

        }


        /// <summary>
        /// Métohde appelé pour l'application dès l'accueil 
        /// pour sortir le top3 de toutes les recettes et
        /// les mettre en vitrine
        /// </summary>
        public List<Recette> Top3RecetteNote()
        {
            //Une nouvelle recette correspondant aux 3 recettes ayant la plus haute note_final (OrderByDescending)
            List<Recette> ListeTop3 = livreRecette.OrderByDescending(o => o.Note_final).Take(3).ToList(); 
            return ListeTop3;
        }

    }
}
