using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Tasking;

namespace WPF
{
    internal class Game
    {
        private double _score;
        private int _round = 1;
        private double _enemy;
        public static double _coficent { get; private set; } = 0.5;

        public Game(double score, double enemy)
        {
            _score = score;
            _enemy = enemy;
        }

        public Game(double score, int coficent, double enemy)
        {
            _score = score;
            _coficent = coficent;
            _enemy = enemy;
        }

        public int GetRound() => _round;
        public double GetEnemy() => Math.Round(_enemy * Math.Pow(_coficent, 2),2); 
        public double GetScore() => _score;

        public void NextRound(double unswer) 
        {
            _round++;
            _score += unswer;
            _score -= Math.Round(_enemy * Math.Pow(_coficent, 2),2);
            _score = Math.Round(_score,2);
            _coficent += 0.1;
        }

        public bool CheckLose() => _score < 0;
    }
}
