using System;
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
        private static Game game;
        private static List<ButtonEquation> _buttonEquations = new();
        private delegate void EventHandlerClick();
        private static event EventHandlerClick? UpdateInfoOnLabel;
        private static bool IsClick = true;

        public static void Update(double score = 100,double enemy = 10) 
        {
            game = new Game(score, enemy);
            UpdateAllButtonEquation();
            UpdateInfoOnLabel?.Invoke();
            IsClick = true;
        }

        public static void GetEvent(Action action) 
        {
            UpdateInfoOnLabel += () => action();
        }

        static ButtonEquation() 
        {
            game = new Game(100, 10);
        }

        public ButtonEquation()
        {
            InitializeComponent();
            CreateEquation();
        }

        private void CreateEquation()
        {
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

        public static int GetRound()
            => game.GetRound();

        public static double GetEnemy() 
            => game.GetEnemy();

        public static double GetScore() 
            => game.GetScore();

        private static void BlockClick() 
            => IsClick = false;


        private static void CheckRecord() 
        {
            int lastRound = game.GetRound();
            if (!ActiveUser.CheckActive())
            {
                MessageBox.Show($"You not been autorisation\nYour high score {lastRound} but your high score not be add or update");
                return;
            }

            string? nameActiveUser = ActiveUser.GetName();
            if (TRecordes.Search(nameActiveUser))
            {
                if (ActiveUser.UpdateRecord(lastRound))
                {
                    MessageBox.Show($"Your high score {lastRound} and he has been updated");
                }
                else 
                {
                    MessageBox.Show($"Your previous record was higher\nTry again");
                }
            }
            else 
            {
                MessageBox.Show($"Your high score {lastRound} and it been added to the table recordes");
                ActiveUser.AddRecord(lastRound);
            }
        }

        private void Equation_Click(object sender, RoutedEventArgs e)
        {
            if (IsClick)
            {
                double unswer = _equation.GetUnswer();
                game?.NextRound(unswer);

                if (game.CheckLose())
                {
                    BlockClick();
                    CheckRecord();
                    UpdateInfoOnLabel?.Invoke();
                    return;
                }
                UpdateInfoOnLabel?.Invoke();
                UpdateAllButtonEquation();
            }
        }
    }
}
