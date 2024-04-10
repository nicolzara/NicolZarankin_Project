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

        }

        private void LoadCurrencies()
        {
            ForeignExchangeList list = new ServiceClient().SelectAllForeignExchanges();
            CurrencyComboBox.ItemsSource = list;
        }

        private void TranferClick(object sender, RoutedEventArgs e)
        {

        }

        private void ClearClick(object sender, RoutedEventArgs e)
        {
            CurrencyComboBox.SelectedIndex = -1;
        }
    }
}
