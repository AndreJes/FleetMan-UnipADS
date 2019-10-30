using Modelo.Classes.Web;
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
    /// Interação lógica para VeiculoShowDataUserControl.xam
    /// </summary>
    public partial class VeiculoShowDataUserControl : UserControl
    {
        public Veiculo Veiculo 
        {
            set
            {
                DefinirVeiculo(value);
            } 
        }

        public VeiculoShowDataUserControl()
        {
            InitializeComponent();
        }

        private void DefinirVeiculo(Veiculo veiculo)
        {
            this.DataContext = veiculo;
        }
    }
}
