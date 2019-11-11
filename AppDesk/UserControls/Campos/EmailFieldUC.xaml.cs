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

namespace AppDesk.UserControls.Campos
{
    /// <summary>
    /// Interação lógica para EmailFieldUC.xam
    /// </summary>
    public partial class EmailFieldUC : UserControl
    {
        private string _text;

        public string Text
        {
            get
            {
                if (EmailTextBox.Text == "Admin")
                {
                    return EmailTextBox.Text;
                }
                if (validado)
                {
                    return _text;
                }
                else
                {
                    throw new FieldException("Email");
                }
            }
        }

        public bool validado = false;

        public EmailFieldUC()
        {
            InitializeComponent();
        }

        async void Validar()
        {
            validado = await ValidadorDeEmail.ValidarEmail(EmailTextBox.Text);
            if (validado)
            {
                _text = EmailTextBox.Text;
                validado = true;
                EmailTextBox.BorderBrush = HexaColorPicker.HexaColorSBrush("#00ff13");
            }
            else
            {
                EmailTextBox.BorderBrush = HexaColorPicker.HexaColorSBrush("#ff0000");
            }
        }

        private void EmailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(EmailTextBox.Text))
            {
                Validar();
            }
        }
    }
}
