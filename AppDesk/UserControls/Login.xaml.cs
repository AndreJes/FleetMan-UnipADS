using AppDesk.Serviço;
using AppDesk.Tools;
using AppDesk.Windows.Extras;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace AppDesk.UserControls
{
    /// <summary>
    /// Interação lógica para Login.xam
    /// </summary>
    public partial class Login : UserControl
    {
        ProgressBarWindow progressBarWindow = null;

        public Login()
        {
            InitializeComponent();
        }

        private void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarWindow.SetProgress(e.ProgressPercentage, "Configurando area de trabalho");
        }

        private void Processar()
        {
            try
            {
                BackgroundWorker bw = new BackgroundWorker();
                bw.WorkerReportsProgress = true;
                bw.DoWork += Bw_DoWork;
                bw.ProgressChanged += Bw_ProgressChanged;
                bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                StandardMessageBoxes.MensagemDeErro(ex.Message);
            }
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string email = "";
                string senha = "";

                Dispatcher.Invoke(() =>
                {
                    LoginBtn.IsEnabled = false;

                    progressBarWindow = new ProgressBarWindow("Realizando Login");
                    progressBarWindow.Show();
                });

                Dispatcher.Invoke(() =>
                {
                    email = EmailUC.Text;
                    senha = PasswordUC.Password;
                });

                if (DesktopLoginControlService.Logar(email, senha))
                {
                    Dispatcher.Invoke(() => { PasswordUC.Password = string.Empty; });

                    foreach (int i in Dispatcher.Invoke(() => Application.Current.Windows.OfType<MainWindow>().First().StartSession()))
                    {
                        Thread.Sleep(50);
                        (sender as BackgroundWorker).ReportProgress(i);
                    }
                }

            }
            catch (FieldException ex)
            {
                StandardMessageBoxes.MensagemDeErroCampoFormulario(ex.Message);
            }
            catch (Exception ex)
            {
                StandardMessageBoxes.MensagemDeErro(ex.Message);
            }
            finally
            {
                Dispatcher.Invoke(() =>
                {
                    progressBarWindow.Close();
                    LoginBtn.IsEnabled = true;
                });
            }
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            Processar();
        }
    }
}