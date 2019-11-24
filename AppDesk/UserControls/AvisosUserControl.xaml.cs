using AppDesk.Tools;
using AppDesk.Windows.Avisos;
using Modelo.Classes.Desk;
using Modelo.Enums;
using Servicos.Desk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AppDesk.UserControls
{
    /// <summary>
    /// Interação lógica para AlertasUserControl.xam
    /// </summary>
    public partial class AvisosUserControl : UserControl, INotifyPropertyChanged
    {
        AvisoService AvisoService = new AvisoService();

        private int _qntAvisos;

        public int QntAvisos
        {
            get
            {
                return _qntAvisos;
            }
            set
            {
                _qntAvisos = value;
                NotifyPropertyChanged();
            }
        }

        private List<Aviso> _avisos;

        public AvisosUserControl()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMinutes(3);
            timer.IsEnabled = true;
            timer.Tick += Timer_Event;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }

        private void Timer_Event(object sender, EventArgs e)
        {
            try
            {
                Dispatcher.Invoke(new Action(() =>
                {
                    _avisos = AvisoService.ObterTodosOsAvisos();
                    QntAvisosLabel.Content = _avisos.Count;
                }),
                    DispatcherPriority.Normal);
            }
            catch(Exception ex)
            {
                StandardMessageBoxes.MensagemDeErro(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FormAvisosList formAvisos = new FormAvisosList(_avisos);
            formAvisos.ShowDialog();
        }
    }
}
