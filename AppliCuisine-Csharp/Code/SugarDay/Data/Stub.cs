using System;
using System.Collections.Generic;
using System.IO;
using CsharpCode;

namespace Data
{
    public class Stub
    {

        /// <summary>
        /// Data de SugarDay
        /// </summary>


        public static LivreRecette RecetteUtilisateur()
        {
                LivreRecette RecetteApp = new LivreRecette();
                     
                if (File.Exists("Recette.bin")) //Charge des données passés dans l'application
            {
                    RecetteApp.chargement();
                }
                else //N'est exectuer qu'au premier lancement de l'application
                {
                    Commentaire cm1 = new Commentaire("Juste Insane la recette.zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz", new Personne("ConfusedGuy", "surprenant", "img\\confused.jpg"));
                    Commentaire cm2 = new Commentaire("Ici on est là", new Personne("SurprisedGuy", "surprenant", "img\\confused.jpg"));
                    Commentaire cm3 = new Commentaire("Tiens Tiens", new Personne("WaitGuy", "surprenant", "img\\confused.jpg"));
                    Commentaire cm4 = new Commentaire("The Emperor is pleased", new Personne("SpaceMarineGuy", "surprenant", "img\\confused.jpg"));

                    Recette r1 = new Recette("Eclair", "30", "img/eclairchoco.png", "Un éclair remplie de chocolat !", "Faire chauffer l'eau le sel et le beurre. À ébullition, " +
                        "ajouter en une fois la farine et mélanger jusqu'à obtenir une pâte consistante et compacte. Retirer du feu, et ajouter les oeufs entiers en les incorporant " +
                        "un à un. Placer la pâte sur une plaque huilée en une forme allongée. Faire cuire à 200°C durant 25 min. ", 4, 25, 2);
                    Recette r2 = new Recette("Flan Patissier", "40", "img/flan.jpg", "U super flan bien crémeux !", "Faire bouillir le lait avec la gousse de vanille fendue (dans le " +
                        "sens de la longueur). Pendant ce temps, mélanger la Maïzena (tamisée, c'est mieux) avec le sucre. et ajouter les oeufs bien battus.Mélanger le tout (bien homogène) ", 5, 20, 1);
                    Recette r3 = new Recette("Chouquettes", "30", "img/Chouquettes.jpg", "Des chouquettes sucrées pour les événements", "Mettre l'eau et le beurre dans une casserole et porter à ébullition. " +
                        "Lorsque le mélange bout, retirer la casserole du feu et ajouter d'un seul coup la farine avec le sel et la levure.Mélanger à l'aide d'une spatule jusqu'à ce que la pâte se décolle " +
                        "toute seule des bords de la casserole et ne fasse plus qu'une masse. ", 6, 50, 3);
                    Recette r4 = new Recette("Croissant", "4", "img/croissant.jpg", "Un croissant pour petit déjeuner parfait", "Tamiser la farine. Mélanger la poudre d'amande et de noisette avec la farine. " +
                        "Ajouter le sucre. Metter le beurre froid en petit cube. Pétrir pour en faire une pâte. Laisser 2h00 au frigidaire. Couper la pâte morceau par morceau. ", 2, 15, 4);

                    r1.Aliments.Add(new Ingredient("Eau", new QuantiteIngredient("25", Unite.cl)));
                    r1.Aliments.Add(new Ingredient("Sel", new QuantiteIngredient("10", Unite.g)));
                    r1.Aliments.Add(new Ingredient("Beurre", new QuantiteIngredient("100", Unite.g)));
                    r1.Aliments.Add(new Ingredient("Oeufs", new QuantiteIngredient("4", Unite.unité)));
                    r1.Aliments.Add(new Ingredient("Farine", new QuantiteIngredient("150", Unite.g)));
                    r1.Aliments.Add(new Ingredient("Chocolat", new QuantiteIngredient("200", Unite.g)));
                    r1.Outils.Add(new Ustensile("Cuillère en bois", new QuantiteUstensile("2")));
                    r1.Outils.Add(new Ustensile("Casserole", new QuantiteUstensile("1")));
                    r1.Outils.Add(new Ustensile("Poche à douille", new QuantiteUstensile("1")));

                    r2.Aliments.Add(new Ingredient("Pâte brisé", new QuantiteIngredient("1", Unite.unité)));
                    r2.Aliments.Add(new Ingredient("Lait", new QuantiteIngredient("1", Unite.l)));
                    r2.Aliments.Add(new Ingredient("Sucre", new QuantiteIngredient("150", Unite.g)));
                    r2.Aliments.Add(new Ingredient("Maïzena", new QuantiteIngredient("90", Unite.g)));
                    r2.Aliments.Add(new Ingredient("Gousse de vanille", new QuantiteIngredient("1", Unite.unité)));
                    r2.Outils.Add(new Ustensile("Tamis", new QuantiteUstensile("1")));
                    r2.Outils.Add(new Ustensile("Casserole", new QuantiteUstensile("1")));
                    r2.Outils.Add(new Ustensile("Fourchette", new QuantiteUstensile("1")));

                    r3.Aliments.Add(new Ingredient("Eau", new QuantiteIngredient("25", Unite.cl)));
                    r3.Aliments.Add(new Ingredient("Sel", new QuantiteIngredient("10", Unite.g)));
                    r3.Aliments.Add(new Ingredient("Beurre", new QuantiteIngredient("100", Unite.g)));
                    r3.Aliments.Add(new Ingredient("Oeufs", new QuantiteIngredient("4", Unite.unité)));
                    r3.Aliments.Add(new Ingredient("Farine", new QuantiteIngredient("150", Unite.g)));
                    r3.Aliments.Add(new Ingredient("Sucre perlé", new QuantiteIngredient("200", Unite.g)));
                    r3.Outils.Add(new Ustensile("Cuillère en bois", new QuantiteUstensile("1")));
                    r3.Outils.Add(new Ustensile("Saladier", new QuantiteUstensile("1")));
                    r3.Outils.Add(new Ustensile("Fouet", new QuantiteUstensile("1")));

                    r4.Aliments.Add(new Ingredient("Eau", new QuantiteIngredient("70", Unite.cl)));
                    r4.Aliments.Add(new Ingredient("Sel", new QuantiteIngredient("10", Unite.g)));
                    r4.Aliments.Add(new Ingredient("Beurre", new QuantiteIngredient("180", Unite.g)));
                    r4.Aliments.Add(new Ingredient("Oeufs", new QuantiteIngredient("1", Unite.unité)));
                    r4.Aliments.Add(new Ingredient("Farine", new QuantiteIngredient("500", Unite.g)));
                    r4.Aliments.Add(new Ingredient("Sucre perlé", new QuantiteIngredient("200", Unite.g)));
                    r4.Outils.Add(new Ustensile("Fouet", new QuantiteUstensile("1")));
                    r4.Outils.Add(new Ustensile("Couvercle", new QuantiteUstensile("1")));
                    r4.Outils.Add(new Ustensile("Four", new QuantiteUstensile("1")));

                    r1.Messages.TousLesComms.Add(cm1);
                    r1.Messages.TousLesComms.Add(cm2);
                    r1.Messages.TousLesComms.Add(cm3);
                    r2.Messages.TousLesComms.Add(cm2);
                    r3.Messages.TousLesComms.Add(cm3);
                    r4.Messages.TousLesComms.Add(cm4);


                    RecetteApp.livreRecette.Add(r1);
                    RecetteApp.livreRecette.Add(r2);
                    RecetteApp.livreRecette.Add(r3);
                    RecetteApp.livreRecette.Add(r4);
                }            
         return RecetteApp;
        }

        public static ListeCommentaire TousLesComms()
        {
            ListeCommentaire ListeTousLesComms = new ListeCommentaire();
            if (File.Exists("Utilisateur.bin")) //Charge des données passés dans l'application
            {
                ListeTousLesComms.chargement();
            }
            else //N'est exectuer qu'au premier lancement de l'application
            {
                ListeTousLesComms.TousLesComms.Add(new Commentaire("Juste Insane la recette.zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz", new Personne("ConfusedGuy", "surprenant", "img\\confused.jpg")));
            ListeTousLesComms.TousLesComms.Add(new Commentaire("Ici on est là", new Personne("SurprisedGuy", "surprenant", "img\\confused.jpg")));
            ListeTousLesComms.TousLesComms.Add(new Commentaire("Tiens Tiens", new Personne("WaitGuy", "surprenant", "img\\confused.jpg")));
            ListeTousLesComms.TousLesComms.Add(new Commentaire("The Emperor is pleased", new Personne("SpaceMarineGuy", "surprenant", "img\\confused.jpg")));
            }
            return ListeTousLesComms;
        }

        public static ListeIngredient TousLesIngrédients()
        {
            ListeIngredient listeIngred = new ListeIngredient();
            listeIngred.Aliments.Add(new Ingredient("Eau"));
            listeIngred.Aliments.Add(new Ingredient("Farine"));
            listeIngred.Aliments.Add(new Ingredient("Oeufs"));
            listeIngred.Aliments.Add(new Ingredient("Eau"));
            listeIngred.Aliments.Add(new Ingredient("Sel"));
            listeIngred.Aliments.Add(new Ingredient("Beurre"));
            listeIngred.Aliments.Add(new Ingredient("Oeufs"));
            listeIngred.Aliments.Add(new Ingredient("Farine"));
            listeIngred.Aliments.Add(new Ingredient("Sucre perlé"));
            return listeIngred;
        }

        public static ListeUstensile TousLesUstensiles()
        {
            ListeUstensile listeUstensile = new ListeUstensile();
            listeUstensile.Outils.Add(new Ustensile("Fourchette"));
            listeUstensile.Outils.Add(new Ustensile("Bol"));
            listeUstensile.Outils.Add(new Ustensile("Cuillère"));
            listeUstensile.Outils.Add(new Ustensile("Fouet"));
            listeUstensile.Outils.Add(new Ustensile("Couvercle"));
            listeUstensile.Outils.Add(new Ustensile("Four"));
            return listeUstensile;
        }


        public static ListeUtilisateur TousLesUtilisateurs ()
        {
            ListeUtilisateur TousLesUtilisateurs = new ListeUtilisateur();
            if (File.Exists("Utilisateur.bin")) //Charge des données passés dans l'application
            {
                TousLesUtilisateurs.chargement();
            }
            else //N'est exectuer qu'au premier lancement de l'application
            {
                TousLesUtilisateurs.AllUsers.Add(new Personne("Finasty2", "mdp1"));
            }
            return TousLesUtilisateurs;
        }


        //les 2 premières sont observables collection
        public static ListeIngredient IngredientRecetteActuel()
        {
            ListeIngredient IngredientActuel = new ListeIngredient();
            return IngredientActuel;
        }

        public static List<Ingredient> IngredientRecetteActuel2()
        {
            List<Ingredient> IngredientActuel = new List<Ingredient>();
            return IngredientActuel;
        }

        //les 2 dernières sont du type List<>
        public static List<Ustensile> UstensileRecetteActuel2()
        {
            List<Ustensile> IngredientActuel = new List<Ustensile>();
            return IngredientActuel;
        }
        public static ListeUstensile UstensileRecetteActuel()
        {
            ListeUstensile UstensileActuel = new ListeUstensile();
            return UstensileActuel;
        }

        
        





        /// <summary>
        /// TEST POUR LA CONSOLE
        /// </summary>
        /// 





        /// <summary>
        /// Base de données pour les ingredients (liste de tous les ingredients de l'app sans unité ni quantité)
        /// </summary>
        public static ListeIngredient CreerListIngredientSansUniteEtQuantité()
        {
            ListeIngredient listeIngredient = new ListeIngredient();
            Ingredient Tomate = new Ingredient("Tomate");            
            listeIngredient.Aliments.Add(Tomate);
            return listeIngredient;
        }


        /// <summary>
        /// Base de données pour les Utilisateurs (liste de tous les Utilisateurs de l'app)
        /// </summary>
        public static ListeUtilisateur CreerListUtilisateur()
        {
            ListeUtilisateur listeUtilisateur = new ListeUtilisateur();
            //listeUtilisateur.AjouterUtilisateur(new Personne("Alpha","mpd1", "ici/la/img", true));
            return listeUtilisateur;
        }

        /// <summary>
        /// Création d'une recette (recette + liste ingreidents)
        /// </summary>
        public static Recette CreerRecetteA()
        {
            Recette recette = new Recette("Gateau choco", "40", "ici/la/img", "Super bon", "Ca puis ci,puis ca");

            Unite uniteFarine = Unite.kg;
            QuantiteIngredient farineQté = new QuantiteIngredient("1", uniteFarine);
            Ingredient farine = new Ingredient("Farine", farineQté);

            Unite uniteOeufs = Unite.unité;
            QuantiteIngredient oeufsQté = new QuantiteIngredient("4", uniteOeufs);
            Ingredient oeufs = new Ingredient("Oeuf(s)", oeufsQté);

            recette.Aliments.Add(farine);
            recette.Aliments.Add(oeufs);
            return recette;
        }

        /// <summary>
        /// Création d'une recette (recette + liste ingredient + liste ustensiles + type)
        /// </summary>
        public static Recette CreerRecetteB()
        {
            Recette recette = new Recette("Gateau choco", "40", "ici/la/img", "Super bon", "Ca puis ci,puis ca");

            Unite uniteChocolat = Unite.g;
            QuantiteIngredient chocolatQté = new QuantiteIngredient("50", uniteChocolat);
            Ingredient chocolat = new Ingredient("Chocolat", chocolatQté);

            Unite uniteSucre = Unite.g;
            QuantiteIngredient sucreQté = new QuantiteIngredient("9", uniteSucre);
            Ingredient sucre = new Ingredient("Sucre", sucreQté);

            Ustensile fouet = new Ustensile("Fouet");
            Ustensile spatule = new Ustensile("Spatule");
            recette.Aliments.Add(chocolat);
            recette.Aliments.Add(sucre);
            recette.Outils.Add(fouet);
            recette.Outils.Add(spatule);
            return recette;
        }

        /// <summary>
        /// Notation d'une recette et commentaire
        /// </summary>
        public static Recette CreerRecetteC()
        {
            Recette recette = new Recette("Gateau coco", "40", "ici/la/img", "Super bon", "Ca puis ci,puis ca");
            Personne testeur = new Personne("Finasty2", "mdp1", "ici/la/imgprofil");
            //Problème : une personne peut noter plusieurs fois (Dictonnaire ?)
            testeur.noter(4, recette);
            testeur.noter(2, recette);
            //testeur.commenter("Très bon", recette);
            return recette;
        }

        /// <summary>
        /// Test description Personne / Utilisateur type admin
        /// </summary>
        public static void TestUser()
        {
            Personne testeur = new Personne("Finasty2","mdp1", "ici/la/imgprofil");
            testeur.ModifierDescription("Salut c'est moi");
            testeur.ToString();
        }

        /// <summary>
        /// Base de données pour les ustensiles (liste de tous les ustensiles de l'app)
        /// </summary>
        /// 
        public static ListeUstensile CreerListUstensileDeBase()
        {
            ListeUstensile listeUstensile = new ListeUstensile();
            listeUstensile.Outils.Add(new Ustensile("Fourchette"));
            listeUstensile.Outils.Add(new Ustensile("Bol"));
            listeUstensile.Outils.Add(new Ustensile("Cuillère"));
            return listeUstensile;
        }
    }
}

