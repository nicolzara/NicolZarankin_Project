using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
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
using Newtonsoft.Json;
using MaterialDesignThemes.Wpf;
using Client.ServiceReferenceVirWallet;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public enum PermissionLevel
        {
            Teen, // have permission only to foreign exchange
            Normal, // have permission to foreign exchange and stock
            Manager // have permission to everything including users
        }

        private User user;
        public LoginWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            user = new User();
            this.DataContext = user;
        }

        /// <summary>
        /// Sends a login request to the server
        /// </summary>
        private void LoginClick(object sender, RoutedEventArgs e)
        {
            ServiceClient service1 = new ServiceClient();
            User loginUser1 = service1.Login("Nicol","Asd123@#");
            ManagerUserMenuWindow w1 = new ManagerUserMenuWindow(loginUser1);
            w1.ShowDialog();
            if (CheckData())
            {
                // do login while using the service
                ServiceClient service = new ServiceClient();
                User loginUser = service.Login(user.UserName, user.Password);
                if(loginUser == null)
                {
                    MessageBox.Show("User not found");
                }
                else
                {
                    if (loginUser.PermissionLevel == ((int)PermissionLevel.Teen))
                    {
                        TeenUserMenuWindow teenUserMenuWindow = new TeenUserMenuWindow(user);
                        teenUserMenuWindow.WindowStartupLocation = WindowStartupLocation.Manual;
                        teenUserMenuWindow.Left = this.Left;
                        teenUserMenuWindow.Top = this.Top;
                        Close();
                        teenUserMenuWindow.ShowDialog();
                    }
                    else if (loginUser.PermissionLevel == ((int)PermissionLevel.Normal))
                    {
                        NormalUserMenuWindow normalUserMenuWindow = new NormalUserMenuWindow(user);
                        normalUserMenuWindow.WindowStartupLocation = WindowStartupLocation.Manual;
                        normalUserMenuWindow.Left = this.Left;
                        normalUserMenuWindow.Top = this.Top;
                        Close();
                        normalUserMenuWindow.ShowDialog();
                    }
                    else if(loginUser.PermissionLevel == ((int)PermissionLevel.Manager))
                    {
                        ManagerUserMenuWindow managerUserMenuWindow = new ManagerUserMenuWindow(user);
                        managerUserMenuWindow.WindowStartupLocation = WindowStartupLocation.Manual;
                        managerUserMenuWindow.Left = this.Left;
                        managerUserMenuWindow.Top = this.Top;
                        Close();
                        managerUserMenuWindow.ShowDialog();
                    }
                }                
            }
           else
            {
                MessageBox.Show("You have an error", "Error", MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Clears the data of the text boxes of username and password
        /// </summary>
        private void ClearClick(object sender, RoutedEventArgs e)
        {
            user = new User();
            UserNameTextBox.Clear();
            PasswordBox.Clear();
            HintAssist.SetHelperText(PasswordBox, "Enter your password");
        }

        /// <summary>
        /// Opens sign up window and closes login window
        /// </summary>
        private void SignUpClick(object sender, RoutedEventArgs e)
        {
            SignupWindow signupWindow = new SignupWindow();
            signupWindow.WindowStartupLocation = WindowStartupLocation.Manual;
            signupWindow.Left = this.Left;
            signupWindow.Top = this.Top;
            Close();
            signupWindow.ShowDialog();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ValidationPassword validationPassword = new ValidationPassword();
            ValidationResult result = validationPassword.Validate(PasswordBox.Password, null);
            if (result.IsValid)
            {
                HintAssist.SetHelperText(PasswordBox, "Password");
                user.Password = PasswordBox.Password;
            }
            else
            {
                HintAssist.SetHelperText(PasswordBox, result.ErrorContent.ToString());
            }
        }

        private bool CheckData()
        {
            if (UserNameTextBox.Text.Equals(string.Empty)) return false;
            if (PasswordBox.Password.Equals(string.Empty)) return false;
            if (Validation.GetHasError(UserNameTextBox)) return false;
            if (!HintAssist.GetHelperText(PasswordBox).ToString().Equals("Password")) return false; ;
            return true;
        }
    }
}
