using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime;
using System.Text;

namespace ConsoleGame.Options
{
    internal class YesNoOptions
    {
        public static bool GetYesOrNo()
        {
            while (true)
            {
                Console.WriteLine("Yes:1, No:0");
                switch (Console.ReadLine())
                {
                    case "1":
                        return true;

                    case "0":
                        return false;

                    default:
                        Console.WriteLine("選択肢の入力ミス");
                        continue;
                }
            }
        }
    }
}