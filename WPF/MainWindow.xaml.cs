using System;
using System.Windows;

namespace WPF
{
    public partial class MainWindow : Window 
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BRecordes_Click(object sender, RoutedEventArgs e)
        {
            WindowMethods.InManeShowOtherForm(this, typeof(PRecordes));
        }

        private void BAutorisation_Click(object sender, RoutedEventArgs e)
        {
            WindowMethods.InManeShowOtherForm(this, typeof(PAuvtorisation));
        }

        private void BPaly_Click(object sender, RoutedEventArgs e)
        {
            WindowMethods.InManeShowOtherForm(this, typeof(PPlayGame));
        }

        private void BRegistration_Click_1(object sender, RoutedEventArgs e)
        {
            WindowMethods.InManeShowOtherForm(this, typeof(PRegistration));
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            WindowMethods.Exit();
        }
    }
}
