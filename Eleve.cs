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

        public List<Note> notes = new();
        public List<double> moyenneMat = new();

        public Eleve (string nomEleve, string prenomEleve)
        {
            nom = nomEleve;
            prenom = prenomEleve;
        }

        public void ajouterNote(Note note)
        {
            if(notes.Count <= 200)
            {
                notes.Add(note);
            }
        }

        public double moyenneMatiere(int matiere)
        {
            return moyenneMat[matiere];
        }

        public void calculateMoyenneMatiere(int matiere)
        {
            double TotalNotes = 0;
            int CountNotes = 0;
            foreach(Note note in notes)
            {
                if(note.matiere == matiere)
                {
                    TotalNotes += note.note;
                    CountNotes++;
                }
            }

            double moy = CountNotes > 0 ? (double)Math.Round(TotalNotes / CountNotes, 2) : 0;
            moyenneMat.Insert(matiere, moy);
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
