using Client.ServiceReferenceVirWallet;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for UsersTableWindow.xaml
    /// </summary>
    public partial class UsersTableWindow : Window
    {
        public UsersTableWindow()
        {
            InitializeComponent();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hello");
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            UsersTableWindow usersTableWindow = new UsersTableWindow();
            usersTableWindow.WindowStartupLocation = WindowStartupLocation.Manual;
            usersTableWindow.Left = this.Left;
            usersTableWindow.Top = this.Top;
            Close();
            usersTableWindow.ShowDialog();
        }

        private DataTable GetUsers()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("UserName", typeof(string));
            dataTable.Columns.Add("Email", typeof(string));
            dataTable.Columns.Add("Birthdate", typeof(DateTime));
            dataTable.Columns.Add("Phone Number", typeof(string));
            dataTable.Columns.Add("Permission", typeof(int));
            dataTable.Columns.Add("Password", typeof(string));
            dataTable.Columns.Add("Free Balance", typeof(double));

            UserList users = new ServiceClient().SelectAllUsers();

            // add rows https://support.syncfusion.com/kb/article/9500/how-to-bind-data-table-to-wpf-datagrid-sfdatagrid

            return dataTable;
        }
    }
}
