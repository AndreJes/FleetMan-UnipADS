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

namespace AppDesk.UserControls.Campos
{
    /// <summary>
    /// Interação lógica para MarcaFieldUC.xam
    /// </summary>
    public partial class MarcaFieldUC : UserControl
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
                MarcaTextBox.Text = value;
                validado = true;
            }
        }

        public MarcaFieldUC()
        {
            InitializeComponent();
        }

        private void MarcaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Validar();
        }

        async void Validar()
        {
            validado = await Validador.ValidarTextoAsync(MarcaTextBox.Text);
            if(validado)
            {
                _text = MarcaTextBox.Text;
                MarcaTextBox.BorderBrush = HexaColorPicker.TextBoxValidoColor;
            }
            else
            {
                MarcaTextBox.BorderBrush = HexaColorPicker.TextBoxInvalidoColor;
            }
        }
    }
}
