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
    }
}
