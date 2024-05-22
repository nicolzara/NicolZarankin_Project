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
    /// Interaction logic for UserUserControl.xaml
    /// </summary>
    public partial class UserUserControl : UserControl
    {
        public enum PermissionLevel
        {
            Teen, // have permission only to foreign exchange
            Normal, // have permission to foreign exchange and stock
            Manager // have permission to everything including users
        }
        private User user;
        public UserUserControl(User user)
        {
            InitializeComponent();
            this.user = user;
            UploadData();
        }

        private void UploadData()
        {
            UsernameTextBlock.Text += user.UserName;
            EmailTextBlock.Text += user.Email;
            FreeBalanceTextBlock.Text += user.FreeBalance.ToString();
            if(user.PermissionLevel == ((int)PermissionLevel.Teen))
            {
                PermissionLevelTextBlock.Text += "Teen";
            }
            else if(user.PermissionLevel == (int)PermissionLevel.Normal)
            {
                PermissionLevelTextBlock.Text += "Normal";
            }
            else if(user.PermissionLevel == (int)PermissionLevel.Manager)
            {
                PermissionLevelTextBlock.Text += "Manager";
            }
        }
    }
}
