using AppDesk.Tools;
using System;
using System.Windows.Controls;
using Validacao;

namespace AppDesk.UserControls.Campos
{
    /// <summary>
    /// Interação lógica para CorFieldUC.xam
    /// </summary>
    public partial class CorFieldUC : UserControl
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
                    throw new FieldException("Marca");
                }

            }
            set
            {
                CorTextBox.Text = value;
                validado = true;
            }
        }

        public CorFieldUC()
        {
            InitializeComponent();
        }



        async void Validar()
        {
            validado = await Validador.ValidarTextoAsync(CorTextBox.Text);
            if (validado)
            {
                _text = CorTextBox.Text;
                CorTextBox.BorderBrush = HexaColorPicker.TextBoxValidoColor;
            }
            else
            {
                CorTextBox.BorderBrush = HexaColorPicker.TextBoxInvalidoColor;
            }
        }

        private void CorTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Validar();
        }
    }
}
