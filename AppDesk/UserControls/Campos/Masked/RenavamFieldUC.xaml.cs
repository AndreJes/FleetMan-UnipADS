using AppDesk.Tools;
using System;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AppDesk.UserControls.Campos.Masked
{
    /// <summary>
    /// Interação lógica para RenavamFieldUC.xam
    /// </summary>
    public partial class RenavamFieldUC : UserControl
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
                    throw new FieldException("Renavam");
                }
            }
            set
            {
                RenavamTextBox.Text = value;
                validado = true;
            }
        }


        public RenavamFieldUC()
        {
            InitializeComponent();
        }

        async void Validar()
        {
            string texto = RenavamTextBox.Text.Replace("_", "");
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
                _text = RenavamTextBox.Text;
                RenavamTextBox.BorderBrush = HexaColorPicker.TextBoxValidoColor;
            }
            else
            {
                RenavamTextBox.BorderBrush = HexaColorPicker.TextBoxInvalidoColor;
            }
        }

        private void RenavamTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Validar();
        }
    }
}
