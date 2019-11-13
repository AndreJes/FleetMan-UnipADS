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
    /// Interação lógica para CidadeFieldUC.xam
    /// </summary>
    public partial class CidadeFieldUC : UserControl
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
                    throw new FieldException("Cidade");
                }
            }
            set
            {
                CidadeTextBox.Text = value;
                validado = true;
            }
        }

        public CidadeFieldUC()
        {
            InitializeComponent();
        }

        async void Validar()
        {
            validado = await Validador.ValidarTextoAsync(CidadeTextBox.Text);
            if(validado)
            {
                _text = CidadeTextBox.Text;
                CidadeTextBox.BorderBrush = HexaColorPicker.TextBoxValidoColor;
            }
            else
            {
                CidadeTextBox.BorderBrush = HexaColorPicker.TextBoxInvalidoColor;
            }
        }

        private void CidadeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(CidadeTextBox.Text))
            {
                Validar();
            }
        }
    }
}
