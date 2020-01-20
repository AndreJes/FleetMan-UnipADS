using Modelo.Classes.Web;
using System.Windows.Controls;

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
            MarcaUC.Text = veiculo.Marca;
            PlacaUC.Text = veiculo.Placa;
            ModeloUC.Text = veiculo.Modelo;
            AnoUC.Value = veiculo.Ano;
        }
    }
}
