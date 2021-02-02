using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace CsharpCode
{
    public class ListeUtilisateur
    {

        public List<Personne> AllUsers { get; set; } = new List<Personne>();        

        
        public Personne RechercherPersonne(string Pseudo)
        {
            foreach (Personne i in AllUsers) // Pour chaque Personne dans la liste AllUsers
            {
                if(i.Pseudo==Pseudo) //Si le Pseudo de l'acutel "Personne" et le pseudo recu en paramètre correspondent
                {
                    return i; //On retourne la personne
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
            List<Personne> ListeSauvegarde = new List<Personne>();
            foreach (Personne r in AllUsers)
            {
                ListeSauvegarde.Add(r);  //On copie la liste livreRecette dans une nouvelle liste
            }
            using (Stream stream = File.Open("Utilisateur.bin", FileMode.Create))  //On utilise le 'flot/flux' stream pour créer les données du fichier
            {
                BinaryFormatter bin = new BinaryFormatter();  //Créer une variable permettant de seriealizer ou déséréaliser un objet
                bin.Serialize(stream, ListeSauvegarde);   //On déséréalize tous les objet de la listeSauvegardre au travers stream
            }

        }



        /// <summary>
        /// Méthode appelé pour charger des données depuis
        /// un fichier binaire.
        /// </summary>
        public void chargement()
        {
            using (Stream stream = File.Open("Utilisateur.bin", FileMode.Open)) //On utilise le 'flot/flux' stream pour lire les données du fichier
            {
                BinaryFormatter bin = new BinaryFormatter(); //Créer une variable permettant de seriealizer ou déséréaliser un objet
                var ListeChargement = (List<Personne>)bin.Deserialize(stream);  // On récupère dans une liste les object de type List<Recette> au travers du flot stream
                foreach (Personne r in ListeChargement)
                {
                    AllUsers.Add(r);  //On ajoute chaque nouvelle recette prise depuis le fichier binaire dans la véritable listRecette 'livreRecette'
                }
            }
        }

    }
}
