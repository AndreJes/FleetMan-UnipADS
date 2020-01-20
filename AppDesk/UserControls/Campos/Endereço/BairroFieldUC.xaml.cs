using AppDesk.Tools;
using System;
using System.Windows.Controls;
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
            validado = await Validador.ValidarTextoAsync(BairroTextBox.Text);
            if (validado)
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
            if (!string.IsNullOrEmpty(BairroTextBox.Text))
            {
                Validar();
            }
        }
    }
}
