using AppDesk.Tools;
using System;
using System.Windows.Controls;
using Validacao;

namespace AppDesk.UserControls.Campos.Endereço
{
    /// <summary>
    /// Interação lógica para CEPFieldUC.xam
    /// </summary>
    public partial class CEPFieldUC : UserControl
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
                    throw new FieldException("CEP");
                }
            }
            set
            {
                CEPTextBox.Text = value;
                validado = true;
            }
        }

        public CEPFieldUC()
        {
            InitializeComponent();
        }

        async void Validar()
        {
            validado = await Validador.ValidarCEP(CEPTextBox.Text.Replace("-", ""));
            if (validado)
            {
                _text = CEPTextBox.Text;
                CEPTextBox.BorderBrush = HexaColorPicker.TextBoxValidoColor;
            }
            else
            {
                CEPTextBox.BorderBrush = HexaColorPicker.TextBoxInvalidoColor;
            }
        }

        private void CEPTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(CEPTextBox.Text))
            {
                Validar();
            }
        }
    }
}
