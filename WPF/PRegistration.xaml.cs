using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Input;
using WPF.Classes;

namespace WPF
{
    public partial class PRegistration : MetroWindow
    {
        public PRegistration()
        {
            InitializeComponent();
        }

        private static bool EqualPasswords(string password,string repeatPassowrd) 
            => password == repeatPassowrd;

        private static bool CheckVoidFields(string nameUser,string password,string repitPassword)
            => nameUser == "" || password == "" || repitPassword == "";


        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            string nameUser = FName.Text;
            string password = FPassword.Text;
            string repeatPassword = FReplPassword.Text;

            if (CheckVoidFields(nameUser, password, repeatPassword))
            {
                MessageBox.Show("Feilds is void");
                return;
            }

            if (!EqualPasswords(password, repeatPassword))
            {
                ClearPasswords();
                MessageBox.Show("Password not equal");
                return;
            }

            if (!TUsers.SearchUser(nameUser))
            {
                TUsers.Add(nameUser, password);
                ClearFeild();
                MessageBox.Show("Registration completed successfully");
            }
            else 
            { 
                MessageBox.Show("Accaunt with name is exists");
                FName.Clear();
            }
        }

        private void ClearPasswords()
        {
            FPassword.Clear();
            FReplPassword.Clear();
        }

        private void ClearFeild() 
        {
            FName.Clear();
            FPassword.Clear();
            FReplPassword.Clear();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Key.Escape == e.Key)
            {
                WindowMethods.CheckExit = false;
                WindowMethods.ShowMain(this);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (WindowMethods.CheckExit) 
                WindowMethods.Exit();
        }
    }
}
