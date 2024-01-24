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
    public partial class UsersTableUserControl : UserControl
    {
        public UsersTableUserControl()
        {
            InitializeComponent();
            GetUsers();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hello");
        }

        private void GetUsers()
        {
            UserList users = new ServiceClient().SelectAllUsers();
            UsersListView.ItemsSource = users;
        }

        private void UserInfoChanged_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                // Retrieve the user object associated with the TextBox
                User user = textBox.DataContext as User;

                if (user != null)
                {
                    // Call the service client to update the user
                    new ServiceClient().UpdateUser(user);
                }
            }
        }
    }
}
