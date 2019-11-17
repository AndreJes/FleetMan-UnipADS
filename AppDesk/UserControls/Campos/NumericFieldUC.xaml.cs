using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppDesk.UserControls.Campos
{
    /// <summary>
    /// Interação lógica para NumericFieldUC.xam
    /// </summary>
    public partial class NumericFieldUC : UserControl, INotifyPropertyChanged
    {
        public int Value
        {
            get
            {
                return NumeroUD.Value.GetValueOrDefault();
            }
            set
            {
                NumeroUD.Value = value;
                NotifyPropertyChanged();
            }
        }

        public string Label
        {
            get
            {
                return UCLabel.Content.ToString();
            }
            set
            {
                UCLabel.Content = value;
                NotifyPropertyChanged();
            }
        }

        public NumericFieldUC()
        {
            InitializeComponent();
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }
    }
}
