using System;

namespace TypeAutoCHAMP
{
    public static class Entering
    {
        public static string format = "{0,40}: ";

        public static int EnterInt32(string prompt) {
            bool test = true;
            while (test == true)
            {
                Console.Write(format, prompt);
                string s = Console.ReadLine();
                try
                {
                    int value = int.Parse(s);
                    test = false;
                    return value;;
                }
                catch
                {
                    Console.WriteLine("\t Oшибка");
                } 
            }
            return 0;
            //Console.Write(format, prompt);
            //string s = Console.ReadLine();
            //int value = int.Parse(s);
            //return value;
        }

        public static string EnterString(string prompt) {
            Console.Write(format, prompt);
            string s = Console.ReadLine();
            return s.Trim();
        }

        public static string EnterStringOrNull(string prompt) {
            Console.Write(format, prompt);
            string s = Console.ReadLine();
            s = s.Trim();
            return s == "" ? null : s;
        }

        public static double? EnterNullableDouble(string prompt) {
            //Console.Write(format, prompt);
            //string s = Console.ReadLine();
            //return (s == "") ? (double?)null : Convert.ToDouble(s);
            bool test = true;
            while (test == true)
            {
                Console.Write(format, prompt);
                string s = Console.ReadLine();
                try
                {
                    double? value = (s == "") ? (double?)null : Convert.ToDouble(s);
                    test = false;
                    return value;

                }
                catch
                {
                    Console.WriteLine("\t Oшибка");
                }
            }
            return 0;
        }


    }
}
