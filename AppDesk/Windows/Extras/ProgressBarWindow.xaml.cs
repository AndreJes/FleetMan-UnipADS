using System.Windows;

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
