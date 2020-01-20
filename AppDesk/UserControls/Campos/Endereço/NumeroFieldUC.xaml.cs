using AppDesk.Tools;
using System;
using System.Windows.Controls;
using Validacao;

namespace AppDesk.UserControls.Campos.Endereço
{
    /// <summary>
    /// Interação lógica para NumeroFieldUC.xam
    /// </summary>
    public partial class NumeroFieldUC : UserControl
    {
        private bool validado = false;

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
                    throw new FieldException("Nº");
                }
            }
            set
            {
                NumeroTextBox.Text = value;
                validado = true;
            }
        }

        public NumeroFieldUC()
        {
            InitializeComponent();
        }

        async void Validar()
        {
            validado = await Validador.ValidarNumeroAsync(NumeroTextBox.Text);
            if (validado)
            {
                _text = NumeroTextBox.Text;
                NumeroTextBox.BorderBrush = HexaColorPicker.TextBoxValidoColor;
            }
            else
            {
                NumeroTextBox.BorderBrush = HexaColorPicker.TextBoxInvalidoColor;
            }
        }

        private void NumeroTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(NumeroTextBox.Text) || !string.IsNullOrWhiteSpace(NumeroTextBox.Text))
            {
                Validar();
            }
        }
    }
}
