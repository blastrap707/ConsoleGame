using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleGame.Options
{
    public class OptionManager
    {
        public static ConsoleKey GetKey()
        {
            return GetKey(ConsoleKey.UpArrow, ConsoleKey.DownArrow, ConsoleKey.Enter, ConsoleKey.Spacebar, ConsoleKey.Escape);
        }
        public static ConsoleKey GetKey(params ConsoleKey[] acceptKeyes)
        {
            for (; ; )
            {
                var k = Console.ReadKey(true);
                if (acceptKeyes.Contains(k.Key))
                {
                    return k.Key;
                }
            }
        }
        public Option<T> ShowOptions<T>(IReadOnlyList<Option<T>> commands, int cursorPosition = 0)
        {
            var initialTop = Console.CursorTop;

            for (; ; )
            {
                Console.CursorTop = initialTop;
                Console.CursorVisible = false;

                var i = 0;
                foreach (var c in commands)
                {
                    Console.WriteLine($"{(i++ == cursorPosition ? "⇒" : "  ")} {c.Caption}");
                }

                switch (GetKey())
                {
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        return commands[cursorPosition];

                    case ConsoleKey.Escape:
                        return null;

                    case ConsoleKey.UpArrow:
                        cursorPosition--;
                        break;

                    case ConsoleKey.DownArrow:
                        cursorPosition++;
                        break;

                    default:
                        break;
                }

                if (cursorPosition < 0)
                {
                    cursorPosition = commands.Count - 1;
                }
                else if (cursorPosition >= commands.Count)
                {
                    cursorPosition = 0;
                }
            }
        }
    }
}

