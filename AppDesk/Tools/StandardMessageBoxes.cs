using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppDesk.Tools
{
    public static class StandardMessageBoxes
    {
        public static MessageBoxResult RegistrarMessageBox(string nomeItem)
        {
            if (MessageBox.Show("Confirmar registro de: " + nomeItem + "?", "Confirmar Registro", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                return MessageBoxResult.Yes;
            }
            else
            {
                return MessageBoxResult.No;
            }
        }

        public static MessageBoxResult RemoverMessageBox(string nomeItem)
        {
            if (MessageBox.Show("Confirmar remoção de: " + nomeItem + "?", "Confirmar Remoção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                return MessageBoxResult.Yes;
            }
            else
            {
                return MessageBoxResult.No;
            }
        }
    }
}
