using SimplifiedSlotMachine.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SimplifiedSlotMachine.Services
{
    public class SlotMachine : ISlotMachine
    {
        private Dictionary<char, double> _coefficients { get; }

        public SlotMachine()
        {
            _coefficients = new Dictionary<char, double>()
            {
                { 'A', 0.4 },
                { 'B', 0.6 },
                { 'P', 0.8 },
                { '*', 0 }
            };
        }

        public PlayResult Play(decimal stake)
        {
            double coefficient = 0.0;
            StringBuilder rounds = new StringBuilder();

            for (int i = 0; i < 4; i++)
            {
                var round = ConstructRound();
                rounds.AppendLine(round);
                if (CheckIfRoundIsLegit(round))
                {
                    foreach (var chr in round)
                    {
                        coefficient += _coefficients[chr];
                    }
                }
            }

            var amount = stake * (decimal)coefficient;

            var result = new PlayResult()
            {
                Rounds = rounds.ToString(),
                Amount = amount
            };

            return result;
        }

        private string ConstructRound()
        {
            Random rnd = new Random();
            StringBuilder round = new StringBuilder();

            for (int i = 0; i < 3; i++)
            {
                var num = rnd.Next(100);

                if (num <= 45)
                {
                    round.Append("A");
                }
                else if (num > 45 && num <= 80)
                {
                    round.Append("B");
                }
                else if (num > 80 && num <= 95)
                {
                    round.Append("P");
                }
                else
                {
                    round.Append("*");
                }
            }

            return round.ToString();
        }

        public bool CheckIfRoundIsLegit(string round)
        {
            var reg = new Regex("[A|*]{3}|[B|*]{3}|[P|*]{3}");
            if (reg.IsMatch(round))
            {
                return true;
            }

            return false;
        }
    }
}
