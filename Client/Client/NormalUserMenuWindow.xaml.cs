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
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Interaction logic for NormalUserMenuWindow.xaml
    /// </summary>
    public partial class NormalUserMenuWindow : Window
    {
        private User user;
        public NormalUserMenuWindow(User user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hello");
        }

        private void StockInfo_Click(object sender, RoutedEventArgs e)
        {
            grView.Children.Clear();
            grView.Children.Add(new StockListUserControl());
        }

        private void ForeignExchangeInfo_Click(object sender, RoutedEventArgs e)
        {
            grView.Children.Clear();
            grView.Children.Add(new ForeignExchangeListUserControl());
        }

        private void AboutUs_Click(object sender, RoutedEventArgs e)
        {
            grView.Children.Clear();
            grView.Children.Add(new AboutUsUserControl());
        }

        private void ForeignExchangeTransactions_Click(object sender, RoutedEventArgs e)
        {
            grView.Children.Clear();
            grView.Children.Add(new ForeignExchangeTransactionsUserControl(user, false));
        }

        private void StockTransactions_Click(object sender, RoutedEventArgs e)
        {
            grView.Children.Clear();
            grView.Children.Add(new StockTransactionsUserControl(user, false));
        }

        private void ForeignExchangeWallet_Click(object sender, RoutedEventArgs e)
        {
            grView.Children.Clear();
            grView.Children.Add(new ForeignExchangeWalletUserControl(user, false, this));
        }

        private void StockWallet_Click(object sender, RoutedEventArgs e)
        {
            grView.Children.Clear();
            grView.Children.Add(new StockWalletUserControl(user, false, this));
        }

        public void OpenTransferForeignExchange()
        {
            grView.Children.Clear();
            grView.Children.Add(new TransferForeignExchangeUserControl(user));
        }

        public void OpenTransferStock()
        {
            grView.Children.Clear();
            grView.Children.Add(new TranferStockUserControl(user));
        }
    }
}
