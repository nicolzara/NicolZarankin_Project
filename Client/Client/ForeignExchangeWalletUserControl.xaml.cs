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
    /// Interaction logic for ForeignExchangeWalletUserControl.xaml
    /// </summary>
    public partial class ForeignExchangeWalletUserControl : UserControl
    {
        private User user;
        private ManagerUserMenuWindow parent;

        public ForeignExchangeWalletUserControl(User user, bool all, ManagerUserMenuWindow managerUserMenuWindow)
        {
            this.user = user;
            this.parent = managerUserMenuWindow;
            InitializeComponent();
            if (all)
            {
                GetAllWallets();
            }
            else
            {
                GetWallets();
            }
            
        }

        private void GetWallets()
        {
            ForeignExchangeWalletList list = new ServiceClient().SelectForeignExchangeWalletsByUser(user);
            CurrencyWalletListView.ItemsSource = list;
        }

        private void GetAllWallets()
        {
            ForeignExchangeWalletList list = new ServiceClient().SelectAllForeignExchangeWallets();
            CurrencyWalletListView.ItemsSource = list;
        }

        private void PopupBox_Opened(object sender, RoutedEventArgs e)
        {

        }

        private void PopupBox_Closed(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            parent.OpenTransferForeignExchange();
        }
    }
}
