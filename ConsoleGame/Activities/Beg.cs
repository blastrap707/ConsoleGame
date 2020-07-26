﻿using System;
using ConsoleGame.Relationships;

namespace ConsoleGame.Activities
{
    internal class Beg : AbstractAction
    {
        protected override string OptionName => "知り合いから借りる";
        protected override int TimeCost => 5;
        protected override int Earnings { get; set; }

        protected override string RuleExplanation() => "abc";

        protected override void GetLatestCondition(PayBackPlanner condition)
        {
            Borrow();
            condition.Cash += Earnings;
            condition.HoursLeft -= TimeCost;
        }

        private void Borrow()
        {
            var friend = Connections.ChooseFriends();

            while (true)
            {
                Console.WriteLine("借りたい金額を入力してください。");
                friend.Borrow = int.TryParse(Console.ReadLine(), out var num) ? num : 0;

                if (friend.Borrow <= 0)
                {
                    Console.WriteLine("金額の入力は適切ではない。");
                    continue;
                }

                if (!friend.CanLend)
                {
                    Console.WriteLine("だから、借りることができません。");
                    Earnings = 0;
                    return;
                }

                Console.WriteLine($"友人から{friend.Borrow}円をいただけました。");
                friend.Likes -= 1;
                friend.TotalBorrowing += friend.Borrow;

                Console.WriteLine($"{friend.FriendName}さんのLikesは、{friend.Likes}");
                Earnings = friend.Borrow;
                return;
            }
        }
    }
}