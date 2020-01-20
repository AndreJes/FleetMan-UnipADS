using AppDesk.Tools;
using System;
using System.Windows.Controls;
using Validacao;

namespace AppDesk.UserControls.Campos.Endereço
{
    /// <summary>
    /// Interação lógica para RuaFieldUC.xam
    /// </summary>
    public partial class RuaFieldUC : UserControl
    {
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
                    throw new FieldException("Endereço");
                }
            }
            set
            {
                RuaTextBox.Text = value;
            }
        }

        public bool validado = false;

        public RuaFieldUC()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void RuaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(RuaTextBox.Text))
            {
                Validar();
            }
        }

        async void Validar()
        {
            validado = await Validador.ValidarTextoAsync(RuaTextBox.Text);
            if (validado)
            {
                _text = RuaTextBox.Text;
                RuaTextBox.BorderBrush = HexaColorPicker.TextBoxValidoColor;
            }
            else
            {
                RuaTextBox.BorderBrush = HexaColorPicker.TextBoxInvalidoColor;
            }
        }
    }
}
