using AppDesk.Serviço;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppDesk.UserControls
{
    /// <summary>
    /// Interação lógica para Login.xam
    /// </summary>
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Logar())
            {
                MessageBox.Show("Login realizado com sucesso!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                Application.Current.Windows.OfType<MainWindow>().First().StartSession();
            }
        }

        private bool Logar()
        {
            try
            {
                return DesktopLoginControlService.Logar(EmailTextBox.Text, PassWordTextBox.Password);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Dados Inválidos", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
        }
    }
}
