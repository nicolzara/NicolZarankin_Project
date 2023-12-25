using Client.ServiceReferenceVirWallet;
using MaterialDesignThemes.Wpf;
using Newtonsoft.Json;
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
    /// Interaction logic for SignupWindow.xaml
    /// </summary>
    public partial class SignupWindow : Window
    {
        public enum PermissionLevel
        {
            Teen, // have permission only to foreign exchange
            Normal, // have permission to foreign exchange and stock
            Manager // have permission to everything including users
        }
        private User user;

        public SignupWindow()
        {
            InitializeComponent();
            user = new User();
            this.DataContext = user;
        }

        /// <summary>
        /// Clears the data of all the text boxes
        /// </summary>
        private void ClearClick(object sender, RoutedEventArgs e)
        {
            user = new User();
            this.DataContext = user;
            BirthdateDatePicker.SelectedDate = null;

        }

        /// <summary>
        /// Sends a signup request to the server
        /// </summary>
        private void SignupClick(object sender, RoutedEventArgs e)
        {
            if(CheckData())
            {
                user.FreeBalance = 0;   
                DateTime currentDate = DateTime.Now;
                if (BirthdateDatePicker.SelectedDate.HasValue)
                { 
                    DateTime selectedDate = DateTime.Parse(BirthdateDatePicker.SelectedDate.ToString());               
                    if(CalculateAge(selectedDate) < 18)
                    {
                        user.PermissionLevel = ((int)PermissionLevel.Teen);
                        MessageBox.Show(user.PermissionLevel.ToString());
                    }
                    else
                    {
                        user.PermissionLevel = ((int)PermissionLevel.Normal);
                    }


                }
                else
                {
                    MessageBox.Show("No date selected.");
                }
            }

            else
            {
                MessageBox.Show("You have an error", "Error", MessageBoxButton.OK);
            }
        }


        /// <summary>
        /// Opens login window and closes sign up window
        /// </summary>
        private void LoginClick(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.WindowStartupLocation = WindowStartupLocation.Manual;
            loginWindow.Left = this.Left;
            loginWindow.Top = this.Top;
            Close();
            loginWindow.ShowDialog();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ValidationPassword validationPassword = new ValidationPassword();
            ValidationResult result = validationPassword.Validate(PasswordBox.Password, null);
            if (result.IsValid)
            {
                HintAssist.SetHelperText(PasswordBox, "Password");
            }
            else
            {
                HintAssist.SetHelperText(PasswordBox, result.ErrorContent.ToString());
            }
        }

        private void BirthdateDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime currentDate = DateTime.Now;
            DateTime? selectedDate = BirthdateDatePicker.SelectedDate;

            if (selectedDate.HasValue)
            {
                if (selectedDate > currentDate)
                {
                    HintAssist.SetHelperText(BirthdateDatePicker, "you can't born in the future");
                }

                else
                {
                    HintAssist.SetHelperText(BirthdateDatePicker, "Birthdate");
                }
            }
            else
            {
                HintAssist.SetHelperText(BirthdateDatePicker, "Enter your birthdate");
            }
        }

        private bool CheckData()
        {
            if (UserNameTextBox.Text.Equals(string.Empty)) return false;
            if (PasswordBox.Password.Equals(string.Empty)) return false;
            if (EmailTextBox.Text.Equals(string.Empty)) return false;
            if (PhoneNumberTextBox.Text.Equals(string.Empty)) return false;
            if (!BirthdateDatePicker.SelectedDate.HasValue) return false;
            if (Validation.GetHasError(UserNameTextBox)) return false;
            if (Validation.GetHasError(EmailTextBox)) return false;
            if (Validation.GetHasError(PhoneNumberTextBox)) return false;
            if (!HintAssist.GetHelperText(PasswordBox).ToString().Equals("Password")) return false;
            if (DateTime.Now < DateTime.Parse(BirthdateDatePicker.SelectedDate.ToString())) return false;
            return true;
        }

        static int CalculateAge(DateTime birthDate)
        {
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - birthDate.Year;

            // Check if the birthday has occurred this year
            if (birthDate > currentDate.AddYears(-age))
            {
                age--;
            }

            return age;
        }
    }
}
