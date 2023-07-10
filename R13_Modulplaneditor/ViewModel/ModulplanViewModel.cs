using Modulplaneditor.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Modulplaneditor.ViewModel
{
    public class ModulplanViewModel : ViewModelBase
    {
        #region Private

        private readonly ModulDatabase _db;
        private ObservableCollection<Modul> _module;
        private Modul _selectedModulToEdit;
        private Modul _selectedModulToView;
        private InhaltTreeItemViewModel _selectedInhalt;

        #endregion

        /// <summary>
        /// Gemeinsame Datenquelle für die ComboBox
        /// </summary>
        public ObservableCollection<Modul> Module
        {
            get { return _module; }
            set { _module = value; }
        }

        #region Links

        public Modul SelectedModulToEdit
        {
            get 
            { 
                return _selectedModulToEdit; 
            }
            set 
            {
                _selectedModulToEdit = value;

                LoadInhalt(value, InhalteSelectedModulToEdit);
                OnPropertyChanged(nameof(SelectedModulToEdit));
                OnPropertyChanged(nameof(InhalteSelectedModulToEdit));
            }
        }

        public ObservableCollection<InhaltTreeItemViewModel> InhalteSelectedModulToEdit { get; private set; }

        public InhaltTreeItemViewModel SelectedInhalt
        {
            get 
            { 
                return _selectedInhalt;
            }
            set 
            {
                _selectedInhalt = value;
                OnPropertyChanged(nameof(SelectedInhalt));
            }
        }

        #endregion

        #region Rechts

        public Modul SelectedModulToView
        {
            get
            {
                return _selectedModulToView;
            }
            set
            {
                _selectedModulToView = value;

                LoadInhalt(value, InhalteSelectedModulToView);
                OnPropertyChanged(nameof(SelectedModulToView));
                OnPropertyChanged(nameof(InhalteSelectedModulToView));
            }
        }

        public ObservableCollection<InhaltTreeItemViewModel> InhalteSelectedModulToView { get; private set; }

        #endregion

        public ICommand DeleteInhaltCommand { get => new RelayCommand(DeleteInhalt); }
        public ICommand AddInhaltCommand { get => new RelayCommand(AddInhalt); }

        public ModulplanViewModel()
        {
            _db = new ModulDatabase();
            Module = new ObservableCollection<Modul>(_db.LadeModule());
            InhalteSelectedModulToEdit = new ObservableCollection<InhaltTreeItemViewModel>();
            InhalteSelectedModulToView = new ObservableCollection<InhaltTreeItemViewModel>();
        }

        private void DeleteInhalt(object param)
        {
            if (SelectedInhalt == null) return;

            MessageBoxResult result = MessageBox.Show(
                "Wollen Sie den Inhalt und dessen Unterinhalte löschen?", 
                "Löschen", 
                MessageBoxButton.YesNo, 
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                int rootID = SelectedInhalt.RootID;
                int superID = SelectedInhalt.SuperID;
                _db.DeleteInhalt(SelectedInhalt.Inhalt);

                // NEU-LADEN
                LoadInhalt(SelectedModulToEdit, InhalteSelectedModulToEdit);
                // EXPAND BIS ZUM SUPER-ITEM
                if (superID > 0)
                {
                    InhaltTreeItemViewModel root = InhalteSelectedModulToEdit.SingleOrDefault(i => i.Inhalt.ID == rootID);
                    root.FindInhaltTreeItem(superID).IsExpanded = true;
                }
            }
        }

        private void AddInhalt(object param)
        {
            int lastID = _db.GetLastID();
            InhaltTreeItemViewModel selected = SelectedInhalt;
            
            AddInhaltDialog dialog = new AddInhaltDialog(lastID + 1, selected != null ? selected.Inhalt : null);
            dialog.ShowDialog();

            if (dialog.DialogResult == true)
            {
                _db.InsertInhalt(
                    new Inhalt(dialog.ID, dialog.Titel),
                    SelectedModulToEdit, 
                    dialog.Super);

                LoadInhalt(SelectedModulToEdit, InhalteSelectedModulToEdit);

                if (SelectedModulToView?.ID == SelectedModulToEdit?.ID)
                {
                    LoadInhalt(SelectedModulToView, InhalteSelectedModulToView);
                }
                
                // EXPAND BIS ZUM SUPER-ITEM
                if (selected != null)
                {
                    InhaltTreeItemViewModel root = InhalteSelectedModulToEdit.SingleOrDefault(i => i.Inhalt.ID == selected.RootID);
                    root.FindInhaltTreeItem(selected.Inhalt.ID).IsExpanded = true;
                }
            }
        }

        private void LoadInhalt(Modul modul, ObservableCollection<InhaltTreeItemViewModel> list)
        {
            list.Clear();
            foreach (Inhalt inhalt in _db.LadeOberinhalte(modul.ID))
            {
                list.Add(new InhaltTreeItemViewModel(inhalt));
            }
        }
    }
}
