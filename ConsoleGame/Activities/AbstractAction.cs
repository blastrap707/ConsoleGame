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
            new Beg(),
            new Gamble(),
        };

        private static string OptionUi()
        {
            Console.WriteLine("活動をお選びください");
            Console.WriteLine();

            var cm = new OptionManager();

            var c = cm.ShowOptions(
                Activities.Select(e => new Option<AbstractAction>($"{e.OptionName}", e)).ToList()
            );

            if (c != null)
            {
                var item = c.Extension;
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
        }

        protected abstract void GetLatestCondition(PayBackPlanner condition);

        protected abstract string OptionName { get; }

        protected abstract int TimeCost { get; }

        protected abstract int Earnings { get; set; }

        protected abstract string RuleExplanation();
    }
}