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
           if(CheckData())
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
                    MessageBox.Show(loginUser.UserName, "Ok", MessageBoxButton.OK);
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
