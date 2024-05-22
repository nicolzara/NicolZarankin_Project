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
    /// Interaction logic for ManagerUserMenuWindow.xaml
    /// </summary>
    public partial class ManagerUserMenuWindow : Window
    {
        private User user;
        public ManagerUserMenuWindow(User user)
        {
            this.user = user;
            InitializeComponent();
            grView.Children.Clear();
            grView.Children.Add(new UserUserControl(user));
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            grView.Children.Clear();
            grView.Children.Add(new UserUserControl(user));
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            grView.Children.Clear();
            grView.Children.Add(new UsersTableUserControl());
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

        private void AddForeignExchange_Click(object sender, RoutedEventArgs e)
        {
            grView.Children.Clear();
            grView.Children.Add(new AddForeignExchangeUserControl());
        }

        private void AddStock_Click(object sender, RoutedEventArgs e)
        {
            grView.Children.Clear();
            grView.Children.Add(new AddStockUserControl());
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

        private void AllForeignExchangeTransactions_Click(object sender, RoutedEventArgs e)
        {
            grView.Children.Clear();
            grView.Children.Add(new ForeignExchangeTransactionsUserControl(user, true));
        }

        private void AllStockTransactions_Click(object sender, RoutedEventArgs e)
        {
            grView.Children.Clear();
            grView.Children.Add(new StockTransactionsUserControl(user, true));
        }

        private void ForeignExchangeWallet_Click(object sender, RoutedEventArgs e)
        {
            grView.Children.Clear();
            grView.Children.Add(new ForeignExchangeWalletUserControl(user, false,this));
        }

        private void AllForeignExchangeWallet_Click(object sender, RoutedEventArgs e)
        {
            grView.Children.Clear();
            grView.Children.Add(new ForeignExchangeWalletUserControl(user, true, this));
        }

        private void StockWallet_Click(object sender, RoutedEventArgs e)
        {
            grView.Children.Clear();
            grView.Children.Add(new StockWalletUserControl(user, false, this));
        }

        private void AllStockWallet_Click(object sender, RoutedEventArgs e)
        {
            grView.Children.Clear();
            grView.Children.Add(new StockWalletUserControl(user, true, this));
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
