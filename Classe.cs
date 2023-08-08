using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPMoyennes
{

    class Classe
    {
        public string nomClasse { get; private set; }

        public List<Eleve> eleves = new List<Eleve>();

        public List<string> matieres = new List<string>();

        public List<double> moyenneMat = new List<double>();

        public Classe(string nom)
        {
            nomClasse = nom;
        }

        public void ajouterEleve(string prenom, string nom)
        {
            eleves.Add(new Eleve(nom, prenom));
        }

        public void ajouterMatiere(string nom)
        {
            matieres.Add(nom);
        }

        public void calculateMoyenneMatiere(int matiere)
        {
            double totalMoyenne = 0;
            
            foreach (Eleve eleve in eleves)
            {
                totalMoyenne += eleve.moyenneMat[matiere];
            }

            double moy = eleves.Count > 0 ? (double)Math.Round(totalMoyenne / eleves.Count, 2) : 0;
            moyenneMat.Insert(matiere, moy);
        }

        public double moyenneMatiere(int matiere)
        {
            return moyenneMat[matiere];
        }

        public double moyenneGeneral()
        {
            double totalMoy = 0;
            foreach (double moy in moyenneMat)
            {
                totalMoy += moy;
            }
            return Math.Round(totalMoy / moyenneMat.Count, 2);
        }

    }
}
