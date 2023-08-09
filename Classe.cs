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

        public List<Eleve> eleves = new();
        public List<string> matieres = new();
        public List<double> moyenneMat = new();

        public Classe(string nom)
        {
            nomClasse = nom;
        }

        public void ajouterEleve(string prenom, string nom)
        {
            if(eleves.Count <= 30)
            {
                eleves.Add(new Eleve(nom, prenom));
            }
        }

        public void ajouterMatiere(string nom)
        {
            if(matieres.Count <= 10)
            {
                matieres.Add(nom);
            }
        }

        public double moyenneMatiere(int matiere)
        {
            return moyenneMat[matiere];
        }

        public void calculateMoyenneMatiere(int matiere)
        {
            double TotalMoyenne = 0;
            
            foreach (Eleve eleve in eleves)
            {
                TotalMoyenne += eleve.moyenneMat[matiere];
            }

            double moy = eleves.Count > 0 ? (double)Math.Round(TotalMoyenne / eleves.Count, 2) : 0;
            moyenneMat.Insert(matiere, moy);
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
