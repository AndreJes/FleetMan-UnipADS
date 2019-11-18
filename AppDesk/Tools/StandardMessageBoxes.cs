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
        public static MessageBoxResult ConfirmarRegistroMessageBox(string nomeItem)
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

        public static MessageBoxResult ConfirmarRemocaoMessageBox(string nomeItem)
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

        public static MessageBoxResult ConfirmarAlteracaoMessageBox(string nomeItem)
        {
            if (MessageBox.Show("Confirmar alteração de: " + nomeItem + "?", "Confirmar Alteração", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                return MessageBoxResult.Yes;
            }
            else
            {
                return MessageBoxResult.No;
            }
        }

        public static MessageBoxResult MensagemSucesso(string mensagem, string acao)
        {
            return MessageBox.Show(mensagem, acao, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static MessageBoxResult MensagemDeErroCampoFormulario(string campo)
        {
            return MessageBox.Show("Verifique os seguintes campos: " + Environment.NewLine + campo, "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public static MessageBoxResult MensagemDeErro(string mensagem)
        {
            return MessageBox.Show(mensagem, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static MessageBoxResult MensagemSelecao(string item)
        {
            return MessageBox.Show("Deseja selecionar " + item + " agora?", "Confirmar Seleção", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }

        public static MessageBoxResult MensagemCancelamento(string item)
        {
            return MessageBox.Show("Deseja cancelar: " + item + "?", "Cancelar " + item, MessageBoxButton.YesNo, MessageBoxImage.Question);
        }
    }
}
