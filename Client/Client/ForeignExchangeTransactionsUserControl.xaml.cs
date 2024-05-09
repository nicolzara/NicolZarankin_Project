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
    /// Interaction logic for ForeignExchangeTransactionsUserControl.xaml
    /// </summary>
    public partial class ForeignExchangeTransactionsUserControl : UserControl
    {
        private ServiceClient service = new ServiceClient();
        public ForeignExchangeTransactionsUserControl()
        {
            InitializeComponent();
            GetTransactions();
        }

        private void GetTransactions()
        {
            ForeignExchangeTransactionList list = new ServiceClient().SelectAllForeignExchangeTransactions();
            CurrencyTransactionsListView.ItemsSource = list;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hello");
        }
    }

    [ValueConversion(typeof(bool), typeof(string))]
    public class BooleanToBuyOrSellConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch (value.ToString())
            {
                case "true":
                case "True":
                    return "Buy";
                case "false":
                case "False":
                    return "Sell";
            }
            return "Unknown";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return "null";
        }
    }

}
