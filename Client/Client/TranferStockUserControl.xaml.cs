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
    /// Interaction logic for TranferStockUserControl.xaml
    /// </summary>
    public partial class TranferStockUserControl : UserControl
    {
        private User user;
        public TranferStockUserControl(User user)
        {
            this.user = user;
            InitializeComponent();
            LoadStocks();
        }

        private void LoadStocks()
        {
            StockList list = new ServiceClient().SelectAllStocks();
            StockComboBox.ItemsSource = list;
        }

        private void TransferClick(object sender, RoutedEventArgs e)
        {
            StockTransaction StockTransaction = new StockTransaction();
            if (!CheckData())
                return;
            Stock Stock = StockComboBox.SelectedItem as Stock;
            StockTransaction.User = user;
            StockTransaction.Stock = Stock;
            StockTransaction.StockValue = Stock.Value;
            StockTransaction.StockAmount = int.Parse(StockAmountTextBox.Text);
            StockTransaction.DateSignature = DateTime.Now;
            string buyOrSell = BuyOrSellComboBox.Text;
            StockTransaction.BuyOrSell = buyOrSell == "Buy" ? true : false;

            ServiceClient service = new ServiceClient();
            StockWalletList StockWalletList = service.SelectStockWalletsByUser(user);
            StockWallet StockWallet = null;
            foreach (StockWallet wallet in StockWalletList)
            {
                if (wallet.Stock.Id == Stock.Id)
                    StockWallet = wallet;
            }

            if (StockWallet == null)
            {
                if (StockTransaction.BuyOrSell)
                {
                    if (user.FreeBalance - (double.Parse(TotalTextBox.Text)) > 0)
                    {
                        StockWallet = new StockWallet();
                        StockWallet.Stock = Stock;
                        StockWallet.User = user;
                        StockWallet.StockAmount = int.Parse(StockAmountTextBox.Text);
                        service.InsertStockWallet(StockWallet);
                        user.FreeBalance -= (double.Parse(TotalTextBox.Text));
                        service.UpdateUser(user);
                        service.InsertStockTransaction(StockTransaction);
                    }
                    else
                    {
                        MessageBox.Show("Sorry, you don't have enough money");
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("You can't sell if you don't have currency");
                    return;
                }
            }
            else
            {
                if (StockTransaction.BuyOrSell)
                {
                    if (user.FreeBalance - (double.Parse(TotalTextBox.Text)) > 0)
                    {
                        StockWallet.StockAmount += StockTransaction.StockAmount;
                        user.FreeBalance -= (double.Parse(TotalTextBox.Text));
                        service.UpdateUser(user);
                        service.UpdateStockWallet(StockWallet);
                        service.InsertStockTransaction(StockTransaction);
                    }
                    else
                    {
                        MessageBox.Show("Sorry, you don't have enough money");
                        return;
                    }

                }
                else
                {
                    if (StockWallet.StockAmount > StockTransaction.StockAmount)
                    {
                        StockWallet.StockAmount -= StockTransaction.StockAmount;
                        user.FreeBalance += (double.Parse(TotalTextBox.Text));
                        service.UpdateUser(user);
                        service.UpdateStockWallet(StockWallet);
                        service.InsertStockTransaction(StockTransaction);
                    }
                    else
                    {
                        MessageBox.Show("Sorry, you don't have enough currency to sell");
                        return;
                    }
                }
            }

            StockComboBox.SelectedIndex = -1;
            BuyOrSellComboBox.SelectedIndex = -1;
            StockAmountTextBox.Clear();
            TotalTextBox.Clear();
        }

        private void ClearClick(object sender, RoutedEventArgs e)
        {
            StockComboBox.SelectedIndex = -1;
            BuyOrSellComboBox.SelectedIndex = -1;
            StockAmountTextBox.Clear();
            TotalTextBox.Clear();
        }

        private void StockAmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Stock Stock = StockComboBox.SelectedItem as Stock;
            if (Stock == null) return;
            if (StockAmountTextBox.Text.Length == 0)
            {
                TotalTextBox.Text = string.Empty;
                return;
            }

            try
            {
                if (!TotalTextBox.IsFocused)
                    TotalTextBox.Text = (int.Parse(StockAmountTextBox.Text) * Stock.Value).ToString();
            }
            catch
            {
                MessageBox.Show("Bad Input");
            }
        }

        private bool CheckData()
        {
            if (!(StockComboBox.SelectedIndex == -1 || BuyOrSellComboBox.SelectedIndex == -1))
            {
                if (StockAmountTextBox.Text != string.Empty && TotalTextBox.Text != string.Empty)
                {
                    try
                    {
                        if (double.Parse(TotalTextBox.Text) > 0 && double.Parse(StockAmountTextBox.Text) > 0)
                        {
                            return true;
                        }
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            MessageBox.Show("Bad Input");
            return false;
        }
    }
}
