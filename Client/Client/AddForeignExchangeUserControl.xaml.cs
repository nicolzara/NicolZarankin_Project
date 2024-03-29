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
    /// Interaction logic for AddForeignExchangeUserControl.xaml
    /// </summary>
    public partial class AddForeignExchangeUserControl : UserControl
    {
        public AddForeignExchangeUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clears the data of all the text boxes
        /// </summary>
        private void ClearClick(object sender, RoutedEventArgs e)
        {
            CurrencySymbolTextBox.Clear();
            CurrencyNameTextBox.Clear();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            ForeignExchange foreignExchange = new ForeignExchange();
            foreignExchange.CurrencyName = CurrencyNameTextBox.Text;
            foreignExchange.CurrencyCode = CurrencySymbolTextBox.Text;
            (new ServiceClient()).InsertForeignExchange(foreignExchange);
            MessageBox.Show("Successfuly added");
            ClearClick(sender, e);
        }
    }
}
