using MahApps.Metro.Controls;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using WPF.Classes;
using WPF.Database;

namespace WPF
{
    public partial class PRecordes : MetroWindow
    {
        public PRecordes()
        {
            InitializeComponent();
            DataGridRecordes.ItemsSource = TRecordes.GetTable();///
        }

        private void BSort_Click(object sender, RoutedEventArgs e)
        {
            DataGridRecordes.ItemsSource = TRecordes.Sort();
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

        private void BUpdate_Click(object sender, RoutedEventArgs e)
        {
            DataGridRecordes.ItemsSource = TRecordes.GetTable();
        }

        private static bool CheckFeildIsVoid(string enterName) 
            => enterName == "";
        
        private void BSearch_Click(object sender, RoutedEventArgs e)
        {
            string enterName = FName.Text;
            if (CheckFeildIsVoid(enterName))
            {
                MessageBox.Show("Field is void");
                return;
            }

            Record? record = new Record();
            if (TRecordes.Search(enterName, out record)) 
            {
                DataGridRecordes.ItemsSource = new List<Record?>() { record };
                MessageBox.Show("User found");
            }
            else 
            {
                MessageBox.Show("User not found");
            }
        }
    }
}
