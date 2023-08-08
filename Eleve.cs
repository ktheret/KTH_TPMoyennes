using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPMoyennes
{
    class Eleve
    {
        public string nom { get; private set; }
        public string prenom { get; private set; }

        public List<Note> notes = new List<Note>();
        public List<double> moyenneMat = new List<double>();

        public Eleve (string nomEleve, string prenomEleve)
        {
            nom = nomEleve;
            prenom = prenomEleve;
        }

        public void ajouterNote(Note note)
        {
            notes.Add(note);
        }


        public void calculateMoyenneMatiere(int matiere)
        {
            double totalNotes = 0;
            int CountNotes = 0;
            foreach(Note note in notes)
            {
                if(note.matiere == matiere)
                {
                    totalNotes += note.note;
                    CountNotes++;
                }
            }

            double moy = CountNotes > 0 ? (double)Math.Round(totalNotes / CountNotes, 2) : 0;
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
            return Math.Round(totalMoy/moyenneMat.Count, 2);
        }
    }
}
