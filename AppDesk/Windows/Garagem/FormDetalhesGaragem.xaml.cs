using Modelo.Enums;
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
using System.Windows.Shapes;

namespace AppDesk.Windows.Garagem
{
    /// <summary>
    /// Lógica interna para FormDetalhesGaragem.xaml
    /// </summary>
    public partial class FormDetalhesGaragem : Window
    {
        private Modelo.Classes.Desk.Garagem _garagem = null;

        private FormDetalhesGaragem()
        {
            InitializeComponent();
        }

        public FormDetalhesGaragem(Modelo.Classes.Desk.Garagem garagem) : this()
        {
            _garagem = garagem;
        }


    }
}
