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
    /// Interaction logic for TransferForeignExchangeUserControl.xaml
    /// </summary>
    public partial class TransferForeignExchangeUserControl : UserControl
    {
        private User user;
        public TransferForeignExchangeUserControl(User user)
        {
            this.user = user;
            InitializeComponent();
            LoadCurrencies();
        }

        private void LoadCurrencies()
        {
            ForeignExchangeList list = new ServiceClient().SelectAllForeignExchanges();
            CurrencyComboBox.ItemsSource = list;
        }

        private void TransferClick(object sender, RoutedEventArgs e)
        {
            ForeignExchangeTransaction foreignExchangeTransaction = new ForeignExchangeTransaction();
            if (!CheckData())
                return;
            ForeignExchange foreignExchange = CurrencyComboBox.SelectedItem as ForeignExchange;
            foreignExchangeTransaction.ForeignExchange = foreignExchange;
            foreignExchangeTransaction.CurrencyValue = foreignExchange.Value;
            foreignExchangeTransaction.CurrencyAmount = double.Parse(CurrencyAmountTextBox.Text);
            foreignExchangeTransaction.DateSignature = DateTime.Now;
            //string buyOrSell = BuyOrSellComboBox.SelectedItem as string;
            //MessageBox.Show(buyOrSell);
            //foreignExchangeTransaction.BuyOrSell = buyOrSell == "Buy" ? true : false;
            
        }

        private void ClearClick(object sender, RoutedEventArgs e)
        {
            CurrencyComboBox.SelectedIndex = -1;
            BuyOrSellComboBox.SelectedIndex = -1;
            CurrencyAmountTextBox.Clear();
            TotalTextBox.Clear();
        }

        private void CurrencyAmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           ForeignExchange foreignExchange = CurrencyComboBox.SelectedItem as ForeignExchange;
            if (foreignExchange == null) return;
            if(CurrencyAmountTextBox.Text.Length == 0)
            {
                TotalTextBox.Text = string.Empty;
                return;
            }

            try
            {
                if (!TotalTextBox.IsFocused)
                    TotalTextBox.Text = (double.Parse(CurrencyAmountTextBox.Text) / foreignExchange.Value).ToString();
            }
            catch
            {
                MessageBox.Show("Bad Input");
            }
        }

        private void TotalTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ForeignExchange foreignExchange = CurrencyComboBox.SelectedItem as ForeignExchange;
            if (foreignExchange == null) return;
            if (TotalTextBox.Text.Length == 0)
            {
                CurrencyAmountTextBox.Text = string.Empty;
                return;
            }

            try
            {
                if (!CurrencyAmountTextBox.IsFocused)
                    CurrencyAmountTextBox.Text = (foreignExchange.Value * double.Parse(TotalTextBox.Text)).ToString();
            }
            catch
            {
                MessageBox.Show("Bad Input");
            }
        }

        private bool CheckData()
        {
            if(!(CurrencyComboBox.SelectedIndex == -1 || BuyOrSellComboBox.SelectedIndex == -1))
            {
                if (CurrencyAmountTextBox.Text != string.Empty && TotalTextBox.Text != string.Empty)
                {
                    try
                    {
                        if (double.Parse(TotalTextBox.Text) > 0 && double.Parse(CurrencyAmountTextBox.Text) > 0)
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
