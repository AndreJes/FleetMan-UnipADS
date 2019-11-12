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
using Validacao;

namespace AppDesk.UserControls.Campos.Endereço
{
    /// <summary>
    /// Interação lógica para BairroFieldUC.xam
    /// </summary>
    public partial class BairroFieldUC : UserControl
    {
        private string _text;
        private bool validado = false;

        public string Text
        {
            get
            {
                if (validado)
                {
                    return _text;
                }
                else
                {
                    throw new FieldException("Bairro");
                }
            }
            set
            {
                BairroTextBox.Text = value;
                validado = true;
            }
        }

        public BairroFieldUC()
        {
            InitializeComponent();
        }

        async void Validar()
        {
            validado = await ValidadorEndereco.ValidarTexto(BairroTextBox.Text);
            if(validado)
            {
                _text = BairroTextBox.Text;
                BairroTextBox.BorderBrush = HexaColorPicker.TextBoxValidoColor;
            }
            else
            {
                BairroTextBox.BorderBrush = HexaColorPicker.TextBoxInvalidoColor;
            }
        }

        private void BairroTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!string.IsNullOrEmpty(BairroTextBox.Text))
            {
                Validar();
            }
        }
    }
}
