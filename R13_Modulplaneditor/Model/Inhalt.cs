using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulplaneditor
{
    public class Inhalt
    {
        public int ID { get; }
        public string Titel { get; }
        public List<Inhalt> Unterinhalte { get; set; }

        public Inhalt(int iD, string titel)
        {
            ID = iD;
            Titel = titel;
            Unterinhalte = new List<Inhalt>();
        }

        public override string ToString()
        {
            return $"Inhalt #{ID}: {Titel}";
        }

    }

}
