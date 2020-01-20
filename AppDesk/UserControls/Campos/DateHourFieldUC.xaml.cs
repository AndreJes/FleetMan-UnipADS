using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

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
