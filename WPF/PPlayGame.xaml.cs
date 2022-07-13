using MahApps.Metro.Controls;
using System;
using System.Windows;
using System.Windows.Input;

namespace WPF
{
    public partial class PPlayGame : MetroWindow
    {
        public PPlayGame()
        {
            InitializeComponent();
            ButtonEquation.GetEvent(UpdateLabels);
        }

        public void UpdateLabels() 
        {
            LEnemy.Content = "Enemy:" + ButtonEquation.GetEnemy();
            LRound.Content = "Round:" + ButtonEquation.GetRound();
            LScore.Content = "Score:" + ButtonEquation.GetScore();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (WindowMethods.CheckExit) WindowMethods.Exit();
        }

        private void WPlay_KeyDown(object sender, KeyEventArgs e)
        {
            if (Key.Escape == e.Key)
            {
                WindowMethods.CheckExit = false;
                WindowMethods.ShowMain(this);
            }
        }

        private void WPlay_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ButtonEquation.Update();
            UpdateLabels();
        }
    }
}
