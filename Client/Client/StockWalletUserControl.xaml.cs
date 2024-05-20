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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Client
{
    /// <summary>
    /// Interaction logic for StockWalletUserControl.xaml
    /// </summary>
    public partial class StockWalletUserControl : UserControl
    {
        private User user;
        private Window parent;
        public StockWalletUserControl(User user, bool all, ManagerUserMenuWindow managerUserMenuWindow)
        {
            this.parent = managerUserMenuWindow;
            this.user = user;
            InitializeComponent();
            if(all)
            {
                GetAllWallets();
            }
            else
            {
                GetWallets();
            }
        }

        public StockWalletUserControl(User user, bool all, NormalUserMenuWindow normalUserMenuWindow)
        {
            this.parent = normalUserMenuWindow;
            this.user = user;
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
            StockWalletList list = new ServiceClient().SelectStockWalletsByUser(user);
            StockWalletListView.ItemsSource = list;
        }

        private void GetAllWallets()
        {
            StockWalletList list = new ServiceClient().SelectAllStockWallets();
            StockWalletListView.ItemsSource = list;
        }

        private void PopupBox_Opened(object sender, RoutedEventArgs e)
        {

        }

        private void PopupBox_Closed(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (parent is ManagerUserMenuWindow)
            {
                ManagerUserMenuWindow managerUserMenuWindow = (ManagerUserMenuWindow)parent;
                managerUserMenuWindow.OpenTransferStock();
            }
            else if (parent is NormalUserMenuWindow)
            {
                NormalUserMenuWindow normalUserMenuWindow = (NormalUserMenuWindow)parent;
                normalUserMenuWindow.OpenTransferStock();
            }
        }
    }
}
