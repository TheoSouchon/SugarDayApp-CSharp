using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace CsharpCode
{
    [Serializable]
    public class ListeCommentaire
    {
        
        //ObservableCollection : permet d'appeler INotifyCollectionChanged à chaque ajout ou suppression dans la liste (Actualise la liste dans la vue)
        public ObservableCollection<Commentaire> TousLesComms { get; set; } = new ObservableCollection<Commentaire>(); 
        
        public void AfficherListe()
        {
            foreach (Commentaire i in TousLesComms)
            {
                Console.WriteLine(i);
            }

        }



        /// <summary>
        /// Méthode appelé pour charger des données depuis
        /// un fichier binaire.
        /// </summary>
        public void chargement()
        {
            using (Stream stream = File.Open("Commentaire.bin", FileMode.Open))   //On utilise le 'flot/flux' stream pour lire les données du fichier
            {
                BinaryFormatter bin = new BinaryFormatter();   //Créer une variable permettant de seriealizer ou déséréaliser un objet
                var ListeChargement = (List<Commentaire>)bin.Deserialize(stream);   // On récupère dans une liste les object de type List<Recette> au travers du flot stream
                foreach (Commentaire r in ListeChargement)
                {
                    TousLesComms.Add(r);  //On ajoute chaque nouvelle recette prise depuis le fichier binaire dans la véritable listRecette 'livreRecette'
                }
            }
        }



        /// <summary>
        /// Méthode appelé pour sauvegarder des objets
        /// dans un fichier binaire.
        /// </summary>
        public void sauvegarde()
        {
            List<Commentaire> ListeSauvegarde = new List<Commentaire>();
            foreach (Commentaire r in TousLesComms)
            {
                ListeSauvegarde.Add(r);  //On copie la liste livreRecette dans une nouvelle liste
            }
            using (Stream stream = File.Open("Commentaire.bin", FileMode.Create))  //On utilise le 'flot/flux' stream pour créer les données du fichier
            {
                BinaryFormatter bin = new BinaryFormatter();   //Créer une variable permettant de seriealizer ou déséréaliser un objet
                bin.Serialize(stream, ListeSauvegarde);   //On déséréalize tous les objet de la listeSauvegardre au travers stream
            }

        }
    }
}
