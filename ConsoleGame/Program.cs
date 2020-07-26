using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using ConsoleGame.Activities;
using ConsoleGame.Relationships;

namespace ConsoleGame
{
    //500万の借金を返済するゲーム（一週間で）
    //バーでアルバイト、ギャンブル
    //一か月内で全額返済できなかったら、ホームレスになるか、手元に30万現金あれば、海外に逃亡し、一生母国に帰れなくなる。

    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(GameRules.Instruction);

            const int debt = 1000000;
            const int cash = 100000;
            const int dayLeft = 30;

            var condition = new PayBackPlanner(debt, cash, dayLeft);
            condition.ShowLatestCondition(condition);

            while (condition.DaysToDeadline != 0 && condition.DebtToPay != 0)
            {
                var action = AbstractAction.ChooseAction();
                action.TakeAction(condition);
            }

            if (condition.DaysToDeadline == 0 && condition.DebtToPay > 0)
            {
                Console.WriteLine("期限内で返済をできませんでした。");
                if (condition.Cash > 100000)
                {
                    Console.WriteLine("海外へ逃亡するか、ホームレスになるか？");
                }
            }
            else if (condition.DaysToDeadline > 0 && condition.DebtToPay == 0)
            {
                Console.WriteLine("期限内で返済することができました。。おめでとうございます！");
            }
        }
    }
}