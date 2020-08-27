using System;
using System.Linq.Expressions;

namespace ConsoleGame.Relationships
{
    //一人の友人関係を示すクラス
    public class Friend : Connections
    {
        public Friend()
        {
        }

        public override int Borrow { get; set; }

        public override int Likes { get; set; }

        public override int TotalBorrowing { get; set; }

        private readonly int TotalAfforable = 300000;

        public override int OnetimeLimit { get; set; }

        public override bool CanLend => CheckIfBorrable();

        private bool CheckIfBorrable()
        {
            if (Borrow > OnetimeLimit)
            {
                Console.WriteLine("借りてくれなかった。");
                Console.WriteLine("金額が大きすぎたかも？");
                return false;
            }
            if (Likes <= 0)
            {
                Console.WriteLine("借りてくれなかった。");
                Console.WriteLine("この人に嫌われているかも？");
                return false;
            }

            if (TotalBorrowing + Borrow > TotalAfforable)
            {
                Console.WriteLine("借りてくれなかった。");
                Console.WriteLine("借りすぎているかも？");
                return false;
            }
            return true;
        }

        public override string FriendName { get; set; }
    }
}