using AppDesk.Tools;
using System;
using System.Windows.Controls;
using Validacao;

namespace AppDesk.UserControls.Campos
{
    /// <summary>
    /// Interação lógica para ModeloFieldUC.xam
    /// </summary>
    public partial class ModeloFieldUC : UserControl
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
                ModeloTextbox.Text = value;
                validado = true;
            }
        }

        public ModeloFieldUC()
        {
            InitializeComponent();
        }

        async void Validar()
        {
            validado = await Validador.ValidarTextoAsync(ModeloTextbox.Text);
            if (validado)
            {
                _text = ModeloTextbox.Text;
                ModeloTextbox.BorderBrush = HexaColorPicker.TextBoxValidoColor;
            }
            else
            {
                ModeloTextbox.BorderBrush = HexaColorPicker.TextBoxInvalidoColor;
            }
        }

        private void ModeloTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Validar();
        }
    }
}
