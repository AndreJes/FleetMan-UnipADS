using AppDesk.Tools;
using System;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AppDesk.UserControls.Campos.Masked
{
    /// <summary>
    /// Interação lógica para NumeroCNHFieldUC.xam
    /// </summary>
    public partial class NumeroCNHFieldUC : UserControl
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
                    throw new FieldException("Nº CNH");
                }

            }
            set
            {
                NumeroCNHTextBox.Text = value;
                validado = true;
            }
        }

        public NumeroCNHFieldUC()
        {
            InitializeComponent();
        }

        async void Validar()
        {
            string texto = NumeroCNHTextBox.Text.Replace("_", "");
            validado = await Task.Run(() =>
            {
                if (texto.Length < 11)
                {
                    return false;
                }
                return true;
            });

            if (validado)
            {
                _text = NumeroCNHTextBox.Text;
                NumeroCNHTextBox.BorderBrush = HexaColorPicker.TextBoxValidoColor;
            }
            else
            {
                NumeroCNHTextBox.BorderBrush = HexaColorPicker.TextBoxInvalidoColor;
            }
        }

        private void NumeroCNHTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Validar();
        }
    }
}
