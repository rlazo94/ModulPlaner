using System.Collections.ObjectModel;

namespace Modulplaneditor.ViewModel
{
    public class InhaltTreeItemViewModel : TreeItemViewModelBase
    {
        #region Private

        private Inhalt _inhalt;
        private ObservableCollection<InhaltTreeItemViewModel> _unterinhalte;

        #endregion

        public Inhalt Inhalt
        {
            get { return _inhalt; }
            set { _inhalt = value; }
        }

        public ObservableCollection<InhaltTreeItemViewModel> Unterinhalte
        {
            get { return _unterinhalte; }
            private set { _unterinhalte = value; OnPropertyChanged(nameof(Unterinhalte)); }
        }

        public string Bezeichner { get => $"{Inhalt.Titel}"; }

        public int RootID { get => _superitem != null ? (_superitem as InhaltTreeItemViewModel).RootID : Inhalt.ID; }

        public int SuperID { get => _superitem != null ? (_superitem as InhaltTreeItemViewModel).Inhalt.ID : -1; }

        public InhaltTreeItemViewModel(Inhalt inhalt, TreeItemViewModelBase superitem = null) : base(superitem)
        {
            Inhalt = inhalt;
            Unterinhalte = new ObservableCollection<InhaltTreeItemViewModel>();

            foreach (Inhalt unterinhalt in inhalt.Unterinhalte)
            {
                Unterinhalte.Add(new InhaltTreeItemViewModel(unterinhalt, this));
            }
        }

        public InhaltTreeItemViewModel FindInhaltTreeItem(int id)
        {
            if (id == Inhalt.ID)
            {
                return this;
            }

            if (Unterinhalte.Count > 0)
            {
                foreach (InhaltTreeItemViewModel unter in Unterinhalte)
                {
                    InhaltTreeItemViewModel found = unter.FindInhaltTreeItem(id);
                    if (found != null)
                    {
                        return found;
                    }
                }
            }

            return null;
        }
    }
}
