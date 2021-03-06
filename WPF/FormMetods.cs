using System;
using System.Windows;

namespace WPF
{
    internal class WindowMethods
    {
        public static bool CheckExit = false;

        public static void ShowMain(Window This)
        {
            MainWindow maneform = new MainWindow();
            This.Close();
            maneform.Show();
            CheckExit = true;
        }

        public static void InManeShowOtherForm(Window This, Type A)
        {
            Window? instance = (Activator.CreateInstance(A) as Window);
            instance?.Show();
            This.Visibility = Visibility.Collapsed;
            CheckExit = true;
        }

        public static void ShowOtherForm(Window This, Type A)
        {
            Window? instance = Activator.CreateInstance(A) as Window;
            This.Close();
            instance?.Show();
            CheckExit = true;
        }

        public static void Exit() 
            => Environment.Exit(0);
    }
}