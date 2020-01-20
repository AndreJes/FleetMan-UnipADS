using AppDesk.Tools;
using System;
using System.Windows.Controls;
using Validacao;

namespace AppDesk.UserControls.Campos.Masked
{
    /// <summary>
    /// Interação lógica para PlacaFieldUC.xam
    /// </summary>
    public partial class PlacaFieldUC : UserControl
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
                    throw new FieldException("Placa");
                }
            }
            set
            {
                PlacaTextBox.Text = value;
                validado = true;
            }
        }
        public PlacaFieldUC()
        {
            InitializeComponent();
        }

        async void Validar()
        {
            validado = await Validador.ValidarPlacaVeiculoAsync(PlacaTextBox.Text.Replace("-", ""));
            if (validado)
            {
                _text = PlacaTextBox.Text;
                PlacaTextBox.BorderBrush = HexaColorPicker.TextBoxValidoColor;
            }
            else
            {
                PlacaTextBox.BorderBrush = HexaColorPicker.TextBoxInvalidoColor;
            }
        }

        private void PlacaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Validar();
        }
    }
}
