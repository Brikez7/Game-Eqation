using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Input;
using WPF.Classes;

namespace WPF
{
    public partial class PAuvtorisation : MetroWindow
    {
        public PAuvtorisation()
        {
            InitializeComponent();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Key.Escape == e.Key)
            {
                WindowMethods.CheckExit = false;
                WindowMethods.ShowMain(this);
            }
        }
        private void ClearFeilds() 
        {
            FName.Clear();
            FPassword.Clear();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (WindowMethods.CheckExit) WindowMethods.Exit();
        }

        private static bool CheckFilds(string name, string password) 
            => name == "" || password == "";

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = FName.Text;
            string password = FPassword.Text;

            if (CheckFilds(name, password))
            {
                MessageBox.Show("Feilds is void");
                return;
            }

            if (TUsers.CheckPassword(name, password))
            {
                ActiveUser.SetNewUser(name);
                MessageBox.Show("Autorisation completed successfully");
                ClearFeilds();
            }
            else 
            {
                MessageBox.Show("Autorisation faild\nWorng name or password");
                ClearFeilds();
                ActiveUser.Disactive();
            }
        }
    }
}
