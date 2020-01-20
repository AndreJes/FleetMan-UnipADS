using System.Linq;
using System.Windows;

namespace AppDesk.Tools
{
    public static class MainWindowUpdater
    {
        private static MainWindow Window = Application.Current.Windows.OfType<MainWindow>().First();

        public static void UpdateDataGrids()
        {
            Window.PopulateDataGrid();
        }
    }
}
