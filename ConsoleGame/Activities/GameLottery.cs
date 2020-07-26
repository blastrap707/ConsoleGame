using System;

namespace ConsoleGame.Activities
{
    //一回のゲームを示すクラス
    internal class GameLottery : Gamble
    {
        protected override string OptionName => "Lottery";
        protected int SingleGame => -500;
        protected int JackPot => 1000000;
        protected string RangeSetting => "1~100";
        protected int Limitation => 5;
        protected override int TimeCost => 1;

        protected override bool IfPlayGame { get; set; }

        protected override int Earnings { get; set; }

        protected override string RuleExplanation() =>
            "＝＝＝＝＝ルール＝＝＝＝＝＝ \r\n " +
            $"{RangeSetting}の中から数字を当てるゲームです。" +
            "Hintを使うと、正解の数字は、より大きいか小さいかの情報が得られます。\r\n" +
            $"Hintは最大{Limitation}回、一回は１００円かかります。\r\n" +
            $"一回プレイするには、{SingleGame} がかかり、時間は{TimeCost}、。\r\n" +
            $"成功したら、{JackPot}もらえます";

        private void BuyLottery()
        {
            var time = 0;
            var r1 = new Random();
            var answer = r1.Next(1, 101);
            while (time < Limitation)
            {
                Console.WriteLine("0~100の整数を一つ入力してください。");
                Console.WriteLine("=>");
                var correctInput = int.TryParse(Console.ReadLine(), out var input);
                if (!correctInput || input <= 0 || input > 100)
                {
                    Console.WriteLine("入力ミス");
                    continue;
                }

                time++;
                if (input == answer)
                {
                    Console.WriteLine("当たりです。");
                    Console.WriteLine($"{answer}が正解です。");
                    Console.WriteLine("50万円を差し上げます。");
                    Earnings = JackPot;
                    return;
                }
                Console.WriteLine("外れです");
                Console.WriteLine($"残り{5 - time}回");
            }
            Earnings = SingleGame;
        }

        protected override void GetLatestCondition(PayBackPlanner condition)
        {
            while (true)
            {
                BuyLottery();
                condition.Cash += Earnings;
                condition.HoursLeft -= TimeCost;
                if (Earnings > 0)
                {
                    Console.WriteLine($"gambleで{Earnings}円を得ました。");
                }
                else if (Earnings < 0)
                {
                    Console.WriteLine($"gamble代金：{SingleGame}");
                }
                AskIfContinue();
                return;
            }
        }

        private void AskIfContinue()
        {
            while (true)
            {
                Console.WriteLine("=================================");
                Console.WriteLine("もう一回ギャンブルしますか？");
                Console.WriteLine("yes:1,no:0");
                Console.WriteLine("=================================");
                var correctOption = int.TryParse(Console.ReadLine(), out var option);
                if (!correctOption || (option != 0 && option != 1))
                {
                    Console.WriteLine("選択肢の入力ミス");
                    continue;
                }
                if (option == 0)
                {
                    IfPlayGame = false;
                    return;
                }
                IfPlayGame = true;
                return;
            }
        }
    }
}