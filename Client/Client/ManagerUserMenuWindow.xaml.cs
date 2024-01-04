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
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Interaction logic for ManagerUserMenuWindow.xaml
    /// </summary>
    public partial class ManagerUserMenuWindow : Window
    {
        public ManagerUserMenuWindow()
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
    }
}
