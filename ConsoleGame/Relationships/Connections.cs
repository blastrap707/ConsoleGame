using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using ConsoleGame.Activities;
using ConsoleGame.Options;
using ConsoleGame.Relationships;

//人間関係を示すクラス

namespace ConsoleGame
{
    public class Connections
    {
        private static readonly Connections[] Friends =
        {
            new Friend(){FriendName = "aさん",Likes = 10,OnetimeLimit=100000,TotalBorrowing=0},
            new Friend(){FriendName = "bさん",Likes = 5,OnetimeLimit=100000,TotalBorrowing=0},
            new Friend(){FriendName = "cさん",Likes = 1,OnetimeLimit=100000,TotalBorrowing=0},
            new Friend(){FriendName = "dさん",Likes = 0,OnetimeLimit=100000,TotalBorrowing=0},
            new Friend(){FriendName = "eさん",Likes = 10,OnetimeLimit=100000,TotalBorrowing=0}
        };

        public virtual int Borrow { get; set; }
        public virtual int TotalBorrowing { get; set; }

        public virtual string FriendName { get; set; }
        public virtual int OnetimeLimit { get; set; }

        public virtual int Likes { get; set; }

        public virtual bool CanLend { get; set; }

        private static Dictionary<string, Connections> People => Friends
            .ToDictionary(x => x.FriendName);

        public static Connections ChooseFriends()
        {
            return People.GetValueOrDefault(GetSelectedFriend());
        }

        private static string GetSelectedFriend()
        {
            Console.WriteLine("誰から借りますか？");
            Console.WriteLine();

            var cm = new OptionManager();
            //var list = FriendsOptions;

            var c = cm.ShowOptions(
                Friends.Select(e => new Option<Connections>($"{e.FriendName}", e)).ToList()
                );

            Console.WriteLine($"{c?.Caption ?? "キャンセル"} が選択されました");

            if (c == null) return null;
            var item = c.Extension;
            Console.WriteLine($"{item.FriendName}を選択した");
            return item.FriendName;
        }
    }
}