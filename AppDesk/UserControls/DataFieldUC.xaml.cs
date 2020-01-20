using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace AppDesk.UserControls
{
    /// <summary>
    /// Interação lógica para DataFieldUC.xam
    /// </summary>
    public partial class DataFieldUC : UserControl, INotifyPropertyChanged
    {
        private bool _required = true;

        public bool Required
        {
            get
            {
                return _required;
            }
            set
            {
                _required = value;
                NotifyPropertyChanged();
            }
        }


        public DateTime? Date
        {
            get
            {
                if (DatePickerField.SelectedDate != null)
                {
                    return DatePickerField.SelectedDate.GetValueOrDefault();
                }
                else if (Required)
                {
                    throw new FieldException(Label);
                }
                else
                {
                    return null;
                }
            }
            set
            {
                DatePickerField.SelectedDate = value;
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


        public DataFieldUC()
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
