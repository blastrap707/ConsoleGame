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
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(AppConst.Instruction);

            const int debt = 1000000;
            const int cash = 100000;
            const int dayLeft = 30;
            const int escapeBudget = 100000;
            try
            {
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
                    if (condition.Cash >= escapeBudget)
                    {
                        Console.WriteLine($"残りの{condition.Cash}円を使っちゃって、海外へ逃亡しよう！");
                        return;
                    }

                    Console.WriteLine("Game Over");
                }
                else if (condition.DaysToDeadline > 0 && condition.DebtToPay == 0)
                {
                    Console.WriteLine("期限内で返済することができました。。おめでとうございます！");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}