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
using System.Xml;


namespace Client
{
    /// <summary>
    /// Interaction logic for UsersTableWindow.xaml
    /// </summary>
    public partial class UsersTableUserControl : UserControl
    {
        private ServiceClient service = new ServiceClient();
        public UsersTableUserControl()
        {
            InitializeComponent();
            GetUsers();
            UsersListView.MouseDoubleClick += UsersListView_MouseDoubleClick;

        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hello");
        }

        private void GetUsers()
        {
            UserList users = new ServiceClient().SelectAllUsers();
            UsersListView.ItemsSource = users;
            //UsersListView.MouseDoubleClick += UsersListView_MouseDoubleClick;
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
                    service.UpdateUser(user);
                }
            }
        }

        private void UsersListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            for (int itemIndex = 0; itemIndex < UsersListView.Items.Count; itemIndex++)
            {
                ListViewItem item = (ListViewItem)UsersListView.Items[itemIndex];
                Rectangle itemRect = item.GetBounds(ItemBoundsPortion.Label);
                if (itemRect.Contains(e.Location))
                {
                    item.Checked = !item.Checked;
                    break;
                }
            }
        }


    }
}
