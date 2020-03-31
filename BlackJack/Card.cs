using System;

namespace BlackJack
{
    public enum Mark
    {
        Heart,
        Crab,
        Spade,
        Diamond
    }
    public class Card
    {
        public Card(Mark mark,int number)
        {
            if(number > 13 || number <= 0)
            {
                throw new Exception(number + " is not playing card.");
            }

            MarkName = mark;
            Number = number;
            DisplayName = GetDisplayName(mark, number);
        }

        private string GetDisplayName(Mark mark, int number)
        {
            
            var markDic = new System.Collections.Generic.Dictionary<Mark, string>()
            {
                { Mark.Crab,"♣" },
                { Mark.Spade,"♠"},
                { Mark.Diamond,"♢"},
                { Mark.Heart,"♡"}
            };

            string mrkStr = markDic[mark];
            string noStr =
                number == 1 ? "A" :
                number == 11 ? "J":
                number == 12 ? "Q":
                number == 13 ? "K":
                number.ToString();

            return mrkStr + noStr;
        }

        public Mark MarkName { get; private set; }
        public int Number { get; private set; }
        public string DisplayName { get; private set; }
    }
}