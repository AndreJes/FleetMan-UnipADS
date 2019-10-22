using Modelo.Classes.Auxiliares;
using Modelo.Enums;
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
    /// Interação lógica para EnderecoUserControl.xam
    /// </summary>
    public partial class EnderecoUserControl : UserControl
    {
        public EnderecoUserControl()
        {
            InitializeComponent();
            UfComboBox.ItemsSource = Enum.GetNames(typeof(UnidadesFederativas));
        }
    }
}
