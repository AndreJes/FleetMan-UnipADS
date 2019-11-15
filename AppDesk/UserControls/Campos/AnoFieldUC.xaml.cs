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

namespace AppDesk.UserControls.Campos
{
    /// <summary>
    /// Interação lógica para AnoFieldUC.xam
    /// </summary>
    public partial class AnoFieldUC : UserControl
    {
        private bool validado = false;
        private int _value;

        public int Value
        {
            get
            {
                if (validado)
                {
                    return _value;
                }
                else
                {
                    throw new FieldException("Ano");
                }

            }
            set
            {
                AnoNumberUD.Value = value;
                validado = true;
            }
        }
        public AnoFieldUC()
        {
            InitializeComponent();
        }

        private void AnoNumberUD_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Validar();
        }

        async void Validar()
        {
            int? valor = AnoNumberUD.Value;
            validado = await Task.Run(() =>
            {
                if(valor != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            });

            if(validado)
            {
                _value = (int)AnoNumberUD.Value;
                AnoNumberUD.BorderBrush = HexaColorPicker.TextBoxValidoColor;
            }
            else
            {
                AnoNumberUD.BorderBrush = HexaColorPicker.TextBoxInvalidoColor;
            }
        }
    }
}
