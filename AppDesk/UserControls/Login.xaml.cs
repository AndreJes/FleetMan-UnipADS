using AppDesk.Serviço;
using AppDesk.Tools;
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
                StandardMessageBoxes.MensagemSucesso("Login realizado com sucesso!", "Login");
                PasswordUC.Password = string.Empty;
                Application.Current.Windows.OfType<MainWindow>().First().StartSession();
            }
        }

        private bool Logar()
        {
            try
            {
                return DesktopLoginControlService.Logar(EmailUC.Text, PasswordUC.Password);
            }
            catch(FieldException fex)
            {
                StandardMessageBoxes.MensagemDeErroCampoFormulario(fex.Message);
                return false;
            }
            catch (Exception ex)
            {
                StandardMessageBoxes.MensagemDeErro(ex.Message);
                return false;
            }
        }
    }
}
