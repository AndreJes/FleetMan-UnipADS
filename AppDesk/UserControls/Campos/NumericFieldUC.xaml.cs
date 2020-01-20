using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

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
