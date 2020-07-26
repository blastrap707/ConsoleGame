using System;
using System.Linq.Expressions;

namespace ConsoleGame.Relationships
{
    //一人の友人関係を示すクラス
    public class Friend : Connections
    {
        //友達に嫌われると、追い出されるから、好感度をアップする
        // if 好感度
        public Friend()
        {
        }

        public override int Borrow { get; set; }

        public override int Likes { get; set; }

        public override int TotalBorrowing { get; set; }

        public override int OnetimeLimit { get; set; }

        public override bool CanLend => CheckIfLend();

        private bool CheckIfLend()
        {
            if (Borrow > OnetimeLimit)
            {
                Console.WriteLine("向こうの一回で貸せる金額を超えちゃっている");
                return false;
            }
            if (Likes <= 0)
            {
                Console.WriteLine("もうこの人から嫌われている");
                return false;
            }

            if (TotalBorrowing + Borrow > 300000)
            {
                Console.WriteLine("もうこの人から借りすぎている");
                return false;
            }

            return true;
        }

        public override string FriendName { get; set; }

        public string Relationship { get; set; }

        public bool HasMarried { get; set; }

        public bool HasChild { get; set; }
        public int Income { get; set; }
    }
}