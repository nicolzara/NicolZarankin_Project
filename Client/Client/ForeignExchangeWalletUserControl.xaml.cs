﻿using Client.ServiceReferenceVirWallet;
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
        public ForeignExchangeWalletUserControl(User user, bool all)
        {
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
            ForeignExchangeWalletList list = new ServiceClient().SelectForeignExchangeWalletsByUser(user);
            CurrencyWalletListView.ItemsSource = list;
        }

        private void GetAllWallets()
        {
            ForeignExchangeWalletList list = new ServiceClient().SelectAllForeignExchangeWallets();
            CurrencyWalletListView.ItemsSource = list;
        }
    }
}
