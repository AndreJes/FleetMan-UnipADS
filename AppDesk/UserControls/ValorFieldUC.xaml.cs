using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace AppDesk.UserControls
{
    /// <summary>
    /// Interação lógica para ValorFieldUC.xam
    /// </summary>
    public partial class ValorFieldUC : UserControl, INotifyPropertyChanged
    {
        public double Valor
        {
            get
            {
                if (ValorParcelaUD.Value != null)
                {
                    return ValorParcelaUD.Value.GetValueOrDefault();
                }
                else
                {
                    throw new Exception(Label);
                }
            }
            set
            {
                ValorParcelaUD.Value = value;
                NotifyPropertyChanged();
            }
        }

        public string Label
        {
            get
            {
                return LabelValor.Content.ToString();
            }
            set
            {
                LabelValor.Content = value;
            }
        }

        public ValorFieldUC()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }
    }
}
