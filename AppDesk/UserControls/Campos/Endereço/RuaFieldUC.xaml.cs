using AppDesk.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
            if(!string.IsNullOrWhiteSpace(RuaTextBox.Text))
            {
                Validar();
            }
        }

        async void Validar()
        {
            validado = await ValidadorEndereco.ValidarTexto(RuaTextBox.Text);
            if(validado)
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
