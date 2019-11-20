using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
    /// Interação lógica para DateHourFieldUC.xam
    /// </summary>
    public partial class DateHourFieldUC : UserControl, INotifyPropertyChanged
    {
        public DateTime Date
        {
            get
            {
                if (DatePickerField.Text != null)
                {
                    return DateTime.ParseExact(DatePickerField.Text, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                }
                else
                {
                    throw new FieldException(Label);
                }
            }
            set
            {
                DatePickerField.Text = value.ToString("dd/MM/yyyy HH:mm");
                NotifyPropertyChanged();
            }
        }

        public string Label
        {
            get
            {
                return DataLabel.Content.ToString();
            }
            set
            {
                DataLabel.Content = value;
                NotifyPropertyChanged();
            }
        }

        public DateTime DataMinima
        {
            set
            {
                DatePickerField.Minimum = value;
                NotifyPropertyChanged();
            }
        }

        public DateTime DataMaxima
        {
            set
            {
                {
                    DatePickerField.Maximum = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public DateHourFieldUC()
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
