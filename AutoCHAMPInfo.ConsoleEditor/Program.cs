using System;
using System.Text;
namespace TypeAutoCHAMP.ConsoleEditor
{
    class Program
    {
         static DataContext dataContext;
         static Editor editor;
        /* static string[] items = new string[] {
             "Україна",
             "Сполучені Штати Америки",
             "Боснія і Герцеговина",
         };
        */

       // static SimpleSelector selector;

        static void Main(string[] args) {
            Console.Title = "AutoCHAMPInfo.ConsoleEditor Yroshenko Pavlo P.)";
            Settings.SetConsoleParam();
            Console.WriteLine("Реалізація класів для предметної області");
            /*Console.OutputEncoding = Encoding.Unicode;
            Console.Write("\nSelect item: ");
            selector = new SimpleSelector(Console.CursorLeft,
                Console.CursorTop, 30, items);
            selector.Focus();
            string text = selector.Text;
            */
            dataContext = new DataContext();
            editor = new Editor(dataContext);
            editor.Run();
            //int s = Entering.EnterInt32("Vedit 4islo");
            //Console.WriteLine(s);

            //Console.ReadKey(true);
        }

    }
}
