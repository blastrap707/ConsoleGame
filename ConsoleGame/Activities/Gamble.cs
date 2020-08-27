using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using ConsoleGame.Options;
using ConsoleGame.Relationships;

namespace ConsoleGame.Activities
{
    internal class Gamble : AbstractAction
    {
        protected override string OptionName => "ギャンブルする";

        protected override int TimeCost { get; }
        protected override int Earnings { get; set; }
        protected virtual bool IfPlayGame { get; set; }

        private static readonly Gamble[] Games = {
            new GameLottery(),
            new Game2(),
        };

        private static Dictionary<string, Gamble> Gambles => Games
            .ToDictionary(x => x.OptionName);

        protected override string RuleExplanation() => "abc";

        private string GetSelectedGame()
        {
            Console.WriteLine("ゲームをお選びください");
            Console.WriteLine();

            var cm = new OptionManager();

            var c = cm.ShowOptions(
                Games.Select(e => new Option<Gamble>($"{e.OptionName}", e)).ToList()
            );

            Console.WriteLine($"{c?.Caption ?? "キャンセル"} が選択されました");

            if (c == null) return null;
            var item = c.Extension;
            //Console.WriteLine($"{item.OptionName}を選択した");
            return item.OptionName;
        }

        public Gamble ChooseGames()
        {
            return Gambles.GetValueOrDefault(GetSelectedGame());
        }

        //一回のゲーム
        protected override void GetLatestCondition(PayBackPlanner condition)
        {
            if (condition.Cash <= 0)
            {
                Console.WriteLine("手元には現金が足りないため、ギャンブルができない。");
                return;
            }

            var game = ChooseGames();
            game.IfPlayGame = true;

            while (game.IfPlayGame)
            {
                game.GetLatestCondition(condition);
            }
            Console.WriteLine("ゲーム終了");
            Console.Clear();
        }
    }
}