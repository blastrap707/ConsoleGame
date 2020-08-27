using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using ConsoleGame.Options;

namespace ConsoleGame
{
    //返済進捗を管理するクラス
    //返済を行う

    public class PayBackPlanner
    {
        public PayBackPlanner(int debt, int cash, int days)
        {
            DebtToPay = debt;
            Cash = cash;
            DaysToDeadline = days;
            HoursLeft = 24;
        }

        public PayBackPlanner()
        {
        }

        public int Cash { get; set; }
        public int DebtToPay { get; set; }
        public int DaysToDeadline { get; set; }

        public int HoursLeft { get; set; }
        private bool IfAfforable { get; set; }

        private int PayBackAmount { get; set; }

        private bool IfPayBack { get; set; }

        private void AdjustShownItems(PayBackPlanner condition)
        {
            if (condition.DaysToDeadline == 30)
            {
                condition.HoursLeft = 0;
                return;
            }
            if (condition.Cash < 0)
            {
                condition.DebtToPay -= condition.Cash;
                condition.Cash = 0;
            }

            if (condition.HoursLeft < 0)
            {
                condition.HoursLeft += 24;
                condition.DaysToDeadline -= 1;
            }
        }

        public void ShowLatestCondition(PayBackPlanner condition)
        {
            AdjustShownItems(condition);
            Console.WriteLine("============================");
            Console.WriteLine("現時点の返済進捗状況");
            Console.WriteLine($"手元の現金:{condition.Cash}円\r\n" +
                                               $"残りの返済金額:{condition.DebtToPay}円\r\n" +
                                               $"返済期限日まではあと：{condition.DaysToDeadline }日 {condition.HoursLeft} 時間");
            Console.WriteLine("============================");
        }

        private void AskIfPayback(PayBackPlanner condition)
        {
            if (condition.Cash <= 0) return;

            Console.WriteLine("手元にある現金から返済しますか？");

            IfPayBack = YesNoOptions.GetYesOrNo();

            if (!IfPayBack)
            {
                Console.WriteLine("返済しない");
            }
        }

        private void CheckIfAfforable(PayBackPlanner condition)
        {
            Console.WriteLine("返済する金額を入力してください。");
            while (!IfAfforable)
            {
                var payback = int.TryParse(Console.ReadLine(), out var num) ? num : 0;
                if (payback <= 0)
                {
                    Console.WriteLine("返済金額の入力ミス");
                    IfAfforable = false;
                    continue;
                }

                if (payback > condition.Cash || condition.Cash <= 0)
                {
                    Console.WriteLine("現金が足りません。");
                    IfAfforable = false;
                    continue;
                }

                if (payback > condition.DebtToPay)
                {
                    Console.WriteLine("債務金額より大きい金額での返済はできません。");
                    continue;
                }
                IfAfforable = true;
                PayBackAmount = payback;
            }
        }

        public void PayBack(PayBackPlanner condition)
        {
            AskIfPayback(condition);
            if (!IfPayBack) return;
            CheckIfAfforable(condition);
            if (!IfAfforable) return;

            condition.Cash -= PayBackAmount;
            condition.DebtToPay -= PayBackAmount;
            condition.DaysToDeadline -= 1;

            Console.WriteLine($"{PayBackAmount}円を返済できました。");
            ShowLatestCondition(condition);
        }
    }
}