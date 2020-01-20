using AppDesk.Tools;
using System;
using System.Windows.Controls;
using Validacao;

namespace AppDesk.UserControls.Campos.Masked
{
    /// <summary>
    /// Interação lógica para TelefoneFieldUC.xam
    /// </summary>
    public partial class TelefoneFieldUC : UserControl
    {
        public bool validado = false;
        private string _text;

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
                    throw new FieldException("Telefone");
                }
            }
            set
            {
                TelefoneTextBox.Text = value;
                validado = true;
            }
        }

        public TelefoneFieldUC()
        {
            InitializeComponent();
        }

        async void Validar()
        {
            validado = await Validador.ValidarTelefoneAsync(TelefoneTextBox.Text.Replace("-", "").Replace("(", "").Replace(")", "").Replace("_", ""));
            if (validado)
            {
                _text = TelefoneTextBox.Text.Replace("-", "").Replace("(", "").Replace(")", "").Replace("_", "");
                TelefoneTextBox.BorderBrush = HexaColorPicker.TextBoxValidoColor;
            }
            else
            {
                TelefoneTextBox.BorderBrush = HexaColorPicker.TextBoxInvalidoColor;
            }

        }

        private void TelefoneTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Validar();
        }
    }
}
