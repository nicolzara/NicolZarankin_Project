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
    /// Interaction logic for StockTransactionsUserControl.xaml
    /// </summary>
    public partial class StockTransactionsUserControl : UserControl
    {
        private ServiceClient service = new ServiceClient();
        public StockTransactionsUserControl()
        {
            InitializeComponent();
            GetTransactions();
        }
        private void GetTransactions()
        {
            StockTransactionList list = new ServiceClient().SelectAllStockTransactions();
            CurrencyTransactionsListView.ItemsSource = list;
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hello");
        }
    }
}
