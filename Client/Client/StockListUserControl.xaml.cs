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
    /// Interaction logic for StockListUserControl.xaml
    /// </summary>
    public partial class StockListUserControl : UserControl
    {
        public StockListUserControl()
        {
            InitializeComponent();
            StockList list = (new ServiceClient()).SelectAllStocks();
            foreach (Stock stock in list)
                main.Children.Add(new StockUserControl(stock));
        }
    }
}
