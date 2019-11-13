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
    /// Interação lógica para CPFFieldUC.xam
    /// </summary>
    public partial class CPFFieldUC : UserControl
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
                    throw new FieldException("CPF");
                }
            }
            set
            {
                CPFTextBox.Text = value;
                validado = true;
            }
        }

        public CPFFieldUC()
        {
            InitializeComponent();
        }

        async void Validar()
        {
            validado = await Validador.ValidarCPFCNPJAsync(CPFTextBox.Text.Replace(".", "").Replace("-", ""));
            if (validado)
            {
                _text = CPFTextBox.Text.Replace(".", "").Replace("-", "");
                CPFTextBox.BorderBrush = HexaColorPicker.TextBoxValidoColor;
            }
            else
            {
                CPFTextBox.BorderBrush = HexaColorPicker.TextBoxInvalidoColor;
            }
        }

        private void CPFTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Validar();
        }
    }
}
