using System.Windows.Controls;

namespace AppDesk.UserControls.Campos
{
    /// <summary>
    /// Interação lógica para PasswordFieldUC.xam
    /// </summary>
    public partial class PasswordFieldUC : UserControl
    {
        public string Password
        {
            get
            {
                return PassWordTextBox.Password;
            }
            set
            {
                PassWordTextBox.Password = value;
            }
        }

        public PasswordFieldUC()
        {
            InitializeComponent();
        }
    }
}
