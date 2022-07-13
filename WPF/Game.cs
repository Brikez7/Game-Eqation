using System;

namespace WPF
{
    internal class Game
    {
        private double _score;
        private int _round = 1;
        private double _enemy;
        public static double Coficent { get; private set; } = 0.3;

        public Game(double score, double enemy,double coficent = 0.3)
        {
            _score = score;
            _enemy = enemy;
            Coficent = coficent;
        }

        public Game(double score, int coficent, double enemy)
        {
            _score = score;
            Coficent = coficent;
            _enemy = enemy;
        }

        public int GetRound()
            => _round;

        public double GetEnemy() 
            => Math.Round(_enemy * Math.Pow(Coficent, 2),2); 

        public double GetScore()
            => _score;

        public void NextRound(double unswer) 
        {
            _round++;
            _score += unswer;
            double DeductPointEndRound = Math.Round(_enemy * Math.Pow(Coficent, 2), 2);
            _score -= DeductPointEndRound;
            _score = Math.Round(_score,2);
            Coficent += 0.1;
        }

        public bool CheckLose()
            => _score < 0;
    }
}
