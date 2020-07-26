using System.Collections.Generic;
using System.Linq;

namespace ConsoleGame.Options
{
    public class Option<T>
        {
            public static IReadOnlyList<Option<T>> CreateCommands(params string[] caption)
            {
                return caption.Select(v => new Option<T>(v)).ToList().AsReadOnly();
            }

            public string Caption { get; private set; }

            public T Extension { get; private set; }

            public Option(string caption)
                : this(caption, default)
            {
            }

            public Option(string caption, T extension)
            {
                Caption = caption;
                Extension = extension;
            }
    }
}