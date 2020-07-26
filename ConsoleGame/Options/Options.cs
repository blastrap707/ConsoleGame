//using System;
//using System.Linq;
//using ConsoleGame.Activities;

//namespace ConsoleGame
//{
//    public class Options
//    {
//        public static string OptionUi(AbstractAction [] activities)
//        {
//            Console.WriteLine("選びなさい");
//            Console.WriteLine();

//            var cm = new OptionManager();

//            //var items = new[] {
//            //    new SampleItem() { Name = "知り合いから借りる",ActionName="Beg" },
//            //    new SampleItem() { Name = "夜のアルバイトする",ActionName="Bartend" },
//            //    new SampleItem() { Name = "ギャンブルする",ActionName="Gamble"},
//            //};

//            var c = cm.ShowOptions(
//                activities.Select(e => new Option<AbstractAction>($"{e.OptionName}", e)).ToList()
//            );

//            Console.WriteLine($"{c?.Caption ?? "キャンセル"} が選択されました");

//            if (c != null)
//            {
//                var item = c.Extension;
//                Console.WriteLine($"{item.OptionName}を選択した");
//                return item.OptionName;
//            }
//            return null;
//        }
//    }
//}