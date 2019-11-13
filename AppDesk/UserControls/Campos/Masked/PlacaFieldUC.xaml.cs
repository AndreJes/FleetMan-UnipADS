using AppDesk.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
