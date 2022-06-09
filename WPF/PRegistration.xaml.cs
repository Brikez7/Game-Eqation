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

        private void EqualPasswords() 
        {
            if (FPassword.Text != FReplPassword.Text)
            {
                FPassword.Clear();
                FReplPassword.Clear();
                MessageBox.Show("Password not equal");
                return;
            }
        }


        private void CheckVoidFields()
        {
            if (FPassword.Text == "" || FName.Text == "" || FReplPassword.Text == "")
            {
                MessageBox.Show("Feilds is void");
                return;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EqualPasswords();
            CheckVoidFields();
            string nameUser = FName.Text;
            string password = FPassword.Text;
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
            if (WindowMethods.CheckExit) WindowMethods.Exit();
        }
    }
}
