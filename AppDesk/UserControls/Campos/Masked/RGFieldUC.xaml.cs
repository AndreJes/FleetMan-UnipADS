using AppDesk.Tools;
using System;
using System.Windows.Controls;
using Validacao;

namespace AppDesk.UserControls.Campos.Masked
{
    /// <summary>
    /// Interação lógica para RGFieldUC.xam
    /// </summary>
    public partial class RGFieldUC : UserControl
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
                    throw new FieldException("RG");
                }

            }
            set
            {
                RGTextBox.Text = value;
                validado = true;
            }
        }

        public RGFieldUC()
        {
            InitializeComponent();
        }

        async void Validar()
        {
            validado = await Validador.ValidarCPFCNPJAsync(RGTextBox.Text.Replace(".", "").Replace("-", ""));
            if (validado)
            {
                _text = RGTextBox.Text.Replace(".", "").Replace("-", "");
                RGTextBox.BorderBrush = HexaColorPicker.TextBoxValidoColor;
            }
            else
            {
                RGTextBox.BorderBrush = HexaColorPicker.TextBoxInvalidoColor;
            }
        }

        private void RGTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Validar();
        }
    }
}
