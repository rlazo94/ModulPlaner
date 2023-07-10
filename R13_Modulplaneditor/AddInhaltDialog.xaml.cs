using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Modulplaneditor
{
    /// <summary>
    /// Interaction logic for AddInhaltDialog.xaml
    /// </summary>
    public partial class AddInhaltDialog : Window
    {
        public Inhalt Super { get; set; }

        public int ID { get; }

        public string Titel { get; set; }

        public AddInhaltDialog(int id, Inhalt super = null)
        {
            InitializeComponent();
            Super = super;
            ID = id;
            DataContext = this;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
