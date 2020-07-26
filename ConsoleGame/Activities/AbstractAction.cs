using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleGame.Options;
using ConsoleGame.Relationships;

namespace ConsoleGame.Activities
{
    //主人公にできるアクティビティを提供するクラス
    public abstract class AbstractAction
    {
        private static readonly AbstractAction[] Activities = {
            new WorkPartTime(),
            new Beg(),
            new Gamble(),
        };

        public static List<Friend> GetFriends { get; set; }

        private static string OptionUi()
        {
            Console.WriteLine("活動をお選びください");
            Console.WriteLine();

            var cm = new OptionManager();

            var c = cm.ShowOptions(
                Activities.Select(e => new Option<AbstractAction>($"{e.OptionName}", e)).ToList()
            );

            Console.WriteLine($"{c?.Caption ?? "キャンセル"} が選択されました");

            if (c != null)
            {
                var item = c.Extension;
                Console.WriteLine($"{item.OptionName}を選択した");
                return item.OptionName;
            }
            return null;
        }

        private static Dictionary<string, AbstractAction> Action => Activities
            .ToDictionary(x => x.OptionName);

        public static AbstractAction ChooseAction()
        {
            return Action.GetValueOrDefault(OptionUi());
        }

        public void TakeAction(PayBackPlanner condition)
        {
            GetLatestCondition(condition);
            var latestCondition = new PayBackPlanner();
            latestCondition.ShowLatestCondition(condition);
            latestCondition.PayBack(condition);
            //PayBackPlanner.GetPresentCondition(condition);
        }

        protected abstract void GetLatestCondition(PayBackPlanner condition);

        protected abstract string OptionName { get; }

        protected abstract int TimeCost { get; }

        protected abstract int Earnings { get; set; }

        protected abstract string RuleExplanation();
    }
}