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
            validado = await ValidadorEndereco.ValidarCEP(CEPTextBox.Text.Replace("-", ""));
            if(validado)
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
            if(!string.IsNullOrEmpty(CEPTextBox.Text))
            {
                Validar();
            }
        }
    }
}
