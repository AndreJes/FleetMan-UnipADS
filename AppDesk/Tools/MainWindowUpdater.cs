using Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
