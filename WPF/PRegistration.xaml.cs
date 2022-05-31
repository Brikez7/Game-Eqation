using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;

namespace WPF
{
    public partial class PRegistration : Window
    {
        public PRegistration()
        {
            InitializeComponent();
        }
        private void equalPasswords() 
        {
            if (BPassword.Text != BReplPassword.Text)
            {
                BPassword.Clear();
                BReplPassword.Clear();
                MessageBox.Show("Пароли не совпадают");
                return;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            equalPasswords();

        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
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
