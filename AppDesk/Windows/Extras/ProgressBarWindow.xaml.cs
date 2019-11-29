using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppDesk.Windows.Extras
{
    /// <summary>
    /// Lógica interna para ProgressBarWindow.xaml
    /// </summary>
    public partial class ProgressBarWindow : Window
    {
        public ProgressBarWindow()
        {
            InitializeComponent();
        }

        public ProgressBarWindow(string initialText) : this()
        {
            ProgressTextBlock.Text = initialText;
        }

        public void SetProgress(int value, string text = "")
        {
            MainProgressBar.Value = value;
            ProgressTextBlock.Text = text;
            if (value >= 100)
            {
                this.Close();
            }
        }
    }
}
