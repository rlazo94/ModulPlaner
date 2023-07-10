using Modulplaneditor.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace Modulplaneditor
{
    /// <summary>
    /// Interaktionslogik für ModulplanView.xaml
    /// </summary>
    public partial class ModulplanView : Window
    {
        public ModulplanViewModel ViewModel { get; } = new ModulplanViewModel();

        public ModulplanView()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            InhaltTreeItemViewModel selected = (sender as TreeView).SelectedItem as InhaltTreeItemViewModel;
            ViewModel.SelectedInhalt = selected;
        }
    }
}
