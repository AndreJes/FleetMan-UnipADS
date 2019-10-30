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
        public bool Editavel { get; set; }

        public Endereco Endereco
        {
            get
            {
                Endereco endereco = new Endereco();
                endereco.Rua = RuaTextBox.Text;
                endereco.Numero = NumeroTextBox.Text;
                endereco.Bairro = BairroTextBox.Text;
                endereco.CEP = CEPTextBox.Text;
                endereco.Cidade = CidadeTextBox.Text;
                endereco.UF = (UnidadesFederativas)Enum.Parse(typeof(UnidadesFederativas), UfComboBox.SelectedItem.ToString());
                return endereco;
            }
            set
            {
                DefinirEndereco(value);
            }
        }

        public EnderecoUserControl()
        {
            InitializeComponent();
            UfComboBox.ItemsSource = Enum.GetNames(typeof(UnidadesFederativas));
        }

        private void DefinirEndereco(Endereco endereco)
        {
            this.DataContext = endereco;
            UfComboBox.SelectedItem = endereco.UF.ToString("G");
            if (Editavel == false)
            {
                BairroTextBox.IsEnabled = false;
                CEPTextBox.IsEnabled = false;
                CidadeTextBox.IsEnabled = false;
                NumeroTextBox.IsEnabled = false;
                RuaTextBox.IsEnabled = false;
                UfComboBox.IsEnabled = false;
            }
        }
    }
}
