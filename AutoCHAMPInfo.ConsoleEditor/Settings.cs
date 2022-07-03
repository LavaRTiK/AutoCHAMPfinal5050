using System;
using System.Text;

namespace TypeAutoCHAMP {
    static class Settings {
        public static void SetConsoleParam() {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
        }
    }
}
