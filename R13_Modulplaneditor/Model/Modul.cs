using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulplaneditor.Model
{
    public class Modul
    {
        #region Private

        private int _id;
        private string _fach;
        private int _semester;
        private List<Inhalt> _inhalte;

        #endregion

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Fach
        {
            get { return _fach; }
            set { _fach = value; }
        }

        public int Semester
        {
            get { return _semester; }
            set { _semester = value; }
        }

        public List<Inhalt> Inhalte
        {
            get { return _inhalte; }
            set { _inhalte = value; }
        }

        public string Bezeichner { get => $"{Fach}-{Semester}. Semester"; }

        public Modul(int iD, string fach, int semester)
        {
            ID = iD;
            Fach = fach;
            Semester = semester;
            Inhalte = new List<Inhalt>();
        }
    }
}
