using AppDesk.Tools;
using System;
using System.Windows.Controls;
using Validacao;

namespace AppDesk.UserControls.Campos
{
    /// <summary>
    /// Interação lógica para NomeFieldUC.xam
    /// </summary>
    public partial class NomeFieldUC : UserControl
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
                    throw new FieldException("Nome");
                }
            }
            set
            {
                NomeTextBox.Text = value;
                validado = true;
            }
        }

        public NomeFieldUC()
        {
            InitializeComponent();
        }

        async void Validar()
        {
            validado = await Validador.ValidarTextoAsync(NomeTextBox.Text);
            if (validado)
            {
                _text = NomeTextBox.Text;
                NomeTextBox.BorderBrush = HexaColorPicker.TextBoxValidoColor;
            }
            else
            {
                NomeTextBox.BorderBrush = HexaColorPicker.TextBoxInvalidoColor;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Validar();
        }
    }
}
