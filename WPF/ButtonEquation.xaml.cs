﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WPF.Classes;
using WPF.Tasking;

namespace WPF
{
    /// <summary>
    /// Interaction logic for ButtonEquation.xaml
    /// </summary>
    public partial class ButtonEquation : UserControl
    {
        private Equation _equation;
        private static Game game = new Game(100,10);
        private static List<ButtonEquation> _buttonEquations = new();
        private delegate void EventHandlerClick();
        private static event EventHandlerClick? EventHadlerButton;
        private static bool IsClick = true;

        public static void Update() 
        {
            game = new Game(100,10);
            UpdateAllButtonEquation();
            EventHadlerButton?.Invoke();
            IsClick = true;
        }

        public static void GetEvent(Action action) 
        {
            EventHadlerButton += () => action();
        }

        public ButtonEquation()
        {
            InitializeComponent();
            _equation = new Equation();
            GameButton.Content = _equation.GetEqution();
            _buttonEquations.Add(this);
        }

        private static void UpdateAllButtonEquation() 
        {
            for (int i = 0; i < _buttonEquations.Count; i++)
            {
                _buttonEquations[i]._equation = new Equation();
                _buttonEquations[i].GameButton.Content = _buttonEquations[i]._equation.GetEqution();
            }
        }

        public static int GetRound() => game.GetRound();
        public static double GetEnemy() => game.GetEnemy();
        public static double GetScore() => game.GetScore();

        private void Block() => IsClick = false;


        private void CheckRecord() 
        {
            int lastRound = game.GetRound();
            if (!ActiveUser.CheckActive())
            {
                MessageBox.Show($"You not been autorisation\nYour high score {lastRound} but your high score not be add or update");
                return;
            }

            if (TRecordes.Search(ActiveUser.GetName()))
            {
                if (ActiveUser.UpdateRecord(lastRound))
                {
                    MessageBox.Show($"Your high score has been updated");
                }
                else 
                {
                    MessageBox.Show($"Your high score {lastRound} and not been update\nTry again");
                }
            }
            else 
            {
                MessageBox.Show($"Your high score {lastRound} and it been added to the table recordes");
                ActiveUser.AddRecord(lastRound);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (IsClick)
            {
                double unswer = _equation.GetUnswer();
                game.NextRound(unswer);

                if (game.CheckLose())
                {
                    Block();
                    CheckRecord();
                    EventHadlerButton?.Invoke();
                    IsClick = false;
                    return;
                }
                EventHadlerButton?.Invoke();
                UpdateAllButtonEquation();
            }
        }
    }
}