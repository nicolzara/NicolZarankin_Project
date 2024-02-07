using Client.ServiceReferenceVirWallet;
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

namespace Client
{
    /// <summary>
    /// Interaction logic for AddStockUserControl.xaml
    /// </summary>
    public partial class AddStockUserControl : UserControl
    {
        public AddStockUserControl()
        {
            InitializeComponent();
        }

        private void ClearClick(object sender, RoutedEventArgs e)
        {
            StockNameTextBox.Clear();
            StockSymbolTextBox.Clear();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            Stock stock = new Stock();
            stock.StockName = StockNameTextBox.Text;
            stock.StockSymbol = StockSymbolTextBox.Text;
            (new ServiceClient()).InsertStock(stock);
            MessageBox.Show("Successfuly added");
            ClearClick(sender, e);
        }
    }
}
