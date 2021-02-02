using System;
using CsharpCode;
using Data;

namespace Programme
{
    class Program
    {
        static void Main(string[] args)
        {
            //*unique : Si on créer plusieurs ListeUstensile/Utilisateur/Ingredient lesl istes vont s'additionner
            //Liste de tous les ustensiles (unique)
            ListeUstensile UnPetitNom = Data.Stub.CreerListUstensileDeBase();
            UnPetitNom.ToString();

            //Liste de tous les utilisateurs (unique)
            ListeUtilisateur AllUsers = Data.Stub.CreerListUtilisateur();
            //AllUsers.AfficherListe();

            //Liste de tous les ingredients (unique)
            ListeIngredient TousLesIngredients = Data.Stub.CreerListIngredientSansUniteEtQuantité();
            TousLesIngredients.ToString();

            Console.WriteLine("*************");
            //test création recette A
            Recette recetteA = Data.Stub.CreerRecetteA();
            recetteA.ToString();
            Console.WriteLine("*************");
            //test création recette B
            Recette recetteB = Data.Stub.CreerRecetteB();
            recetteB.ToString();
            recetteB.ToString();
            Console.WriteLine("*************");
            //test création recette C
            Recette recetteC = Data.Stub.CreerRecetteC();
            recetteC.ToString();
            recetteC.ToString();
            Console.WriteLine("*************");
            //test UserDesc
            Data.Stub.TestUser();


        }
    }
}

