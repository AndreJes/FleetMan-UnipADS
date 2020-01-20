using AppDesk.Tools;
using System;
using System.Windows.Controls;
using Validacao;

namespace AppDesk.UserControls.Campos.Endereço
{
    /// <summary>
    /// Interação lógica para CidadeFieldUC.xam
    /// </summary>
    public partial class CidadeFieldUC : UserControl
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
                    throw new FieldException("Cidade");
                }
            }
            set
            {
                CidadeTextBox.Text = value;
                validado = true;
            }
        }

        public CidadeFieldUC()
        {
            InitializeComponent();
        }

        async void Validar()
        {
            validado = await Validador.ValidarTextoAsync(CidadeTextBox.Text);
            if (validado)
            {
                _text = CidadeTextBox.Text;
                CidadeTextBox.BorderBrush = HexaColorPicker.TextBoxValidoColor;
            }
            else
            {
                CidadeTextBox.BorderBrush = HexaColorPicker.TextBoxInvalidoColor;
            }
        }

        private void CidadeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CidadeTextBox.Text))
            {
                Validar();
            }
        }
    }
}
