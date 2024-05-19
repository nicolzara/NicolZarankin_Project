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
        public StockTransactionsUserControl(User user, bool all)
        {
            InitializeComponent();
            if(all)
            {
                GetAllTransactions();
            }
            else
            {
                GetTransactions(user);
            }
            
        }
        private void GetAllTransactions()
        {
            StockTransactionList list = new ServiceClient().SelectAllStockTransactions();
            StockTransactionsListView.ItemsSource = list;
        }

        private void GetTransactions(User user)
        {
            StockTransactionList list = new ServiceClient().SelectStockTransactionsByUser(user);
            StockTransactionsListView.ItemsSource = list;
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hello");
        }
    }
}
