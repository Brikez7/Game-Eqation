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
using WPF.Classes;

namespace WPF
{
    /// <summary>
    /// Interaction logic for PRecordes.xaml
    /// </summary>
    public partial class PRecordes : Window
    {
        public PRecordes()
        {
            InitializeComponent();
            DataGridRecordes.ItemsSource = TRecordes.GetTable();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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

        private void BSearch_Click(object sender, RoutedEventArgs e)
        {
            Record? record = new Record();
            if (TRecordes.Search(FName.Text,out record)) 
            {
                DataGridRecordes.ItemsSource = new List<Record?>() { record };
                MessageBox.Show("Пользователь найден");
            }
            else 
            {
                MessageBox.Show("Пользователь не найден");
            }
        }
    }
}
