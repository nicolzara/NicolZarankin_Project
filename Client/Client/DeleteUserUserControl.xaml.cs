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
    /// Interaction logic for DeleteUserUserControl.xaml
    /// </summary>
    public partial class DeleteUserUserControl : UserControl
    {
        private User user;
        public DeleteUserUserControl(User user)
        {
            this.user = user;
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            UserList list = new ServiceClient().SelectAllUsers();
            UsersComboBox.ItemsSource = list;
        }

        private void ClearClick(object sender, RoutedEventArgs e)
        {
            UsersComboBox.SelectedIndex = -1;
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            User user = UsersComboBox.SelectedItem as User;
            (new ServiceClient()).DeleteUser(user);
            LoadUsers();
            UsersComboBox.SelectedIndex = -1;
        }
    }
}
