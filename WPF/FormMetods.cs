using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF
{
    internal class WindowMethods
    {
        public static void ShowMain(Window This)
        {
            MainWindow maneform = new MainWindow();
            This.Visibility = Visibility.Collapsed;
            maneform.Show();
        }

        public static void InManeShowOtherForm(Window This, Type A)
        {
            (Activator.CreateInstance(A) as Window).Show();
            This.Visibility = Visibility.Collapsed;
        }

        public static void ShowOtherForm(Window This, Type A)
        {
            Window instance = Activator.CreateInstance(A) as Window;
            This.Visibility = Visibility.Collapsed;
            instance.Show();
        }
        public static void Exit() => Environment.Exit(0);
    }
}